using System.ComponentModel.DataAnnotations;

namespace ToDoListServer.Models
{
    public class Priority
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        //navigation props
        public List<ToDoItem> ToDoItems { get; set; }
    }
}
