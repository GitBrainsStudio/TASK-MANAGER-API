using Application.Interfaces;
using Domain;
using Infrastructure.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controllers
{
    [ApiController]
    [Route("todo-lists")]
    public class TodoListsController : ControllerBase
    {
        private readonly ITodoListService _todoListService;

        public TodoListsController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_todoListService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Ok(_todoListService.GetById(id));
        }

        [HttpPost]
        public IActionResult Create(TodoList todoListDto)
        {
            return Ok(_todoListService.Create(todoListDto));
        }

        [HttpPut]
        public IActionResult Update(TodoList todoListDto)
        {
            return Ok(_todoListService.Update(todoListDto));
        }

    }
}
