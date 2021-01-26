using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todos.WebApi.Data;
using Todos.WebApi.Dto;
using Todos.WebApi.Interfaces;
using Todos.WebApi.Models;

namespace Todos.WebApi.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly DataContext _context;

        public TodoItemRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<TodoItem>> GetAll()
        {
            return await _context.Todos.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<TodoItem> Add(TodoItemDto item)
        {
            var itemAdd = new TodoItem();
            itemAdd.Title = item.Title;
            itemAdd.Completed = item.Completed;
            _context.Todos.Add(itemAdd);
            await _context.SaveChangesAsync();
            return itemAdd;
        }

        public async Task <TodoItem> Toggle(TodoItemDto item, int id)
        {
            var itemUpdate = new TodoItem()
            {
                Id = id,
                Title = item.Title,
                Completed = item.Completed
            };
            _context.Todos.Update(itemUpdate);
            await _context.SaveChangesAsync();
            return itemUpdate;
        }

        public async Task Delete(int id)
        {
            var item = _context.Todos.Where(i => i.Id == id).SingleOrDefault();
            _context.Todos.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
