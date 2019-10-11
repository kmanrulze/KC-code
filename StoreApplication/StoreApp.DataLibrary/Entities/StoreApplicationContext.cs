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
        public virtual DbSet<Manager> Manager { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Store> Store { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer", "app");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.City).HasMaxLength(25);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(25);

                entity.Property(e => e.State).HasMaxLength(25);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.Zip).HasMaxLength(5);
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager", "app");

                entity.HasIndex(e => e.StoreNumber)
                    .HasName("UQ__Manager__EFFC8D5608A117EC")
                    .IsUnique();

                entity.Property(e => e.ManagerId).HasColumnName("ManagerID");

                entity.Property(e => e.FirstName).HasMaxLength(25);

                entity.Property(e => e.LastName).HasMaxLength(25);

                entity.HasOne(d => d.StoreNumberNavigation)
                    .WithOne(p => p.Manager)
                    .HasForeignKey<Manager>(d => d.StoreNumber)
                    .HasConstraintName("FK__Manager__StoreNu__00AA174D");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__Orders__C3905BAFB61FACA4");

                entity.ToTable("Orders", "app");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Orders__Customer__7BE56230");

                entity.HasOne(d => d.StoreNumberNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StoreNumber)
                    .HasConstraintName("FK__Orders__StoreNum__7CD98669");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StoreNumber)
                    .HasName("PK__Store__EFFC8D57D9A71AFC");

                entity.ToTable("Store", "app");

                entity.Property(e => e.City).HasMaxLength(25);

                entity.Property(e => e.State).HasMaxLength(25);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.Zip).HasMaxLength(5);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
