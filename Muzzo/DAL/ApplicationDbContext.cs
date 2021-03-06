﻿using Microsoft.AspNet.Identity.EntityFramework;
using Muzzo.Main.Models;
using Muzzo.DAL.EntityConfigurations;
using System.Data.Entity;

namespace Muzzo.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Attendance> Attendees { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }



        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());

            modelBuilder.Configurations.Add(new AttendanceConfiguration());

            modelBuilder.Configurations.Add(new FollowingConfiguration());

            modelBuilder.Configurations.Add(new GenreConfiguration());

            modelBuilder.Configurations.Add(new GigConfiguration());

            modelBuilder.Configurations.Add(new NotificationConfiguration());

            modelBuilder.Configurations.Add(new UserNotificationConfiguration());

            base.OnModelCreating(modelBuilder); 
        }
    }
}