using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using ToDoListServer.Data;
using ToDoListServer.Interfaces.IRepositories;
using ToDoListServer.Models;

namespace ToDoListServer.Repositories
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private readonly ToDoListDbContext _dbContext;

        public ToDoItemRepository(ToDoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ToDoItem>> GetToDoItemsByProjectIdAsync(int projectId)
        {
            return await _dbContext.ToDoItems.Where(t => t.ProjectId == projectId).ToListAsync();
        }

        public async Task<ToDoItem> CreateToDoItemAsync(ToDoItem item)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == item.ProjectId);
            if (project == null)
            {
                throw new InvalidOperationException($"Not found project with id {item.ProjectId}");
            }

            await _dbContext.ToDoItems.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return item;
        }

        public async Task<ToDoItem> UpdateToDoItemAsync(ToDoItem item)
        {
            var existingItem = await _dbContext.ToDoItems.FirstOrDefaultAsync(t => t.Id == item.Id);
            if (existingItem == null)
            {
                throw new InvalidOperationException($"Not found to do item with id {item.Id}");
            }

            var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == item.ProjectId);
            if (project == null)
            {
                throw new InvalidOperationException($"Not found project with id {item.ProjectId}");
            }

            //update item
            existingItem.Name = item.Name;
            existingItem.IsCompleted = item.IsCompleted;
            existingItem.ProjectId = item.ProjectId;
            existingItem.PriorityId = item.PriorityId;
            existingItem.StateId = item.StateId;

            await _dbContext.SaveChangesAsync();
            return existingItem;
        }

        public async Task DeleteToDoItemAsync(int id)
        {
            var existingItem = await _dbContext.ToDoItems.FirstOrDefaultAsync(t => t.Id == id);
            if (existingItem == null)
            {
                throw new InvalidOperationException($"Not found to do item with id {id}");
            }

            _dbContext.ToDoItems.Remove(existingItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCompletedToDoItemsAsync(int projectId)
        {
            var project = await _dbContext.Projects
                .Include(p => p.ToDoItems)
                .FirstOrDefaultAsync(p => p.Id == projectId);
            if (project == null)
            {
                throw new InvalidOperationException($"Not found project with id {projectId}");
            }

            var toBeRemovedItems = project.ToDoItems.Where(t => t.IsCompleted == true).ToList();
            if (toBeRemovedItems.Count == 0)
            {
                throw new InvalidOperationException($"No item in project with id {projectId}");
            }

            _dbContext.RemoveRange(toBeRemovedItems);
            await _dbContext.SaveChangesAsync();
        }
    }
}
