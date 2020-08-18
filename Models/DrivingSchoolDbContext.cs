using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DrivingSchool_Api
{
    public partial class DrivingSchoolDbContext : DbContext
    {
        public DrivingSchoolDbContext()
        {
        }

        public DrivingSchoolDbContext(DbContextOptions<DrivingSchoolDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<BookingPackage> BookingPackage { get; set; }
        public virtual DbSet<BookingType> BookingType { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<TimeSlot> TimeSlot { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=(LocalDb)\\LocalDb.;Database=DrivingSchoolDb;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateBooked).HasColumnType("smalldatetime");

                entity.Property(e => e.DateBookingFor).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bkp)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.BkpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_BookingPackage");

                entity.HasOne(d => d.Time)
                    .WithMany(p => p.Booking)
                    .HasForeignKey(d => d.TimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Booking_TimeSlot");
            });

            modelBuilder.Entity<BookingPackage>(entity =>
            {
                entity.HasKey(e => e.BkpId);

                entity.Property(e => e.PackageDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PackagePrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.BookingType)
                    .WithMany(p => p.BookingPackage)
                    .HasForeignKey(d => d.BookingTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookingPackage_BookingType");
            });

            modelBuilder.Entity<BookingType>(entity =>
            {
                entity.Property(e => e.BktName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CellphoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerSurname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.HasKey(e => e.TimeId);

                entity.Property(e => e.TimeSlot1).HasColumnName("Time_Slot");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
