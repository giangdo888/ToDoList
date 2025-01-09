using ToDoListServer.Dtos;

namespace ToDoListServer.Interfaces.IServices
{
    public interface IProjectService
    {
        public Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
        //public Task<ProjectDto> GetProjectByIdAsync(int id);
        //public Task<ProjectDto> CreateProjectAsync(ProjectDto project);
        //public Task<ProjectDto> UpdateProjectAsync(ProjectDto project);
        //public Task<bool> DeleteProjectAsync(int id);
    }
}
