using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PersonApi.Data.Models;

namespace PersonApi.Data.Contexts
{
    public partial class PersonApiContext : DbContext
    {
        public PersonApiContext()
        {
        }

        public PersonApiContext(DbContextOptions<PersonApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Donation> Donation { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonAddress> PersonAddress { get; set; }
        public virtual DbSet<PersonContact> PersonContact { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=PersonApi;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donation>(entity =>
            {
                entity.HasKey(e => e.DonationKey)
                    .HasName("PK__Donation__D04BE9FF2AB75FFE");

                entity.Property(e => e.DonationDate).HasColumnType("datetime");

                entity.HasOne(d => d.PersonKeyNavigation)
                    .WithMany(p => p.Donation)
                    .HasForeignKey(d => d.PersonKey)
                    .HasConstraintName("FK_Donation_PersonKey");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.PersonKey)
                    .HasName("PK__Person__45F58D86AE283418");
            });

            modelBuilder.Entity<PersonAddress>(entity =>
            {
                entity.HasKey(e => e.PersonAddressKey)
                    .HasName("PK__PersonAd__7CE0EF72C5B514B5");

                entity.HasOne(d => d.PersonKeyNavigation)
                    .WithMany(p => p.PersonAddress)
                    .HasForeignKey(d => d.PersonKey)
                    .HasConstraintName("FK_PersonAddress_PersonKey");
            });

            modelBuilder.Entity<PersonContact>(entity =>
            {
                entity.HasKey(e => e.ContactKey)
                    .HasName("PK__PersonCo__8BED7D4D09AFBA3C");

                entity.HasOne(d => d.PersonKeyNavigation)
                    .WithMany(p => p.PersonContact)
                    .HasForeignKey(d => d.PersonKey)
                    .HasConstraintName("FK_PersonContact_PersonKey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
