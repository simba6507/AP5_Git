using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AP5_New.Models
{
    public partial class AP5_NewContext : DbContext
    {
        public AP5_NewContext()
        {
        }

        public AP5_NewContext(DbContextOptions<AP5_NewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContainerMaster> ContainerMasters { get; set; }
        public virtual DbSet<ModMaster> ModMasters { get; set; }
        public virtual DbSet<PlanLineoff> PlanLineoffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=192.168.15.84;Database=AP5_New;User ID=unboxingUser;Password=unboxingUser;Trusted_Connection=True;Integrated Security=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_Taiwan_Stroke_CI_AS");

            modelBuilder.Entity<ContainerMaster>(entity =>
            {
                entity.HasKey(e => new { e.Country, e.ContainerRenban, e.ContainerNo })
                    .HasName("PK_CONTAINER_MASTER_1");

                entity.ToTable("CONTAINER_MASTER");

                entity.Property(e => e.Country)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.ContainerRenban)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONTAINER_RENBAN");

                entity.Property(e => e.ContainerNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONTAINER_NO");

                entity.Property(e => e.ContainerStatus)
                    .HasMaxLength(10)
                    .HasColumnName("CONTAINER_STATUS");

                entity.Property(e => e.DockNo).HasColumnName("DOCK_NO");

                entity.Property(e => e.DoneFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DONE_FLAG");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("END_TIME");

                entity.Property(e => e.LineoffCount).HasColumnName("LINEOFF_COUNT");

                entity.Property(e => e.LogicalTime).HasColumnName("LOGICAL_TIME");

                entity.Property(e => e.Mark)
                    .HasMaxLength(50)
                    .HasColumnName("MARK");

                entity.Property(e => e.PlantCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PLANT_CODE");

                entity.Property(e => e.ProcessTime).HasColumnName("PROCESS_TIME");

                entity.Property(e => e.ShiftType).HasColumnName("SHIFT_TYPE");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("START_TIME");

                entity.Property(e => e.UnboxDate)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("UNBOX_DATE");
            });

            modelBuilder.Entity<ModMaster>(entity =>
            {
                entity.HasKey(e => new { e.CarType, e.Country, e.ModNo })
                    .HasName("PK_MOD_MASTER_1");

                entity.ToTable("MOD_MASTER");

                entity.Property(e => e.CarType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CAR_TYPE");

                entity.Property(e => e.Country)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.ModNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MOD_NO");

                entity.Property(e => e.DoneFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DONE_FLAG");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("END_TIME");

                entity.Property(e => e.LineoffCount).HasColumnName("LINEOFF_COUNT");

                entity.Property(e => e.LogicalTime).HasColumnName("LOGICAL_TIME");

                entity.Property(e => e.Mark)
                    .HasMaxLength(50)
                    .HasColumnName("MARK");

                entity.Property(e => e.ModStatus)
                    .HasMaxLength(10)
                    .HasColumnName("MOD_STATUS");

                entity.Property(e => e.PlantCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PLANT_CODE");

                entity.Property(e => e.ProcessTime).HasColumnName("PROCESS_TIME");

                entity.Property(e => e.ShiftType).HasColumnName("SHIFT_TYPE");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("START_TIME");

                entity.Property(e => e.UnboxArea).HasColumnName("UNBOX_AREA");

                entity.Property(e => e.UnboxDate)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("UNBOX_DATE");
            });

            modelBuilder.Entity<PlanLineoff>(entity =>
            {
                entity.HasKey(e => new { e.PlantCode, e.ShiftType })
                    .HasName("PK_PLAN_LINEOFF_1");

                entity.ToTable("PLAN_LINEOFF");

                entity.Property(e => e.EndDt)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("END_DT");

                entity.Property(e => e.Lineoff).HasColumnName("LINEOFF");

                entity.Property(e => e.PlantCode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PLANT_CODE");

                entity.Property(e => e.ShiftType).HasColumnName("SHIFT_TYPE");

                entity.Property(e => e.StartDt)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("START_DT");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
