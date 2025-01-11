using ToDoListServer.Dtos;
using ToDoListServer.Models;

namespace ToDoListServer.Interfaces.IServices
{
    public interface IToDoItemService
    {
        public Task<IEnumerable<ToDoItemDtos>> GetToDoItemsByProjectIdAsync(int projectId);
        public Task<ToDoItemDtos> CreateToDoItemAsync(ToDoItemDtos itemDto);
        public Task<ToDoItemDtos> UpdateToDoItemAsync(ToDoItemDtos itemDto);
        public Task DeleteToDoItemAsync(int id);
        public Task DeleteCompletedToDoItemsAsync(int projectId);
    }
}
