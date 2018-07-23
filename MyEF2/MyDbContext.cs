using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MyEF2.Configuration;
using MyEF2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEF2
{
    public class MyDbContext : DbContext
    {
      
        public DbSet<Class> Classes { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Students> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql("Server = 127.0.0.1; Database = study; uid = root; pwd = root; SslMode = none; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Class>().ToTable("T_Classs");

            modelBuilder.Entity<Teachers>().ToTable("T_Teachers");

            //modelBuilder.Entity<Students>()    //这是EF 2.0之前版本将配置写在OnModelCreating方法中的写法
            //    .ToTable("T_Students")
            //    .HasOne(s => s.Class)
            //    .WithMany(e => e.Students)
            //    .HasForeignKey(e => e.ClassId);

            modelBuilder.ApplyConfiguration(new StudentCofig());  //这是将单独的配置类注册到OnModelCreating中

            modelBuilder.ApplyConfiguration(new TeacherClassConfig());
               

        }
    }
}
