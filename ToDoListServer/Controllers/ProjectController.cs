using Microsoft.AspNetCore.Mvc;
using ToDoListServer.Dtos;
using ToDoListServer.Interfaces.IServices;

namespace ToDoListServer.Controllers
{
    [Route("/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly ILogger<ProjectController> _logger;

        public ProjectController(IProjectService projectService, ILogger<ProjectController> logger)
        {
            _projectService = projectService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjectsController()
        {
            var reponse = await _projectService.GetAllProjectsAsync();
            if (!reponse.Any())
            {
                return Ok();
            }
            return Ok(reponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectByIdAsync(int id)
        {
            var response = await _projectService.GetProjectByIdAsync(id);
            if (response == null)
            {
                return NotFound($"Not found project with id {id}");
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProjectAsync(ProjectDto projectDto)
        {
            var response = await _projectService.CreateProjectAsync(projectDto);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProjectAsync(int id,  ProjectDto projectDto)
        {
            projectDto.Id = id;
            var response = await _projectService.UpdateProjectAsync(projectDto);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectAsync(int id)
        {
            await _projectService.DeleteProjectAsync(id);
            return Ok($"Delete project with id {id} succesfully");
        }
    }
}
