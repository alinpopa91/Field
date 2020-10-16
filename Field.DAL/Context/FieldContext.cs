using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Field.DAL.Context
{
    public partial class FieldContext : DbContext
    {
        public FieldContext()
        {
        }

        public FieldContext(DbContextOptions<FieldContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ErrorMapping> ErrorMapping { get; set; }
        public virtual DbSet<PaymentList> PaymentList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //this can be deleted
                optionsBuilder.UseSqlServer("Server=127.0.0.1;Database=Field;User Id=sa;Password=brightSide01;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ErrorMapping>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(500);
            });

            modelBuilder.Entity<PaymentList>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.CardHolder).HasMaxLength(500);

                entity.Property(e => e.CreditCardNumber)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.ExpirationDate).HasColumnType("date");

                entity.Property(e => e.PaymentAgent).HasMaxLength(50);

                entity.Property(e => e.SecurityCode).HasMaxLength(3);
            });
        }
    }
}
