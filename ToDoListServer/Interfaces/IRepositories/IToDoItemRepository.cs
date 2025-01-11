using ToDoListServer.Models;

namespace ToDoListServer.Interfaces.IRepositories
{
    public interface IToDoItemRepository
    {
        public Task<IEnumerable<ToDoItem>> GetToDoItemsByProjectIdAsync(int projectId);
        public Task<ToDoItem> CreateToDoItemAsync(ToDoItem item);
        public Task<ToDoItem> UpdateToDoItemAsync(ToDoItem item);
        public Task DeleteToDoItemAsync(int id);
        public Task DeleteCompletedToDoItemsAsync(int projectId);
    }
}
