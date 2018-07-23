using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MySqlEFCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySqlEFCore
{
   public class MyDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<TClass> Classes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("Server=127.0.0.1;Database=study;uid=root;pwd=root;SslMode = none;");
            //.UseLazyLoadingProxies()
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().ToTable("T_Students").HasOne(s => s.TClass).WithMany().HasForeignKey(e => e.ClassId).IsRequired();

            modelBuilder.Entity<TeacherClass>().HasKey(t => new { t.ClassId, t.TeacherId });
            modelBuilder.Entity<TeacherClass>().HasOne(t => t.Teacher).WithMany(t => t.TeacherClass).HasForeignKey(t=>t.TeacherId);
            modelBuilder.Entity<TeacherClass>().HasOne(t => t.TClass).WithMany(t => t.TeacherClass).HasForeignKey(t => t.ClassId);

        }
       

    }

    public class Test : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            return new MyDbContext();
        }
    }
}
