﻿using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MessageHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {


        public DbSet<Message> Messages { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }

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
            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Message)
                .WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }

    }
}