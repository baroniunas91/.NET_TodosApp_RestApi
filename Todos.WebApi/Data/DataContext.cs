using Microsoft.EntityFrameworkCore;
using Todos.WebApi.Models;

namespace Todos.WebApi.Data
{
    public class DataContext : DbContext
    {
        public DbSet<TodoItem> Todos { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
