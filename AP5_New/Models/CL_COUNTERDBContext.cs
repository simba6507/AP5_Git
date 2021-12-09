using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AP5_New.Models
{
    public partial class CL_COUNTERDBContext : DbContext
    {
        public CL_COUNTERDBContext()
        {
        }

        public CL_COUNTERDBContext(DbContextOptions<CL_COUNTERDBContext> options)
            : base(options)
        {
        }

       
        public virtual DbSet<CL_TNumberOfLineOff> TNumberOfLineOffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CL_TNumberOfLineOff>(entity =>
            {
                entity.HasKey(e => new { e.OperationDate, e.Shift });

                entity.ToTable("T_NUMBER_OF_LINE_OFF");

                entity.Property(e => e.OperationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("OPERATION_DATE");

                entity.Property(e => e.Shift)
                    .HasColumnType("numeric(1, 0)")
                    .HasColumnName("SHIFT");

                entity.Property(e => e.LoAdjustment)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("LO_ADJUSTMENT");

                entity.Property(e => e.NumberOfLineOff)
                    .HasColumnType("numeric(4, 0)")
                    .HasColumnName("NUMBER_OF_LINE_OFF");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
