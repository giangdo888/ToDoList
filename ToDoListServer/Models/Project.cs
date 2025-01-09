using System.ComponentModel.DataAnnotations;

namespace ToDoListServer.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        //navigation props
        public ICollection<ToDoItem> ToDoItems { get; set; }
        public ICollection<State> States { get; set; }
    }
}
