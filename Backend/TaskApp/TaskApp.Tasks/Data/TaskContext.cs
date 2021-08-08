using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskApp.Tasks.Data.Shared;
using Task = TaskApp.Tasks.Data.Models.Task;

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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var changes = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var change in changes)
            {
                var entity = (IEntity)change.Entity;

                if (change.State == EntityState.Added)
                {
                    entity.DateCreated = DateTime.Now;
                }

                if (change.State == EntityState.Modified)
                {
                    entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
