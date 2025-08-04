using Microsoft.EntityFrameworkCore;
using Assignment_2.Shared.Models;
namespace Assignment_2.Shared.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Database context that interacts with [Model]Service classes
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        // Container for Models
        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }

        // Function to create the model with the discriminator based on the TaskItem sub-class
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<TaskItem>("TaskItem")
                .HasValue<HomeWork>("HomeWork")
                .HasValue<Assignment>("Assignment");
        }
    }
}
