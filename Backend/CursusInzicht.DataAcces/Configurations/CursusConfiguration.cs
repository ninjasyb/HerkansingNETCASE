using CursusInzicht.Domain.Interfaces;
using CursusInzicht.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CursusInzicht.DataAcces.Configurations
{
    public class CursusConfiguration : IEntityTypeConfiguration<Cursus>
    {
        public void Configure(EntityTypeBuilder<Cursus> builder) {
            builder.HasKey(c => c.CursusId);

            builder.Property(c => c.CursusId)
                .HasColumnName("CursusId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(c => c.Titel)
                .HasMaxLength(300);

            builder.Property(c => c.CursusCode)
                .HasMaxLength(10);
        }
    }
}
