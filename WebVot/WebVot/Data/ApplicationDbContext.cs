using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebVot.Models;

namespace WebVot.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DonHang> DonHangs { get; set; } = null!;
        public virtual DbSet<Ncc> Nccs { get; set; } = null!;
        public virtual DbSet<Nsx> Nsxes { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MRPI\\SQLEXPRESS;Database=WebVot;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.MaDh)
                    .HasName("PK__DonHang__2725866194F3421C");

                entity.Property(e => e.MaDh).IsFixedLength();

                entity.Property(e => e.MaSp).IsFixedLength();

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_donhang_sanpham");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_donhang_taikhoan");
            });

            modelBuilder.Entity<Ncc>(entity =>
            {
                entity.HasKey(e => e.MaNcc)
                    .HasName("PK__NCC__3A185DEB4FBFA0A0");

                entity.Property(e => e.MaNcc).IsFixedLength();
            });

            modelBuilder.Entity<Nsx>(entity =>
            {
                entity.HasKey(e => e.MaNsx)
                    .HasName("PK__NSX__3A1BDBD291331705");

                entity.Property(e => e.MaNsx).IsFixedLength();
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("pk_SanPham_MaSp");

                entity.Property(e => e.MaSp).IsFixedLength();

                entity.Property(e => e.MaNcc).IsFixedLength();

                entity.Property(e => e.MaNsx).IsFixedLength();

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaNcc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sanpham_ncc");

                entity.HasOne(d => d.MaNsxNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaNsx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sanpham_nsx");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("pk_TaiKhoan_username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
