﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GymWebAPI.Models
{
    public class GymContext : DbContext
    {

        private readonly IConfiguration _config;
        public GymContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<TrainingEntity> Trainings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(_config.GetConnectionString("GymCore"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainingEntity>()
           .HasData(new
           {
               Id = Guid.NewGuid(),
               Name = "Fitness",
               Instructor = "Javier",
               Schedules = 10
           });

            base.OnModelCreating(modelBuilder);
        }

    }
}
