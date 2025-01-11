using System.ComponentModel.DataAnnotations;

namespace ToDoListServer.Dtos
{
    public class ProjectDto
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
