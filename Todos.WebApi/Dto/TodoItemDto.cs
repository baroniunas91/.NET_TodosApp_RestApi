namespace Todos.WebApi.Dto
{
    public class TodoItemDto
    {
        public string Title { get; set; }
        public bool Completed { get; set; } = false;
    }
}
