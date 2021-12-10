using CursusInzicht.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursusInzicht.DataAcces.Configurations
{
    public class CursusInstantieConfiguratie : IEntityTypeConfiguration<CursusInstantie>
    {
        public void Configure(EntityTypeBuilder<CursusInstantie> builder) {
            builder.HasKey(c => c.CursusInstantieId);

            builder.Property(c => c.CursusInstantieId)
                .HasColumnName("CursusInstantieId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();
        }
    }
}
