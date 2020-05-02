﻿using EmployeeManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}