﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;


#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DemoContext))]
    [Migration("20240911225451_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Degree")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<decimal>("MinDegree")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dept_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("dept_id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("WebApplication1.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Manager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("WebApplication1.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<int>("course_id")
                        .HasColumnType("int");

                    b.Property<int>("dept_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("course_id");

                    b.HasIndex("dept_id");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("WebApplication1.Models.Trainee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("dept_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("dept_id");

                    b.ToTable("Trainees");
                });

            modelBuilder.Entity("WebApplication1.Models.crsResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("TraineeDegree")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("crs_id")
                        .HasColumnType("int");

                    b.Property<int>("trainee_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("crs_id");

                    b.HasIndex("trainee_id");

                    b.ToTable("CrsResults");
                });

            modelBuilder.Entity("WebApplication1.Models.Course", b =>
                {
                    b.HasOne("WebApplication1.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("dept_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WebApplication1.Models.Instructor", b =>
                {
                    b.HasOne("WebApplication1.Models.Course", "Course")
                        .WithMany("Instructors")
                        .HasForeignKey("course_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("dept_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WebApplication1.Models.Trainee", b =>
                {
                    b.HasOne("WebApplication1.Models.Department", "Department")
                        .WithMany("Trainees")
                        .HasForeignKey("dept_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("WebApplication1.Models.crsResult", b =>
                {
                    b.HasOne("WebApplication1.Models.Course", "Course")
                        .WithMany("CrsResults")
                        .HasForeignKey("crs_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Trainee", "Trainee")
                        .WithMany("CrsResults")
                        .HasForeignKey("trainee_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("WebApplication1.Models.Course", b =>
                {
                    b.Navigation("CrsResults");

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("WebApplication1.Models.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Instructors");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("WebApplication1.Models.Trainee", b =>
                {
                    b.Navigation("CrsResults");
                });
#pragma warning restore 612, 618
        }
    }
}
