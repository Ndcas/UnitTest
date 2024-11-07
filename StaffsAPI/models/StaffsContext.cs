using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StaffsAPI.models;

public partial class StaffsContext : DbContext
{
    public StaffsContext()
    {
    }

    public StaffsContext(DbContextOptions<StaffsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Gender> Genders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;uid=root;pwd=;database=staffs");
    } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PRIMARY");

            entity.ToTable("department");

            entity.Property(e => e.DepartmentId)
                .HasColumnType("int(11)")
                .HasColumnName("DepartmentID");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.DepartmentId, "DepartmentID");

            entity.HasIndex(e => e.GenderId, "GenderID");

            entity.Property(e => e.EmployeeId)
                .HasColumnType("int(11)")
                .HasColumnName("EmployeeID");
            entity.Property(e => e.DepartmentId)
                .HasColumnType("int(11)")
                .HasColumnName("DepartmentID");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasDefaultValueSql("'NULL'")
                .IsFixedLength();
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.GenderId)
                .HasColumnType("int(11)")
                .HasColumnName("GenderID");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.StartingDate)
                .HasDefaultValueSql("'curdate()'")
                .HasColumnType("date");

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employee_ibfk_2");

            entity.HasOne(d => d.Gender).WithMany(p => p.Employees)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("employee_ibfk_1");
        });

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.GenderId).HasName("PRIMARY");

            entity.ToTable("gender");

            entity.Property(e => e.GenderId)
                .HasColumnType("int(11)")
                .HasColumnName("GenderID");
            entity.Property(e => e.GenderName)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
