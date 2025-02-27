﻿// <auto-generated />
using System;
using CursusInzicht.DataAcces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CursusInzicht.DataAcces.Migrations
{
    [DbContext(typeof(CursusInzichtContext))]
    [Migration("20211206102058_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CursusInzicht.Domain.Models.Cursus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CursusCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("Duur")
                        .HasColumnType("int");

                    b.Property<string>("Titel")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("Cursussen");
                });

            modelBuilder.Entity("CursusInzicht.Domain.Models.CursusInstantie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CursusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDatum")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CursusId");

                    b.ToTable("CursusInstanties");
                });

            modelBuilder.Entity("CursusInzicht.Domain.Models.CursusInstantie", b =>
                {
                    b.HasOne("CursusInzicht.Domain.Models.Cursus", "Cursus")
                        .WithMany()
                        .HasForeignKey("CursusId");

                    b.Navigation("Cursus");
                });
#pragma warning restore 612, 618
        }
    }
}
