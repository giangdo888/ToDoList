using Microsoft.Identity.Client;
using ToDoListServer.Models;

namespace ToDoListServer.Interfaces.IRepositories
{
    public interface IProjectRepository
    {
        public Task<IEnumerable<Project>> GetAllProjectsAsync();
        public Task<Project?> GetProjectByIdAsync(int id);
        public Task<Project> CreateProjectAsync(Project project);
        public Task<Project> UpdateProjectAsync(Project project);
        public Task<bool> DeleteProjectAsync(int id);
    }
}
