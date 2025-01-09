using System.ComponentModel.DataAnnotations;

namespace ToDoListServer.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        //navigation props
        public ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
