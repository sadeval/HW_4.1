using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserSettings> UserSettings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=UserManagement;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.UserSettings)
            .WithOne(us => us.User)
            .HasForeignKey<UserSettings>(us => us.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Marta" },
            new User { Id = 2, Name = "Jane" },
            new User { Id = 3, Name = "Fina" }
        );

        modelBuilder.Entity<UserSettings>().HasData(
            new UserSettings { UserId = 1, Theme = "Dark", NotificationsEnabled = true },
            new UserSettings { UserId = 2, Theme = "Light", NotificationsEnabled = false },
            new UserSettings { UserId = 3, Theme = "Blue", NotificationsEnabled = true }
        );
    }
}
