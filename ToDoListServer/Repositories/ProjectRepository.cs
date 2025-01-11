using Microsoft.EntityFrameworkCore;
using ToDoListServer.Data;
using ToDoListServer.Interfaces.IRepositories;
using ToDoListServer.Models;

namespace ToDoListServer.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ToDoListDbContext _dbContext;
        public ProjectRepository(ToDoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Project?> GetProjectByIdAsync(int id)
        {
            return await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
            return project;
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            var existingProject = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == project.Id);
            if (existingProject == null)
            {
                throw new InvalidOperationException($"Not found project with id {project.Id}");
            }

            existingProject.Name = project.Name;
            await _dbContext.SaveChangesAsync();

            return existingProject;
        }

        public async Task DeleteProjectAsync(int id)
        {
            var existingProject = await _dbContext.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (existingProject == null)
            {
                throw new InvalidOperationException($"Not found project with id {id}");
            }

            _dbContext.Projects.Remove(existingProject);
            await _dbContext.SaveChangesAsync();
        }
    }
}
