using Azure;
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
        private readonly IToDoItemService _toDoItemService;

        public ProjectController(IProjectService projectService, IToDoItemService toDoItemService)
        {
            _projectService = projectService;
            _toDoItemService = toDoItemService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProjectsController()
        {
            var response = await _projectService.GetAllProjectsAsync();
            return Ok(response ?? Enumerable.Empty<ProjectDto>());
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

        [HttpGet("{id}/items")]
        public async Task<IActionResult> GetToDoItemsByProjectIdAsync(int id)
        {
            var response = await _toDoItemService.GetToDoItemsByProjectIdAsync(id);
            return Ok(response ?? Enumerable.Empty<ToDoItemDtos>());
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
            return Ok($"Successfully deleted project with id {id}");
        }

        [HttpDelete("{id}/items/completed")]
        public async Task<IActionResult> DeleteCompletedItemsAsync(int id)
        {
            await _toDoItemService.DeleteCompletedToDoItemsAsync(id);
            return Ok($"Successfully deleted completed to do items from project with id {id}");
        }
    }
}
