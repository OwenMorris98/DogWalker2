﻿// <auto-generated />
using System;
using DogWalker2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DogWalker2.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240807002731_customersUpdate")]
    partial class customersUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DogWalker2.Domain.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passwordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("DogWalker2.Domain.Dog", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("customer_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("customer_id");

                    b.ToTable("Dogs");
                });

            modelBuilder.Entity("DogWalker2.Domain.Users.Role", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DogWalker2.Domain.Users.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Roleid")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Roleid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DogWalker2.Domain.Walks.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.HasKey("LocationID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("DogWalker2.Domain.Walks.Payment", b =>
                {
                    b.Property<int>("PaymentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentID"));

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WalkID")
                        .HasColumnType("int");

                    b.Property<int>("WalkerID")
                        .HasColumnType("int");

                    b.HasKey("PaymentID");

                    b.HasIndex("CustomerId");

                    b.HasIndex("WalkID");

                    b.HasIndex("WalkerID");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("DogWalker2.Domain.Walks.Walk", b =>
                {
                    b.Property<int>("WalkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WalkID"));

                    b.Property<string>("DogId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int?>("LocationID")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ScheduledTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WalkerID")
                        .HasColumnType("int");

                    b.HasKey("WalkID");

                    b.HasIndex("DogId");

                    b.HasIndex("LocationID");

                    b.HasIndex("WalkerID");

                    b.ToTable("Walks");
                });

            modelBuilder.Entity("DogWalker2.Domain.Walks.Walker", b =>
                {
                    b.Property<int>("WalkerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WalkerID"));

                    b.Property<string>("Availability")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExperienceLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("WalkerID");

                    b.ToTable("Walkers");
                });

            modelBuilder.Entity("DogWalker2.Domain.Dog", b =>
                {
                    b.HasOne("DogWalker2.Domain.Customer", "Customer")
                        .WithMany("Dogs")
                        .HasForeignKey("customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("DogWalker2.Domain.Users.User", b =>
                {
                    b.HasOne("DogWalker2.Domain.Users.Role", "Role")
                        .WithMany()
                        .HasForeignKey("Roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DogWalker2.Domain.Walks.Payment", b =>
                {
                    b.HasOne("DogWalker2.Domain.Customer", "Customer")
                        .WithMany("Payments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogWalker2.Domain.Walks.Walk", "Walk")
                        .WithMany("WalkPayments")
                        .HasForeignKey("WalkID");

                    b.HasOne("DogWalker2.Domain.Walks.Walker", "Walker")
                        .WithMany("Payments")
                        .HasForeignKey("WalkerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Walk");

                    b.Navigation("Walker");
                });

            modelBuilder.Entity("DogWalker2.Domain.Walks.Walk", b =>
                {
                    b.HasOne("DogWalker2.Domain.Dog", "Dog")
                        .WithMany("Walks")
                        .HasForeignKey("DogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DogWalker2.Domain.Walks.Location", "Location")
                        .WithMany("Walks")
                        .HasForeignKey("LocationID");

                    b.HasOne("DogWalker2.Domain.Walks.Walker", "Walker")
                        .WithMany("Walks")
                        .HasForeignKey("WalkerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dog");

                    b.Navigation("Location");

                    b.Navigation("Walker");
                });

            modelBuilder.Entity("DogWalker2.Domain.Customer", b =>
                {
                    b.Navigation("Dogs");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("DogWalker2.Domain.Dog", b =>
                {
                    b.Navigation("Walks");
                });

            modelBuilder.Entity("DogWalker2.Domain.Walks.Location", b =>
                {
                    b.Navigation("Walks");
                });

            modelBuilder.Entity("DogWalker2.Domain.Walks.Walk", b =>
                {
                    b.Navigation("WalkPayments");
                });

            modelBuilder.Entity("DogWalker2.Domain.Walks.Walker", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Walks");
                });
#pragma warning restore 612, 618
        }
    }
}
