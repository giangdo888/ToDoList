using AutoMapper;
using ToDoListServer.Dtos;
using ToDoListServer.Models;

namespace ToDoListServer.Mappers
{
    public class ToDoItemMapper : Profile
    {
        public ToDoItemMapper()
        {
            CreateMap<ToDoItem, ToDoItemDtos>();
            CreateMap<ToDoItemDtos, ToDoItem>();
        }
    }
}
