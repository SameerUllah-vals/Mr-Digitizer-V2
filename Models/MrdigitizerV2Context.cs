using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MrDigitizerV2.Models
{
    public partial class MrdigitizerV2Context : DbContext
    {
        public MrdigitizerV2Context()
        {
        }

        public MrdigitizerV2Context(DbContextOptions<MrdigitizerV2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<BackendMenuDetails> BackendMenuDetails { get; set; }
        public virtual DbSet<BackendMenus> BackendMenus { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Formats> Formats { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<RoleBackendMenus> RoleBackendMenus { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(Startup.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Areas>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccessUrl)
                    .HasColumnName("AccessURL")
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.DeletedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LatitudeLongitude)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.UtccreatedDateTime)
                    .HasColumnName("UTCCreatedDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UtcdeletedDateTime)
                    .HasColumnName("UTCDeletedDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UtcupdatedDateTime)
                    .HasColumnName("UTCUpdatedDateTime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Areas_Cities");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Areas_Countries");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Areas_States");
            });

            modelBuilder.Entity<BackendMenuDetails>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.HasOne(d => d.BackendMenu)
                    .WithMany(p => p.BackendMenuDetails)
                    .HasForeignKey(d => d.BackendMenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BackendMenuDetails_BackendMenus");
            });

            modelBuilder.Entity<BackendMenus>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccessUrl)
                    .IsRequired()
                    .HasColumnName("AccessURL")
                    .HasMaxLength(100);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.IconClass)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_BackendMenus_BackendMenus");
            });

            modelBuilder.Entity<Cities>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccessUrl)
                    .HasColumnName("AccessURL")
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.DeletedDateTime).HasColumnType("datetime");

                entity.Property(e => e.LatitudeLongitude)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.UtccreatedDateTime)
                    .HasColumnName("UTCCreatedDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UtcdeletedDateTime)
                    .HasColumnName("UTCDeletedDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UtcupdatedDateTime)
                    .HasColumnName("UTCUpdatedDateTime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_Countries");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_States");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccessUrl)
                    .IsRequired()
                    .HasColumnName("AccessURL")
                    .HasMaxLength(255);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CodePhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.DeletedDateTime).HasColumnType("datetime");

                entity.Property(e => e.IconImage).HasMaxLength(500);

                entity.Property(e => e.Image).HasMaxLength(500);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.UtccreatedDateTime)
                    .HasColumnName("UTCCreatedDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UtcdeletedDateTime)
                    .HasColumnName("UTCDeletedDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UtcupdatedDateTime)
                    .HasColumnName("UTCUpdatedDateTime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Formats>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.UtccreatedDateTime)
                    .HasColumnName("UTCCreatedDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UtcupdatedDateTime)
                    .HasColumnName("UTCUpdatedDateTime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ColorType).HasMaxLength(255);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DesignName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Fabric).HasMaxLength(255);

                entity.Property(e => e.FilePath).HasMaxLength(500);

                entity.Property(e => e.Format)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.NoOfColors)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.OrderType)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Placement).HasMaxLength(255);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Orders__UserId__45F365D3");
            });

            modelBuilder.Entity<RoleBackendMenus>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Permission)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.RoleBackendMenus)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleBackendMenus_BackendMenus");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleBackendMenus)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleBackendMenus_Roles");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.DeletedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Type).HasMaxLength(20);

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.UtccreatedDateTime)
                    .HasColumnName("UTCCreatedDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UtcdeletedDateTime)
                    .HasColumnName("UTCDeletedDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UtcupdatedDateTime)
                    .HasColumnName("UTCUpdatedDateTime")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Settings>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccessUrl)
                    .IsRequired()
                    .HasColumnName("AccessURL")
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.DeletedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.UtccreatedDateTime)
                    .HasColumnName("UTCCreatedDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UtcdeletedDateTime)
                    .HasColumnName("UTCDeletedDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UtcupdatedDateTime)
                    .HasColumnName("UTCUpdatedDateTime")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_States_Countries");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccountType).HasMaxLength(20);

                entity.Property(e => e.ConnectionId).HasColumnType("text");

                entity.Property(e => e.CreatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.DeletedDateTime).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Fullname).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.PasswordRecoveryCode).HasMaxLength(50);

                entity.Property(e => e.PasswordRecoveryExpireDateTime).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.ProfileImagePath).HasMaxLength(100);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UpdatedDateTime).HasColumnType("datetime");

                entity.Property(e => e.UtccreatedDateTime)
                    .HasColumnName("UTCCreatedDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UtcdeletedDateTime)
                    .HasColumnName("UTCDeletedDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.UtcupdatedDateTime)
                    .HasColumnName("UTCUpdatedDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.VerificationDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
