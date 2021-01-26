using System.Collections.Generic;
using System.Threading.Tasks;
using Todos.WebApi.Dto;
using Todos.WebApi.Models;

namespace Todos.WebApi.Interfaces
{
    public interface ITodoItemRepository
    {
        Task<List<TodoItem>> GetAll();
        Task<TodoItem> Add(TodoItemDto item);
        Task<TodoItem> Toggle(TodoItemDto item, int id);
        Task Delete(int id);
    }
}
