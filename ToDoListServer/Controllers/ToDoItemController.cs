using Microsoft.AspNetCore.Mvc;
using ToDoListServer.Dtos;
using ToDoListServer.Interfaces.IServices;

namespace ToDoListServer.Controllers
{
    [Route("/items")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoItemService _toDoItemService;

        public ToDoItemController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDoItemControllerAsync(ToDoItemDtos item)
        {
            var response = await _toDoItemService.CreateToDoItemAsync(item);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDoItemControllerAsync(int id, ToDoItemDtos item)
        {
            item.Id = id;
            var response = await _toDoItemService.UpdateToDoItemAsync(item);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItemControllerAsync(int id)
        {
            await _toDoItemService.DeleteToDoItemAsync(id);
            return Ok($"Successfully deleted to do item with id {id}");
        }
    }
}
