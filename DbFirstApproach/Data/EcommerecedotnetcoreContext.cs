using System;
using System.Collections.Generic;
using DbFirstApproach.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFirstApproach.Data;

public partial class EcommerecedotnetcoreContext : DbContext
{
    public EcommerecedotnetcoreContext()
    {
    }

    public EcommerecedotnetcoreContext(DbContextOptions<EcommerecedotnetcoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Mycart> Mycarts { get; set; }

    public virtual DbSet<Myproduct> Myproducts { get; set; }

    public virtual DbSet<User> Users { get; set; }
    public DbSet<Emp> emps { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mycart>(entity =>
        {
            entity.HasKey(e => e.Pid);

            entity.ToTable("Mycart");
        });

        modelBuilder.Entity<Myproduct>(entity =>
        {
            entity.HasKey(e => e.Pid);

            entity.ToTable("myproducts");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
