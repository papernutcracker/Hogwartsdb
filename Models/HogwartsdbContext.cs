using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hogwards.Models {

    public partial class HogwartsdbContext : DbContext
    {
        public HogwartsdbContext()
        {
        }

        public HogwartsdbContext(DbContextOptions<HogwartsdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditLog> AuditLogs { get; set; }

        public virtual DbSet<HousePoint> HousePoints { get; set; }

        public virtual DbSet<MaraudersMapLog> MaraudersMapLogs { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<Wand> Wands { get; set; }

        public virtual DbSet<Wizard> Wizards { get; set; }

        public virtual DbSet<vw_ActiveWizard> Vw_ActiveWizards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Server=diana\\SQLEXPRESS;Database=HogwardsDB_CodeFirst;Trusted_Connection=True;TrustServerCertificate=True;";

            optionsBuilder.UseSqlServer(connectionString);
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__AuditLog__3214EC077B5BB6DE");

                entity.Property(e => e.DateTrigerred)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.LogMessage).HasMaxLength(256);
            });

            modelBuilder.Entity<HousePoint>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__HousePoi__3214EC07085F3163");

                entity.Property(e => e.DateRecorded)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Subject).WithMany(p => p.HousePoints)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK__HousePoin__Subje__0B91BA14");

                entity.HasOne(d => d.Wizard).WithMany(p => p.HousePoints)
                    .HasForeignKey(d => d.WizardId)
                    .HasConstraintName("FK__HousePoin__Wizar__0A9D95DB");
            });

            modelBuilder.Entity<MaraudersMapLog>(entity =>
            {
                entity.HasKey(e => e.TrackId).HasName("PK__Marauder__7A74F8E0251A6D6E");

                entity.HasIndex(e => e.MovementTime, "IX_MaraudersMapLogs_MovementTime");

                entity.Property(e => e.Location).HasMaxLength(100);
                entity.Property(e => e.MovementTime).HasColumnType("datetime");
                entity.Property(e => e.WizardName).HasMaxLength(100);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Subjects__3214EC070009E3CD");

                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Teacher).HasMaxLength(100);
            });

            modelBuilder.Entity<Wand>(entity =>
            {
                entity.HasKey(e => e.WandId).HasName("PK__WANDS__BB49E3C8E14BFDCE");

                entity.ToTable("WANDS");

                entity.HasIndex(e => e.WizardId, "UQ_Wands_WizardId").IsUnique();

                entity.Property(e => e.CoreMaterial).HasMaxLength(100);
                entity.Property(e => e.Length).HasColumnType("decimal(4, 1)");

                entity.HasOne(d => d.Wizard).WithOne(p => p.Wand)
                    .HasForeignKey<Wand>(d => d.WizardId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wands_Wizards");
            });

            modelBuilder.Entity<Wizard>(entity =>
            {
                entity.HasKey(e => e.WizardId).HasName("PK__Wizards__EB46AA85423A4160");

                entity.HasIndex(e => e.Name, "IX_Wizards_Name");

                entity.Property(e => e.BloodStatus)
                    .HasMaxLength(30)
                    .HasDefaultValue("Unknown", "DF_Wizard_BloodStatus");
                entity.Property(e => e.House).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<vw_ActiveWizard>(entity =>

            {
                entity.HasNoKey();
                entity.ToView("vw_ActiveWizards");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}