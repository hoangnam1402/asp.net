﻿// <auto-generated />
using System;
using BackEnd.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220310082128_add-day-for-product")]
    partial class adddayforproduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BackEnd.Model.Category", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Content")
                        .HasColumnType("ntext");

                    b.HasKey("CategoryId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("BackEnd.Model.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SignDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("BackEnd.Model.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDay")
                        .HasColumnType("datetime2");

                    b.Property<int>("cost")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("ntext");

                    b.Property<string>("img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("inventory")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("rating")
                        .HasColumnType("int");

                    b.Property<bool>("stopped")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("CustomerProduct", b =>
                {
                    b.Property<Guid>("CustomersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CustomersId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CustomerProduct");
                });

            modelBuilder.Entity("BackEnd.Model.Product", b =>
                {
                    b.HasOne("BackEnd.Model.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CustomerProduct", b =>
                {
                    b.HasOne("BackEnd.Model.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Model.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
