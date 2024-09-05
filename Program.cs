using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;


class Program
{
    static void Main()
    {
        using (var context = new ApplicationContext())
        {
            context.Database.EnsureCreated();

            var user = context.Users
                              .Include(u => u.UserSettings)
                              .FirstOrDefault(u => u.Id == 2);

            Console.WriteLine($"User: {user.Name}, Theme: {user.UserSettings.Theme}, Notifications: {user.UserSettings.NotificationsEnabled}");

            var userToDelete = context.Users.Find(3);
            if (userToDelete != null)
            {
                context.Users.Remove(userToDelete);
                context.SaveChanges();
            }

            Console.WriteLine("User with Id = 3 and their settings have been deleted.");
        }
    }
}
