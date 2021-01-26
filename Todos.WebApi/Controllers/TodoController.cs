using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Todos.WebApi.Dto;
using Todos.WebApi.Interfaces;
using Todos.WebApi.Models;

namespace Todos.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController
    {
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoController(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        [HttpGet]
        public async Task<List<TodoItem>> Get()
        {
            return await _todoItemRepository.GetAll();
        }

        [HttpPost]
        public async Task <TodoItem> Create(TodoItemDto item)
        {
            return await _todoItemRepository.Add(item);
        }

        [HttpPut("{id}")]
        public async Task<TodoItem> Put(TodoItemDto item, int id)
        {
            return await _todoItemRepository.Toggle(item, id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _todoItemRepository.Delete(id);
        }
    }
}
