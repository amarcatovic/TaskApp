using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskApp.Auth.Data;

namespace TaskApp.Auth.Utilities.MigrateDb
{
    public static class PopulateDb
    {
        public static async Task SeedDataAsync(IApplicationBuilder applicationBuilder, RoleManager<IdentityRole> roleManager)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            await dbContext.Database.MigrateAsync();
            await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM AspNetUserRoles WHERE UserId IS NOT NULL");
            await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM AspNetUsers WHERE Id IS NOT NULL");
            await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM AspNetRoles WHERE Id IS NOT NULL");

            await AddRolesAsync(roleManager);

            await dbContext.SaveChangesAsync();
        }

        private static async Task AddRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var userRole = new IdentityRole("User");

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(userRole);
            }
        }
    }
}
