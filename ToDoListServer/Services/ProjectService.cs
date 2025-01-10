using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDoListServer.Data;
using ToDoListServer.Dtos;
using ToDoListServer.Interfaces.IRepositories;
using ToDoListServer.Interfaces.IServices;
using ToDoListServer.Models;

namespace ToDoListServer.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ProjectService> _logger;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper, ILogger<ProjectService> logger)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
        {
            _logger.LogInformation("Fetching project list");
            var projects = await _projectRepository.GetAllProjectsAsync();
            if (!projects.Any())
            {
                return [];
            }

            _logger.LogInformation("Successfully retrieved project list");
            return _mapper.Map<IEnumerable<ProjectDto>>(projects);
        }

        public async Task<ProjectDto?> GetProjectByIdAsync(int id)
        {
            _logger.LogInformation($"Fetching project with id {id}");
            var project = await _projectRepository.GetProjectByIdAsync(id);
            if (project == null)
            {
                return null;
            }

            _logger.LogInformation($"Successfully retrieved project with id {id}");
            return _mapper.Map<ProjectDto>(project);
        }

        public async Task<ProjectDto> CreateProjectAsync(ProjectDto? projectDto)
        {
            if (projectDto == null)
            {
                _logger.LogWarning("Missing input when creating new project");
                throw new ArgumentNullException(nameof(projectDto));
            }
            if (string.IsNullOrEmpty(projectDto.Name))
            {
                _logger.LogWarning("Missing Name when creating new project");
                throw new ArgumentException("Name is required");
            }

            _logger.LogInformation($"Creating new project {projectDto}");
            var project = _mapper.Map<Project>(projectDto);
            var response = await _projectRepository.CreateProjectAsync(project);

            _logger.LogInformation($"Successfully creating new project with id {projectDto.Id}");
            return _mapper.Map<ProjectDto>(response);
        }

        public async Task<ProjectDto> UpdateProjectAsync(ProjectDto projectDto)
        {
            if (projectDto == null)
            {
                _logger.LogWarning("Missing input when updating new project");
                throw new ArgumentNullException(nameof(projectDto));
            }
            if (!projectDto.Id.HasValue)
            {
                _logger.LogWarning("Missing Id when updating new project");
                throw new ArgumentNullException("Id is required");
            }
            if (string.IsNullOrEmpty(projectDto.Name))
            {
                _logger.LogWarning("Missing Name when updating new project");
                throw new ArgumentException("Name is required");
            }

            var project = _mapper.Map<Project>(projectDto);
            var response = await _projectRepository.UpdateProjectAsync(project);

            _logger.LogInformation($"Successfully updating project with id {projectDto.Id}");
            return _mapper.Map<ProjectDto>(response);
        }

        public async Task<bool> DeleteProjectAsync(int id)
        {
            return await _projectRepository.DeleteProjectAsync(id);
        }
    }
}
