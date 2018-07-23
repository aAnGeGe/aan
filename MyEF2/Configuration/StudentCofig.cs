using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEF2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEF2.Configuration
{
    public class StudentCofig : IEntityTypeConfiguration<Students>
    {
        public void Configure(EntityTypeBuilder<Students> builder)
        {
            builder.ToTable("T_Students")
                .HasOne(s => s.Class)
                .WithMany(e => e.Students)
                .HasForeignKey(e => e.ClassId);
        }
    }
}
