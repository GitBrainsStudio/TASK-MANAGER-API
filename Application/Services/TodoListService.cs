using Application.Interfaces;
using Domain;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = Domain.Task;

namespace Application.Services
{
    public class TodoListService : ITodoListService
    {
        private readonly ApplicationContext _context;

        public TodoListService(ApplicationContext context)
        {
            _context = context;
        }
 

        public IEnumerable<TodoList> GetAll()
        {
            return _context.TodoLists
                .Include(item => item.Tasks).ToList();
        }

        public TodoList GetById(Guid id)
        {
            return _context.TodoLists
                .Where(item => item.Id == id)
                .Include(item => item.Tasks)
                .FirstOrDefault();
        }

        public Guid Create(TodoList todoListDto)
        {
            var todoListId = Guid.NewGuid();

            var todoListTasks = new List<Task>();

            todoListDto.Tasks.ToList().ForEach(taskDto =>
            {
                todoListTasks.Add(new Task(
                    Guid.NewGuid(),
                    taskDto.Name,
                    false,
                    todoListId));
            });


            var todoList = new TodoList(
                todoListId,
                todoListDto.Name,
                todoListTasks
                );

            _context.TodoLists.Add(todoList);
            _context.SaveChanges();

            return todoList.Id;
        }

        public Guid Update(TodoList todoListDto)
        {
            var todoList = _context.TodoLists
                .Include(item => item.Tasks)
                .Single(item => item.Id == todoListDto.Id);

            todoListDto.Tasks.ToList().ForEach(taskDto =>
            {
                var task = todoList.Tasks.FirstOrDefault(task => task.Id == taskDto.Id);

                if (task is null)
                {
                    var newTask = new Task(
                          taskDto.Id,
                          taskDto.Name,
                          taskDto.Completed,
                          todoList.Id
                        );

                    _context.Tasks.Add(newTask);
                    todoList.Tasks.Add(newTask);
                }

                else
                {
                    if (task.Completed != taskDto.Completed)
                    {
                        task.Completed = taskDto.Completed;
                        _context.Tasks.Update(task);
                    }
                }
            });

            _context.TodoLists.Update(todoList);
            _context.SaveChanges();

            return todoList.Id;
        }
    }
}
