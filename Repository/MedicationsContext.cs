using System;
using System.Collections.Generic;
using Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Medication
{
    public partial class MedicationsContext : DbContext
    {
        public MedicationsContext()
        {
        }

        public MedicationsContext(DbContextOptions<MedicationsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CaregiverStatusCode> CaregiverStatusCodes { get; set; } = null!;
        public virtual DbSet<GenderCode> GenderCodes { get; set; } = null!;
        public virtual DbSet<Measurement> Measurements { get; set; } = null!;
        public virtual DbSet<Medicine> Medicines { get; set; } = null!;
        public virtual DbSet<MedicineForUser> MedicineForUsers { get; set; } = null!;
        public virtual DbSet<MedicineStock> MedicineStocks { get; set; } = null!;
        public virtual DbSet<SystemMessage> SystemMessages { get; set; } = null!;
        public virtual DbSet<TakingMedication> TakingMedications { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserAndCaregiver> UserAndCaregivers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
               optionsBuilder.UseSqlServer("Server=srv2\\pupils;Database=Medications;Trusted_Connection=True;");
                ///optionsBuilder.UseSqlServer("Server=DESKTOP-SN2JHFI\\SQLEXPRESS;Database=Medications;Trusted_Connection=True;");


            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaregiverStatusCode>(entity =>
            {
                entity.ToTable("CaregiverStatusCode");

                entity.Property(e => e.StatusDescription).HasMaxLength(50);
            });

            modelBuilder.Entity<GenderCode>(entity =>
            {
                entity.ToTable("GenderCode");

                entity.Property(e => e.GenderDescription).HasMaxLength(9);
            });

            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.Property(e => e.DateOfMeasure).HasColumnType("smalldatetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Measurements)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Measurements_User");
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicine");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<MedicineForUser>(entity =>
            {
                entity.ToTable("MedicineForUser");

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.MedicineForUsers)
                    .HasForeignKey(d => d.MedicineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicineForUser_Medicine");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MedicineForUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicineForUser_User");
            });

            modelBuilder.Entity<MedicineStock>(entity =>
            {
                entity.ToTable("MedicineStock");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.MedicineStocks)
                    .HasForeignKey(d => d.MedicineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicineStock_Medicine");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.MedicineStocks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MedicineStock_User");
            });

            modelBuilder.Entity<SystemMessage>(entity =>
            {
                entity.ToTable("SystemMessage");

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.MessageText).HasMaxLength(200);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SystemMessages)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SystemMessage_User");
            });

            modelBuilder.Entity<TakingMedication>(entity =>
            {
                entity.ToTable("TakingMedication");

                entity.Property(e => e.TimeOfTakingMedicine).HasColumnType("smalldatetime");

                entity.HasOne(d => d.MedicineForUserNavigation)
                    .WithMany(p => p.TakingMedications)
                    .HasForeignKey(d => d.MedicineForUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TakingMedication_MedicineForUser");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IdentityNumber).HasMaxLength(10);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_GenderCode");
            });

            modelBuilder.Entity<UserAndCaregiver>(entity =>
            {
                entity.ToTable("UserAndCaregiver");

                entity.HasOne(d => d.Caregiver)
                    .WithMany(p => p.UserAndCaregiverCaregivers)
                    .HasForeignKey(d => d.CaregiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAndCaregiver_User1");

                entity.HasOne(d => d.StatusOfCaregiver)
                    .WithMany(p => p.UserAndCaregivers)
                    .HasForeignKey(d => d.StatusOfCaregiverId)
                    .HasConstraintName("FK_UserAndCaregiver_CaregiverStatusCode");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAndCaregiverUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserAndCaregiver_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
