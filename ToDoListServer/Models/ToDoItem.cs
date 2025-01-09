using System.ComponentModel.DataAnnotations;

namespace ToDoListServer.Models
{
    public class ToDoItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsCompleted {  get; set; }

        //foreign keys
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int StateId { get; set; }
        [Required]
        public int PriorityId { get; set; }

        // Navigation properties
        public Project Project { get; set; }
        public State State { get; set; }
        public Priority Priority { get; set; }
    }
}
