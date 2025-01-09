using AutoMapper;
using ToDoListServer.Data;
using ToDoListServer.Dtos;
using ToDoListServer.Interfaces.IRepositories;
using ToDoListServer.Interfaces.IServices;

namespace ToDoListServer.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ToDoListDbContext _dbContext;
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(ToDoListDbContext dbContext, IProjectRepository projectRepository, IMapper mapper, ILogger<ProjectService> logger)
        {
            _dbContext = dbContext;
            _projectRepository = projectRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
        {
            try
            {
                _logger.LogInformation("Service: Fetching project list");
                var projects = await _projectRepository.GetAllProjectsAsync();
                if (!projects.Any())
                {
                    return [];
                }

                _logger.LogInformation("Service: Successfully retrieved project list");
                return _mapper.Map<IEnumerable<ProjectDto>>(projects);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Service: Error occurred while fetching project list");
                throw;
            }
        }
    }
}
