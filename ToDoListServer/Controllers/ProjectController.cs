using Microsoft.AspNetCore.Mvc;
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
            try
            {
                var result = await _projectService.GetAllProjectsAsync();
                if (!result.Any())
                {
                    return Ok();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("Controller: Database internal error");
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
