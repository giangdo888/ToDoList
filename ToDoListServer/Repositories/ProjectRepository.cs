using Microsoft.EntityFrameworkCore;
using ToDoListServer.Data;
using ToDoListServer.Interfaces.IRepositories;
using ToDoListServer.Models;

namespace ToDoListServer.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ToDoListDbContext _dbContext;
        private readonly ILogger<ProjectRepository> _logger;
        public ProjectRepository(ToDoListDbContext dbContext, ILogger<ProjectRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            try
            {
                return await _dbContext.Projects.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Repository: Error fetching all projects: {msg}", ex.Message);
                throw;
            }
        }
    }
}
