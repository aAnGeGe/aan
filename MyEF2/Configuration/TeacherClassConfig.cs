using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEF2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEF2.Configuration
{
    class TeacherClassConfig : IEntityTypeConfiguration<TeacherClass>
    {
        public void Configure(EntityTypeBuilder<TeacherClass> builder)
        {
            builder.ToTable("T_TeacherClass")
                  .HasKey(t => new { t.ClassId, t.TeacherId });
            builder.HasOne(t => t.Teachers).WithMany(t => t.TeacherClasses).HasForeignKey(t => t.TeacherId);
            builder.HasOne(t => t.Class).WithMany(c => c.TeacherClasses).HasForeignKey(t => t.ClassId);
        }
    }
}
