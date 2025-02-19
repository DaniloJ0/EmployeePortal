﻿// <auto-generated />
using System;
using Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250219194315_adjustUserTableMigration")]
    partial class adjustUserTableMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Arls.Arl", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Arls");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f47a4416-8b3a-4e6c-80f4-785e7391b23f"),
                            CreatedAt = new DateTime(2025, 2, 19, 14, 43, 14, 720, DateTimeKind.Local).AddTicks(431),
                            Name = "Sura"
                        },
                        new
                        {
                            Id = new Guid("547f51da-9545-4a7b-b8bd-0a73c8411e26"),
                            CreatedAt = new DateTime(2025, 2, 19, 14, 43, 14, 720, DateTimeKind.Local).AddTicks(431),
                            Name = "Colpatria"
                        });
                });

            modelBuilder.Entity("Domain.Employees.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ArlId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BloodType")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EpsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("PensionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.HasIndex("ArlId");

                    b.HasIndex("EpsId");

                    b.HasIndex("PensionId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Domain.Epss.Eps", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Epss");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c5a65b34-334f-4355-a8b7-0098d92c7f8e"),
                            CreatedAt = new DateTime(2025, 2, 19, 14, 43, 14, 720, DateTimeKind.Local).AddTicks(431),
                            Name = "Sanitas"
                        },
                        new
                        {
                            Id = new Guid("8e0c872e-f1f6-456a-8bcf-3a6b7a2a7c98"),
                            CreatedAt = new DateTime(2025, 2, 19, 14, 43, 14, 720, DateTimeKind.Local).AddTicks(431),
                            Name = "Nueva EPS"
                        });
                });

            modelBuilder.Entity("Domain.Pensions.Pension", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Pensions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("debead27-46a2-446f-8597-ab06b88695b1"),
                            CreatedAt = new DateTime(2025, 2, 19, 14, 43, 14, 720, DateTimeKind.Local).AddTicks(431),
                            Name = "Porvenir"
                        },
                        new
                        {
                            Id = new Guid("880f4e17-7bd1-4b86-a51c-fd5b65b2c33d"),
                            CreatedAt = new DateTime(2025, 2, 19, 14, 43, 14, 720, DateTimeKind.Local).AddTicks(431),
                            Name = "Protección"
                        });
                });

            modelBuilder.Entity("Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Employees.Employee", b =>
                {
                    b.HasOne("Domain.Arls.Arl", "Arl")
                        .WithMany("Employees")
                        .HasForeignKey("ArlId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Epss.Eps", "Eps")
                        .WithMany("Employees")
                        .HasForeignKey("EpsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Pensions.Pension", "Pension")
                        .WithMany("Employees")
                        .HasForeignKey("PensionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Arl");

                    b.Navigation("Eps");

                    b.Navigation("Pension");
                });

            modelBuilder.Entity("Domain.Arls.Arl", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Domain.Epss.Eps", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Domain.Pensions.Pension", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
