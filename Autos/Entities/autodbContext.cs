using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Auto.Entities
{
    public partial class autodbContext : DbContext
    {
        public autodbContext()
        {
        }

        public autodbContext(DbContextOptions<autodbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buyer> Buyers { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Commission> Commissions { get; set; } = null!;
        public virtual DbSet<CommissionType> CommissionTypes { get; set; } = null!;
        public virtual DbSet<Deal> Deals { get; set; } = null!;
        public virtual DbSet<Gallery> Gallery { get; set; } = null!;
        public virtual DbSet<Refub> Refubs { get; set; } = null!;
        public virtual DbSet<Seller> Sellers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.ToTable("Buyer");

                entity.Property(e => e.BuyerId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.ContactNumber).HasMaxLength(100);

                entity.Property(e => e.IdNumber).HasMaxLength(50);

                entity.Property(e => e.IdType).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Buyers)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__Buyer__CarId__44FF419A");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.CarId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Alloys).HasDefaultValueSql("((0))");

                entity.Property(e => e.Colour).HasMaxLength(20);

                entity.Property(e => e.FuelType).HasMaxLength(30);

                entity.Property(e => e.InsuranceExpiry).HasColumnType("datetime");

                entity.Property(e => e.InsuranceType).HasMaxLength(50);

                entity.Property(e => e.Manufacturer).HasMaxLength(50);

                entity.Property(e => e.Model).HasMaxLength(100);

                entity.Property(e => e.RegistrationNo).HasMaxLength(15);

                entity.Property(e => e.Sunroof).HasDefaultValueSql("((0))");

                entity.Property(e => e.Transmission).HasMaxLength(10);

                entity.Property(e => e.Varient).HasMaxLength(200);

                entity.Property(e => e.CoatPrice).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Commission>(entity =>
            {
                entity.ToTable("Commission");

                entity.Property(e => e.CommissionId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Agent).HasMaxLength(100);

                entity.Property(e => e.Commission1)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Commission");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Commissions)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__Commissio__CarId__4AB81AF0");

                entity.HasOne(d => d.CommissionType)
                    .WithMany(p => p.Commissions)
                    .HasForeignKey(d => d.CommissionTypeId)
                    .HasConstraintName("FK__Commissio__Commi__4BAC3F29");
            });

            modelBuilder.Entity<CommissionType>(entity =>
            {
                entity.ToTable("CommissionType");

                entity.Property(e => e.CommissionTypeId).ValueGeneratedNever();

                entity.Property(e => e.CommissionTypeName).HasMaxLength(5);
            });

            modelBuilder.Entity<Deal>(entity =>
            {
                entity.ToTable("Deal");

                entity.Property(e => e.DealId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BuyCost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.BuyDate).HasColumnType("datetime");

                entity.Property(e => e.DealComplete).HasDefaultValueSql("((0))");

                entity.Property(e => e.SellCost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SellDate).HasColumnType("datetime");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Deals)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__Deal__CarId__5070F446");
            });

            modelBuilder.Entity<Gallery>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("Gallery");
                entity.Property(e => e.GalleryId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.ImageType).HasMaxLength(10);

                entity.HasOne(d => d.Car)
                    .WithMany()
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__Gallery__CarId__3F466844");
            });

            modelBuilder.Entity<Refub>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Refub");

                entity.Property(e => e.Cost).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RefubType).HasMaxLength(10);

                entity.HasOne(d => d.Car)
                    .WithMany()
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__Refub__CarId__412EB0B6");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.ToTable("Seller");

                entity.Property(e => e.SellerId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.ContactNumber).HasMaxLength(100);

                entity.Property(e => e.IdNumber).HasMaxLength(50);

                entity.Property(e => e.IdType).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Sellers)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__Seller__CarId__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
