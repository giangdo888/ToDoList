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
        public List<ToDoItem> ToDoItems { get; set; }
        public List<State> States { get; set; }
    }
}
