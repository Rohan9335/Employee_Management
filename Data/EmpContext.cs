using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data;

public partial class EmpContext : DbContext
{
    public DbSet<Employee> Employee1 { get; set; }
    public EmpContext()
    {
    }

    public EmpContext(DbContextOptions<EmpContext> options): base(options)
    {
    }
   
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySQL("server=localhost;Database=emp;uid=root;pwd=rohan9335");
        }
    }
       

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
