using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace QuanLyKhoHang.Models
{
    public partial class QuanLyKhoContext : DbContext
    {
        public QuanLyKhoContext()
        {
        }

        public QuanLyKhoContext(DbContextOptions<QuanLyKhoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DanhMuc> DanhMuc { get; set; }
        public virtual DbSet<HangSanXuat> HangSanXuat { get; set; }
        public virtual DbSet<KhoTonHang> KhoTonHang { get; set; }
        public virtual DbSet<NhaPhanPhoi> NhaPhanPhoi { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-QP1F3UD\\SQLEXPRESS;Database=QuanLyKho;user id=sa;password=123456789;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasKey(e => e.MaDm)
                    .HasName("PK__DanhMuc__2725866E3FF1A5B6");

                entity.Property(e => e.MaDm)
                    .HasColumnName("MaDM")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.TenDm)
                    .HasColumnName("TenDM")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<HangSanXuat>(entity =>
            {
                entity.HasKey(e => e.MaNxx)
                    .HasName("PK__HangSanX__3A194832AA9C99BC");

                entity.Property(e => e.MaNxx)
                    .HasColumnName("MaNXX")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GhiChu).HasMaxLength(50);

                entity.Property(e => e.TenNxx)
                    .HasColumnName("TenNXX")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<KhoTonHang>(entity =>
            {
                entity.HasKey(e => e.MaKho)
                    .HasName("PK__KhoTonHa__3BDA9350AACF602A");

                entity.Property(e => e.MaKho)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.GhiChup).HasMaxLength(50);

                entity.Property(e => e.TenKho).HasMaxLength(50);
            });

            modelBuilder.Entity<NhaPhanPhoi>(entity =>
            {
                entity.HasKey(e => e.MaNpp)
                    .HasName("PK__NhaPhanP__3A18330CF30BDFB9");

                entity.Property(e => e.MaNpp)
                    .HasColumnName("MaNPP")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Qg)
                    .HasColumnName("QG")
                    .HasMaxLength(50);

                entity.Property(e => e.TenNpp)
                    .HasColumnName("TenNPP")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SanPham__2725081C8060E958");

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Iddm)
                    .HasColumnName("IDDM")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Idhxx)
                    .HasColumnName("IDHXX")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Idkho)
                    .HasColumnName("IDkho")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Idnpp)
                    .HasColumnName("IDNPP")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.NgayNhap)
                    .HasColumnName("NgayNHap")
                    .HasColumnType("date");

                entity.Property(e => e.Slton)
                    .HasColumnName("SLton")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TenSp)
                    .HasColumnName("TenSP")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IddmNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.Iddm)
                    .HasConstraintName("fk_NPP2");

                entity.HasOne(d => d.IdhxxNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.Idhxx)
                    .HasConstraintName("fk_NPP3");

                entity.HasOne(d => d.IdkhoNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.Idkho)
                    .HasConstraintName("fk_NPP");

                entity.HasOne(d => d.IdnppNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.Idnpp)
                    .HasConstraintName("fk_NPP1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
