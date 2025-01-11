using System.ComponentModel.DataAnnotations;

namespace ToDoListServer.Dtos
{
    public class ToDoItemDtos
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "IsCompleted is required")]
        public bool IsCompleted { get; set; }
        [Required(ErrorMessage = "ProjectId is required")]
        public int ProjectId { get; set; }
        [Range(1, 4, ErrorMessage = "StateId must be between 1 and 4")]
        public int StateId { get; set; }
        [Range(1, 4, ErrorMessage = "PriorityId must be between 1 and 4")]
        public int PriorityId { get; set; }
    }
}
