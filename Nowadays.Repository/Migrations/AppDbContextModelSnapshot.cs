﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nowadays.Repository.Context;

#nullable disable

namespace Nowadays.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Nowadays.Core.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 5, 28, 18, 38, 7, 276, DateTimeKind.Local).AddTicks(5432),
                            IsActive = true,
                            Name = "PortalGroup"
                        });
                });

            modelBuilder.Entity("Nowadays.Core.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DateOfBirth")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("NationalIdentity")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            CreatedDate = new DateTime(2024, 5, 28, 18, 38, 7, 276, DateTimeKind.Local).AddTicks(6683),
                            DateOfBirth = 2000,
                            FirstName = "Umut",
                            IsActive = true,
                            LastName = "Ozcan",
                            NationalIdentity = 1234567890L
                        },
                        new
                        {
                            Id = 2,
                            CompanyId = 1,
                            CreatedDate = new DateTime(2024, 5, 28, 18, 38, 7, 276, DateTimeKind.Local).AddTicks(6687),
                            DateOfBirth = 1995,
                            FirstName = "Ahmet",
                            IsActive = true,
                            LastName = "Yılmaz",
                            NationalIdentity = 1234567899L
                        });
                });

            modelBuilder.Entity("Nowadays.Core.Entities.EmployeeProject", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("EmployeeProjects");
                });

            modelBuilder.Entity("Nowadays.Core.Entities.Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Issues");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 5, 28, 18, 38, 7, 277, DateTimeKind.Local).AddTicks(2838),
                            Description = "Check for bugs",
                            IsActive = true,
                            Name = "Fix Bug",
                            ProjectId = 1
                        });
                });

            modelBuilder.Entity("Nowadays.Core.Entities.IssueEmployee", b =>
                {
                    b.Property<int>("IssueId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("IssueId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("IssueEmployees");
                });

            modelBuilder.Entity("Nowadays.Core.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            CreatedDate = new DateTime(2024, 5, 28, 18, 38, 7, 277, DateTimeKind.Local).AddTicks(9160),
                            Description = "Musteri Takip Projesi",
                            IsActive = true,
                            Name = "MusteriTakip"
                        });
                });

            modelBuilder.Entity("Nowadays.Core.Entities.Employee", b =>
                {
                    b.HasOne("Nowadays.Core.Entities.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Nowadays.Core.Entities.EmployeeProject", b =>
                {
                    b.HasOne("Nowadays.Core.Entities.Employee", "Employee")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Nowadays.Core.Entities.Project", "Project")
                        .WithMany("EmployeeProjects")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Nowadays.Core.Entities.Issue", b =>
                {
                    b.HasOne("Nowadays.Core.Entities.Project", "Project")
                        .WithMany("Issues")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Nowadays.Core.Entities.IssueEmployee", b =>
                {
                    b.HasOne("Nowadays.Core.Entities.Employee", "Employee")
                        .WithMany("IssueEmployees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Nowadays.Core.Entities.Issue", "Issue")
                        .WithMany("IssueEmployees")
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Issue");
                });

            modelBuilder.Entity("Nowadays.Core.Entities.Project", b =>
                {
                    b.HasOne("Nowadays.Core.Entities.Company", "Company")
                        .WithMany("Projects")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Nowadays.Core.Entities.Company", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("Nowadays.Core.Entities.Employee", b =>
                {
                    b.Navigation("EmployeeProjects");

                    b.Navigation("IssueEmployees");
                });

            modelBuilder.Entity("Nowadays.Core.Entities.Issue", b =>
                {
                    b.Navigation("IssueEmployees");
                });

            modelBuilder.Entity("Nowadays.Core.Entities.Project", b =>
                {
                    b.Navigation("EmployeeProjects");

                    b.Navigation("Issues");
                });
#pragma warning restore 612, 618
        }
    }
}