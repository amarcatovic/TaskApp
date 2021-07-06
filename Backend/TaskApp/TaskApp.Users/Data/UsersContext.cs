using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskApp.Users.Data.Models;

namespace TaskApp.Users.Data
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; }


        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email);

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .HasDefaultValue(null);

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .HasDefaultValue(null);

            base.OnModelCreating(modelBuilder);
        }
    }
}
