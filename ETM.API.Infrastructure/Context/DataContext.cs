using ETM.API.Core.Entities;

using Microsoft.EntityFrameworkCore;

namespace ETM.API.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Admin",
                    Email = "enosisbd@gmail.com",
                    ImageUri = "/enosis.png",
                },
                new User
                {
                    Id = 2,
                    Name = "Sabbir",
                    Email = "sabbir@gmail.com",
                    ImageUri = "/sabbir.png",
                    CreatedBy = 1,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.UtcNow,
                },
                new User
                {
                    Id = 3,
                    Name = "Shimanto",
                    Email = "Shimanto@gmail.com",
                    ImageUri = "/photo.png",
                    CreatedBy = 1,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.UtcNow,
                });

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name = "Engineering",
                    CreatedBy = 1,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.UtcNow,
                },
                new Department
                {
                    Id = 2,
                    Name = "IT",
                    CreatedBy = 1,
                    CreatedOn = DateTime.UtcNow.AddDays(1),
                    ModifiedBy = 1,
                    ModifiedOn = DateTime.UtcNow.AddDays(2),
                });


            modelBuilder.Entity<Status>().HasData(
                new Status
                {
                    Id = 1,
                    Type = "Pending Approval",
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn= DateTime.UtcNow
                },
                new Status
                {
                    Id = 2,
                    Type = "Approved",
                    CreatedBy = 1,
                    ModifiedBy = 1,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow
                });

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull); 

            modelBuilder.Entity<Ticket>()
                .HasMany(t => t.Comments)
                .WithOne(c => c.Ticket)
                .HasForeignKey(c => c.TicketId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.CreatedBy)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
