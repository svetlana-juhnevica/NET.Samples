using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebEmployeeList.DB
{
    public partial class CUSERSUR777SOURCEREPOSNETMYFIRSTWEBBAPPCATALOGUEDBMDFContext : DbContext
    {
        public CUSERSUR777SOURCEREPOSNETMYFIRSTWEBBAPPCATALOGUEDBMDFContext()
        {
        }

        public CUSERSUR777SOURCEREPOSNETMYFIRSTWEBBAPPCATALOGUEDBMDFContext(DbContextOptions<CUSERSUR777SOURCEREPOSNETMYFIRSTWEBBAPPCATALOGUEDBMDFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Items> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ur777\\source\\repos\\NET\\MyFirstWebbAppCatalogueDb.mdf;Integrated Security=True;Connect Timeout=30");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.Property(e => e.CategoryName).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });
        }
    }
}
