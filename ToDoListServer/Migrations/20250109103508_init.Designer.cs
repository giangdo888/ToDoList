﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoListServer.Data;

#nullable disable

namespace ToDoListServer.Migrations
{
    [DbContext(typeof(ToDoListDbContext))]
    [Migration("20250109103508_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ToDoListServer.Models.Priority", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Priorities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Low"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Medium"
                        },
                        new
                        {
                            Id = 3,
                            Name = "High"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Critical"
                        });
                });

            modelBuilder.Entity("ToDoListServer.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2025, 1, 9, 9, 21, 54, 443, DateTimeKind.Utc),
                            Name = "Work"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2025, 1, 9, 9, 21, 54, 443, DateTimeKind.Utc),
                            Name = "Personal"
                        });
                });

            modelBuilder.Entity("ToDoListServer.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("States");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Backlog"
                        },
                        new
                        {
                            Id = 2,
                            Name = "InProgress"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Testing"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Done"
                        });
                });

            modelBuilder.Entity("ToDoListServer.Models.ToDoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PriorityId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PriorityId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StateId");

                    b.ToTable("ToDoItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsCompleted = false,
                            Name = "Complete project report",
                            PriorityId = 3,
                            ProjectId = 1,
                            StateId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsCompleted = false,
                            Name = "Buy groceries",
                            PriorityId = 2,
                            ProjectId = 2,
                            StateId = 1
                        });
                });

            modelBuilder.Entity("ToDoListServer.Models.State", b =>
                {
                    b.HasOne("ToDoListServer.Models.Project", null)
                        .WithMany("States")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("ToDoListServer.Models.ToDoItem", b =>
                {
                    b.HasOne("ToDoListServer.Models.Priority", "Priority")
                        .WithMany("ToDoItems")
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoListServer.Models.Project", "Project")
                        .WithMany("ToDoItems")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ToDoListServer.Models.State", "State")
                        .WithMany("ToDoItems")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Priority");

                    b.Navigation("Project");

                    b.Navigation("State");
                });

            modelBuilder.Entity("ToDoListServer.Models.Priority", b =>
                {
                    b.Navigation("ToDoItems");
                });

            modelBuilder.Entity("ToDoListServer.Models.Project", b =>
                {
                    b.Navigation("States");

                    b.Navigation("ToDoItems");
                });

            modelBuilder.Entity("ToDoListServer.Models.State", b =>
                {
                    b.Navigation("ToDoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
