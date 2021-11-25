using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITodoListService
    {
        IEnumerable<TodoList> GetAll();
        TodoList GetById(Guid id);
        Guid Create(TodoList todoListDto);
        Guid Update(TodoList todoListDto);
    }
}
