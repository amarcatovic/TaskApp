using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskApp.Users.Data;
using TaskApp.Users.Data.Models;

namespace TaskApp.Users.Utilities.MigrateDb
{
    public static class Migrate
    {
        public static async Task PopulateAsync(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            await SeedDataAsync(serviceScope.ServiceProvider.GetService<UsersContext>());
        }

        public static async Task SeedDataAsync(UsersContext context)
        {
            await context.Database.MigrateAsync();
            await context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Users");
            await context.Users.AddRangeAsync(
                new User()
                {
                    Email = "john.doe@taskapp.com",
                    FirstName = "John",
                    LastName = "Doe"
                },
                new User()
                {
                    Email = "manuel.neuer@taskapp.com",
                    FirstName = "Manuel",
                    LastName = "Neuer"
                },
                new User()
                {
                    Email = "alan.jone@taskapp.com",
                    FirstName = "Alan",
                    LastName = "Jone"
                }
            );
            await context.SaveChangesAsync();
        }
    }
}
