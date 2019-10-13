using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StoreApp.DataLibrary.Entities
{
    public partial class StoreApplicationContext : DbContext
    {
        public StoreApplicationContext()
        {
        }

        public StoreApplicationContext(DbContextOptions<StoreApplicationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<InventoryProduct> InventoryProduct { get; set; }
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<OrderProduct> OrderProduct { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Store> Store { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "app");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            modelBuilder.Entity<InventoryProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("InventoryProduct", "app");

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.InventoryProduct)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Produ__49E3F248");

                entity.HasOne(d => d.StoreNumberNavigation)
                    .WithMany(p => p.InventoryProduct)
                    .HasForeignKey(d => d.StoreNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Store__48EFCE0F");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager", "app");

                entity.HasIndex(e => e.StoreNumber)
                    .HasName("UQ__Manager__EFFC8D565EF0D323")
                    .IsUnique();

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.HasOne(d => d.StoreNumberNavigation)
                    .WithOne(p => p.Manager)
                    .HasForeignKey<Manager>(d => d.StoreNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Manager__StoreNu__546180BB");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("OrderProduct", "app");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProduct)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderProd__Order__4EA8A765");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.OrderProduct)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderProd__Produ__4F9CCB9E");

                entity.HasOne(d => d.StoreNumberNavigation)
                    .WithMany(p => p.OrderProduct)
                    .HasForeignKey(d => d.StoreNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderProd__Store__5090EFD7");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BAF381F409A");

                entity.ToTable("Orders", "app");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__Customer__4CC05EF3");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductTypeId)
                    .HasName("PK__Product__A1312F4E2926D34F");

                entity.ToTable("Product", "app");

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StoreNumber)
                    .HasName("PK__Store__EFFC8D574B4A06EC");

                entity.ToTable("Store", "app");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
