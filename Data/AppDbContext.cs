using Microsoft.EntityFrameworkCore;
using ToDoTask.Models;

namespace ToDoTask.Data
{
    public class AppDbContext:DbContext
    {
        public DbSet<ToDoTask.Models.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder= new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string? connection = builder.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connection);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comment>()
                .HasOne(e=>e.Task).WithMany(e=>e.Comments)
                .HasForeignKey(e=>e.TaskId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(e=>e.User).WithMany(e=>e.Comments)
                .HasForeignKey(e=>e.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
