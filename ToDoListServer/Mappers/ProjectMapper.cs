using AutoMapper;
using ToDoListServer.Dtos;
using ToDoListServer.Models;

namespace ToDoListServer.Mappers
{
    public class ProjectMapper : Profile
    {
        public ProjectMapper()
        {
            CreateMap<Project, ProjectDto>();
            CreateMap<ProjectDto, Project>();
        }
    }
}
