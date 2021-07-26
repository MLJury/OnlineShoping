using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BillingAPI.Models
{
    public partial class BillingContext : DbContext
    {
        public BillingContext()
        {
        }

        public BillingContext(DbContextOptions<BillingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Billing> Billings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=172.26.211.138;Database=Billing;User Id=Mohammadreza;Password=MrMr193782465;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Billing>(entity =>
            {
                entity.ToTable("Billing");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
