﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using control_inventario.Data;

#nullable disable

namespace control_inventario.Migrations
{
    [DbContext(typeof(InventarioDbContext))]
    [Migration("20230402215640_InitialCreated")]
    partial class InitialCreated
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("control_inventario.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<decimal>("CostPrice")
                        .HasColumnType("decimal(2, 0)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("QuantityStock")
                        .HasColumnType("int");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(2, 0)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("control_inventario.Models.RolModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<int>("IdStatus")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdStatus");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("control_inventario.Models.SaleItemModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int>("IdSale")
                        .HasColumnType("int");

                    b.Property<int>("QuantitySold")
                        .HasColumnType("int");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(2, 0)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(2, 0)");

                    b.HasKey("Id");

                    b.HasIndex("IdProduct");

                    b.HasIndex("IdSale");

                    b.ToTable("SalesItems");
                });

            modelBuilder.Entity("control_inventario.Models.SaleModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<byte[]>("SoleAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<decimal>("TotalSale")
                        .HasColumnType("decimal(2, 0)");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("control_inventario.Models.StatusModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Status", (string)null);
                });

            modelBuilder.Entity("control_inventario.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<byte[]>("CreatedAt")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<int>("IdStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastLogin")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdRol");

                    b.HasIndex("IdStatus");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("control_inventario.Models.RolModel", b =>
                {
                    b.HasOne("control_inventario.Models.StatusModel", "IdStatusNavigation")
                        .WithMany("Roles")
                        .HasForeignKey("IdStatus")
                        .IsRequired()
                        .HasConstraintName("FK_Roles_Status");

                    b.Navigation("IdStatusNavigation");
                });

            modelBuilder.Entity("control_inventario.Models.SaleItemModel", b =>
                {
                    b.HasOne("control_inventario.Models.ProductModel", "IdProductNavigation")
                        .WithMany("SalesItems")
                        .HasForeignKey("IdProduct")
                        .IsRequired()
                        .HasConstraintName("FK_SalesItems_Products");

                    b.HasOne("control_inventario.Models.SaleModel", "IdSaleNavigation")
                        .WithMany("SalesItems")
                        .HasForeignKey("IdSale")
                        .IsRequired()
                        .HasConstraintName("FK_SalesItems_Sales");

                    b.Navigation("IdProductNavigation");

                    b.Navigation("IdSaleNavigation");
                });

            modelBuilder.Entity("control_inventario.Models.SaleModel", b =>
                {
                    b.HasOne("control_inventario.Models.UserModel", "IdUserNavigation")
                        .WithMany("Sales")
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("FK_Sales_Users");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("control_inventario.Models.UserModel", b =>
                {
                    b.HasOne("control_inventario.Models.RolModel", "IdRolNavigation")
                        .WithMany("Users")
                        .HasForeignKey("IdRol")
                        .IsRequired()
                        .HasConstraintName("FK_Users_Roles");

                    b.HasOne("control_inventario.Models.StatusModel", "IdStatusNavigation")
                        .WithMany("Users")
                        .HasForeignKey("IdStatus")
                        .IsRequired()
                        .HasConstraintName("FK_Users_Status");

                    b.Navigation("IdRolNavigation");

                    b.Navigation("IdStatusNavigation");
                });

            modelBuilder.Entity("control_inventario.Models.ProductModel", b =>
                {
                    b.Navigation("SalesItems");
                });

            modelBuilder.Entity("control_inventario.Models.RolModel", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("control_inventario.Models.SaleModel", b =>
                {
                    b.Navigation("SalesItems");
                });

            modelBuilder.Entity("control_inventario.Models.StatusModel", b =>
                {
                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("control_inventario.Models.UserModel", b =>
                {
                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
