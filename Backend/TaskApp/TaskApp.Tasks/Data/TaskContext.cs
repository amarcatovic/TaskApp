using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaskApp.Tasks.Data.Models;

namespace TaskApp.Tasks.Data
{
    public class TaskContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Task>()
                .Property(t => t.Title)
                .IsRequired();

            modelBuilder.Entity<Task>()
                .Property(t => t.Description)
                .IsRequired();

            modelBuilder.Entity<Task>()
                .Property(t => t.StartDate)
                .IsRequired();

            modelBuilder.Entity<Task>()
                .Property(t => t.FinishDate)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
