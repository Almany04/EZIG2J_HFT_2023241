using EZIG2J_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Numerics;

namespace EZIG2J_HFT_2023241.Repository
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAssignment> ProjectAssignments { get; set; }

        public EmployeeDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("employee");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectAssignment>()
                .HasOne(pa => pa.Employee)
                .WithMany(e => e.ProjectAssignments)
                .HasForeignKey(pa => pa.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectAssignment>()
                .HasOne(pa => pa.Project)
                .WithMany(p => p.ProjectAssignments)
                .HasForeignKey(pa => pa.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Employee>().HasData(new Employee[]
            {
                    new Employee ("1#John Doe#2022*01*01#1"),
                    new Employee("2#Alice Smith#2023*05*15#2"),
                    new Employee("3#Michael Johnson#2022*11*30#3"),
                    new Employee("4#Emily Brown#2024*02*20#4"),
                    new Employee("5#Daniel Wilson#2023*08*10#5"),
                    new Employee("6#Jessica Taylor#2022*04*05#2"),
                    new Employee("7#Christopher Martinez#2023*01*18#4"),
                    new Employee("8#Sarah Anderson#2024*03*22#3"),
                    new Employee("9#Matthew Thomas#2022*07*11#4"),
                    new Employee("10#Emma Garcia#2023*09*27#1"),
                    new Employee("11#David Hernandez#2022*06*08#2"),
                    new Employee("12#Olivia Lopez#2024*01*14#4"),
                    new Employee("13#James Gonzalez#2023*10*30#1"),
                    new Employee("14#Sophia Perez#2022*03*25#3"),
                    new Employee("15#Benjamin Rodriguez#2024*04*09#5"),
                    new Employee("16#Isabella Lewis#2023*12*03#5"),
                    new Employee("17#Jacob Lee#2022*09*17#3"),
                    new Employee("18#Mia Walker#2023*06*22#2"),
                    new Employee("19#William Moore#2022*02*11#3"),
                    new Employee("20#Ava Martin#2024*05*28#1"),
                    new Employee("21#Alexander Hall#2023*11*11#4"),
            });
            modelBuilder.Entity<ProjectAssignment>().HasData(new ProjectAssignment[]
            {
                new ProjectAssignment ("1#10#3"),
                new ProjectAssignment ("2#15#4"),
                new ProjectAssignment ("3#12#5"),
                new ProjectAssignment ("4#11#6"),
                new ProjectAssignment ("5#10#7"),
                new ProjectAssignment ("6#13#6"),
                new ProjectAssignment ("7#15#2"),
                new ProjectAssignment ("8#9#3"),
                new ProjectAssignment ("9#5#5"),
                new ProjectAssignment ("10#5#2"),
            });
            modelBuilder.Entity<Project>().HasData(new Project[]
            {
                new Project("2#New Backend#2022*01*01#2023*04*04"),
                new Project("3#New Frontend#2020*02*22#2021*09*28"),
                new Project("4#Optimalize#2022*03*02#2023*01*18"),
                new Project("5#Getting New Data#2022*10*01#2022*12*14"),
                new Project("6#Slow Softver#2024*02*01#2023*04*26"),
                new Project("7#Saving Problems#2024*04*07#2023*05*03"),
            });
            modelBuilder.Entity<Department>().HasData(new Department[]
            {
                new Department("1#Telekom"),
                new Department("2#Vodafone"),
                new Department("3#Telenor"),
                new Department("4#UPC"),
                new Department("5#Digi"),
            });
        }

    }
}
