using System;
using System.Collections.Generic;
using control_inventario.Models;
using Microsoft.EntityFrameworkCore;

namespace control_inventario.Data;

public partial class InventarioDbContext : DbContext
{
    public InventarioDbContext()
    {
    }

    public InventarioDbContext(DbContextOptions<InventarioDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProductModel> Products { get; set; }

    public virtual DbSet<RolModel> Roles { get; set; }

    public virtual DbSet<SaleModel> Sales { get; set; }

    public virtual DbSet<SaleItemModel> SalesItems { get; set; }

    public virtual DbSet<StatusModel> Statuses { get; set; }

    public virtual DbSet<UserModel> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:InventarioDb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CostPrice).HasColumnType("decimal(2, 0)");
            entity.Property(e => e.Description)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.SalePrice).HasColumnType("decimal(2, 0)");
        });

        modelBuilder.Entity<RolModel>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Roles)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Roles_Status");
        });

        modelBuilder.Entity<SaleModel>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.SoleAt)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.TotalSale).HasColumnType("decimal(2, 0)");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sales_Users");
        });

        modelBuilder.Entity<SaleItemModel>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.SalePrice).HasColumnType("decimal(2, 0)");
            entity.Property(e => e.Total).HasColumnType("decimal(2, 0)");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.SalesItems)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesItems_Products");

            entity.HasOne(d => d.IdSaleNavigation).WithMany(p => p.SalesItems)
                .HasForeignKey(d => d.IdSale)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SalesItems_Sales");
        });

        modelBuilder.Entity<StatusModel>(entity =>
        {
            entity.ToTable("Status");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
