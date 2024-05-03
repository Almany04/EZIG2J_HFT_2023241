using EZIG2J_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace EZIG2J_HFT_2023241.Repository
{
    internal class EmployeeDbContext :DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectAssignment> ProjectAssignments { get; set; }

    }
}
