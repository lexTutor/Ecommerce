using HomeManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace HomeManagement.DataAccess
{
    public class DataContext: IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> dbContext) : base(dbContext)
        {

        }
        public DbSet<Task> Tasks { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<TaskIssue> TaskIssues { get; set; }

        public DbSet<Reaction> Reactions { get; set; }

        public DbSet<PersonalIssue> PersonalIssues { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Chat> Chat { get; set; }

        public DbSet<UserTasks> UserTasks { get; set; }

        public DbSet<Family> Family { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserTasks>().HasKey(Tasks => new { Tasks.AppUserId, Tasks.TaskId });
            builder.Entity<UserTasks>().HasOne(user => user.AppUser).WithMany(user => user.Tasks);
            builder.Entity<UserTasks>().HasOne(task => task.Task).WithMany(task => task.TaskAsignees);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
