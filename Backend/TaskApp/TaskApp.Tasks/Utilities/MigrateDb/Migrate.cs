using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskApp.Tasks.Data;

namespace TaskApp.Tasks.Utilities.MigrateDb
{
    public class Migrate
    {
        public static async Task PopulateAsync(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            await SeedDataAsync(serviceScope.ServiceProvider.GetService<TaskContext>());
        }

        private static async Task SeedDataAsync(TaskContext context)
        {
            await context.Database.MigrateAsync();
            await context.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Tasks");
            await context.Tasks.AddRangeAsync(
                new Data.Models.Task()
                {
                    Title = "Add new Feature on Backend",
                    Description = "In order to finish the clients requirements, we need to add a new feature to lazy load books into component",
                    UserId = 1,
                    AssigneeId = 2,
                    StartDate = DateTime.Now.AddDays(-2),
                    FinishDate = DateTime.Now.AddDays(7)
                },
                new Data.Models.Task()
                {
                    Title = "Client Meeting",
                    Description = "We need to talk about new features and improvements for TaskApp",
                    UserId = 3,
                    AssigneeId = 2,
                    StartDate = DateTime.Now.AddDays(-2),
                    FinishDate = DateTime.Now.AddDays(3)
                },
                new Data.Models.Task()
                {
                    Title = "Email Supplier about new costs",
                    Description = "We need to email our supplier for new costs as we are in need to make the products more expensive",
                    UserId = 2,
                    AssigneeId = 1,
                    StartDate = DateTime.Now.AddDays(-2),
                    FinishDate = DateTime.Now.AddDays(8)
                },
                new Data.Models.Task()
                {
                    Title = "Write 5 requirements for profile page",
                    Description = "We need to redesign our profile page in order to show users tasks and assigned tasks.",
                    UserId = 2,
                    AssigneeId = 1,
                    StartDate = DateTime.Now.AddDays(-2),
                    FinishDate = DateTime.Now.AddDays(8)
                },
                new Data.Models.Task()
                {
                    Title = "Organise teambuilding",
                    Description = "We need to organise team building this week",
                    UserId = 3,
                    AssigneeId = 2,
                    StartDate = DateTime.Now.AddDays(-2),
                    FinishDate = DateTime.Now.AddDays(1)
                }
            );
            await context.SaveChangesAsync();
        }
    }
}
