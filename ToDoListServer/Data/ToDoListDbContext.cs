using Microsoft.EntityFrameworkCore;
using ToDoListServer.Models;

namespace ToDoListServer.Data
{
    public class ToDoListDbContext : DbContext
    {
        public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Priority> Priorities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Projects
            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Name = "Work", CreatedDate = new DateTime(2025, 1, 9, 9, 21, 54, 443, DateTimeKind.Utc) },
                new Project { Id = 2, Name = "Personal", CreatedDate = new DateTime(2025, 1, 9, 9, 21, 54, 443, DateTimeKind.Utc) }
            );

            // Seed States
            modelBuilder.Entity<State>().HasData(
                new State { Id = 1, Name = "Backlog" },
                new State { Id = 2, Name = "InProgress" },
                new State { Id = 3, Name = "Testing" },
                new State { Id = 4, Name = "Done" }
            );

            // Seed Priorities
            modelBuilder.Entity<Priority>().HasData(
                new Priority { Id = 1, Name = "Low" },
                new Priority { Id = 2, Name = "Medium" },
                new Priority { Id = 3, Name = "High" },
                new Priority { Id = 4, Name = "Critical" }
            );

            // Seed ToDoItems
            modelBuilder.Entity<ToDoItem>().HasData(
                new ToDoItem { Id = 1, Name = "Complete project report", IsCompleted = false, ProjectId = 1, PriorityId = 3, StateId = 1 },
                new ToDoItem { Id = 2, Name = "Buy groceries", IsCompleted = false, ProjectId = 2, PriorityId = 2, StateId = 1 }
            );
        }

    }
}
