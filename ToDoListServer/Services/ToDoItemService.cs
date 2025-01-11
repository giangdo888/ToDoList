using AutoMapper;
using ToDoListServer.Dtos;
using ToDoListServer.Interfaces.IRepositories;
using ToDoListServer.Interfaces.IServices;
using ToDoListServer.Models;
using ToDoListServer.Repositories;

namespace ToDoListServer.Services
{
    public class ToDoItemService : IToDoItemService
    {
        private readonly IToDoItemRepository _toDoItemRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ToDoItemService> _logger;

        public ToDoItemService(IToDoItemRepository toDoItemRepository, IMapper mapper, ILogger<ToDoItemService> logger)
        {
            _toDoItemRepository = toDoItemRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<ToDoItemDtos>> GetToDoItemsByProjectIdAsync(int projectId)
        {
            _logger.LogInformation($"Fetching to do items for project with id {projectId}");
            var items = await _toDoItemRepository.GetToDoItemsByProjectIdAsync(projectId);

            _logger.LogInformation($"Successfully retrieved to do item for project with id {projectId}");
            return _mapper.Map<IEnumerable<ToDoItemDtos>>(items);
        }

        public async Task<ToDoItemDtos> CreateToDoItemAsync(ToDoItemDtos itemDto)
        {
            if (itemDto == null)
            {
                _logger.LogWarning("Missing input when creating new to do item");
                throw new ArgumentNullException(nameof(itemDto));
            }

            var item = _mapper.Map<ToDoItem>(itemDto);
            var response = await _toDoItemRepository.CreateToDoItemAsync(item);

            _logger.LogInformation($"Successfully creating to do item with id {itemDto.Id}");
            return _mapper.Map<ToDoItemDtos>(response);
        }

        public async Task<ToDoItemDtos> UpdateToDoItemAsync(ToDoItemDtos itemDto)
        {
            if (itemDto == null)
            {
                _logger.LogWarning("Missing input when updating to do item");
                throw new ArgumentNullException(nameof(itemDto));
            }
            if (!itemDto.Id.HasValue)
            {
                _logger.LogWarning("Missing Id when updating to do item");
                throw new ArgumentNullException("Id is required");
            }

            var item = _mapper.Map<ToDoItem>(itemDto);
            var response = await _toDoItemRepository.UpdateToDoItemAsync(item);

            _logger.LogInformation($"Successfully updating to do item with id {itemDto.Id}");
            return _mapper.Map<ToDoItemDtos>(response);
        }

        public async Task DeleteToDoItemAsync(int id)
        {
            await _toDoItemRepository.DeleteToDoItemAsync(id);
        }

        public async Task DeleteCompletedToDoItemsAsync(int projectId)
        {
            await _toDoItemRepository.DeleteCompletedToDoItemsAsync(projectId);
        }
    }
}
