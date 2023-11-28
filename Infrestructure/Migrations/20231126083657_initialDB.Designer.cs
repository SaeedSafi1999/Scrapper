﻿// <auto-generated />
using Infrestructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrestructure.Migrations
{
    [DbContext(typeof(AppDataContext))]
    [Migration("20231126083657_initialDB")]
    partial class initialDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.CitiesLatAndLang", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Lang")
                        .HasColumnType("real");

                    b.Property<float>("Lat")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CitiesLatAndLangs");
                });

            modelBuilder.Entity("Core.Entities.Ejucation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Academy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Beginning")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgrammeDuration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("badgeLabel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idSite")
                        .HasColumnType("int");

                    b.Property<bool>("isCompleteOnlinePossible")
                        .HasColumnType("bit");

                    b.Property<bool>("isElearning")
                        .HasColumnType("bit");

                    b.Property<float>("lang")
                        .HasColumnType("real");

                    b.Property<float>("lat")
                        .HasColumnType("real");

                    b.Property<string>("link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("requestLanguage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("structuredResearch")
                        .HasColumnType("bit");

                    b.Property<string>("subject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("typeCourseDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ejucations");
                });

            modelBuilder.Entity("Core.Entities.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobTitel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Lang")
                        .HasColumnType("real");

                    b.Property<string>("Salary")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkHour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("lat")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}
