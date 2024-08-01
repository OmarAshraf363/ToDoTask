using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;

namespace ToDoTask.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<ToDoTask.Models.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder= new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string? connection = builder.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connection);
        }

    }
}
