using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace be_demo_qlnh.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ban> Bans { get; set; }

    public virtual DbSet<Cthd> Cthds { get; set; }

    public virtual DbSet<Ctnk> Ctnks { get; set; }

    public virtual DbSet<Ctxk> Ctxks { get; set; }

    public virtual DbSet<Hoadon> Hoadons { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Kho> Khos { get; set; }

    public virtual DbSet<Monan> Monans { get; set; }

    public virtual DbSet<Nguoidung> Nguoidungs { get; set; }

    public virtual DbSet<Nguyenlieu> Nguyenlieus { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    public virtual DbSet<Phieunk> Phieunks { get; set; }

    public virtual DbSet<Phieuxk> Phieuxks { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("User Id=BTL_Oracle;Password=abc123;Data Source=localhost:1521/orclpdb1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("BTL_ORACLE")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Ban>(entity =>
        {
            entity.HasKey(e => e.IdBan).HasName("SYS_C007809");

            entity.ToTable("BAN");

            entity.Property(e => e.IdBan)
                .HasPrecision(8)
                .ValueGeneratedNever()
                .HasColumnName("ID_BAN");
            entity.Property(e => e.Tenban)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TENBAN");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TRANGTHAI");
            entity.Property(e => e.Vitri)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("VITRI");
        });

        modelBuilder.Entity<Cthd>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CTHD");

            entity.Property(e => e.IdHoadon)
                .HasPrecision(8)
                .HasColumnName("ID_HOADON");
            entity.Property(e => e.IdMonan)
                .HasPrecision(8)
                .HasColumnName("ID_MONAN");
            entity.Property(e => e.Soluong)
                .HasPrecision(3)
                .HasColumnName("SOLUONG");
            entity.Property(e => e.Thanhtien)
                .HasPrecision(10)
                .HasColumnName("THANHTIEN");

            entity.HasOne(d => d.IdHoadonNavigation).WithMany()
                .HasForeignKey(d => d.IdHoadon)
                .HasConstraintName("SYS_C007822");

            entity.HasOne(d => d.IdMonanNavigation).WithMany()
                .HasForeignKey(d => d.IdMonan)
                .HasConstraintName("SYS_C007823");
        });

        modelBuilder.Entity<Ctnk>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CTNK");

            entity.Property(e => e.IdNk)
                .HasPrecision(8)
                .HasColumnName("ID_NK");
            entity.Property(e => e.IdNl)
                .HasPrecision(8)
                .HasColumnName("ID_NL");
            entity.Property(e => e.Soluong)
                .HasPrecision(3)
                .HasColumnName("SOLUONG");
            entity.Property(e => e.Thanhtien)
                .HasPrecision(10)
                .HasColumnName("THANHTIEN");

            entity.HasOne(d => d.IdNkNavigation).WithMany()
                .HasForeignKey(d => d.IdNk)
                .HasConstraintName("SYS_C007826");

            entity.HasOne(d => d.IdNlNavigation).WithMany()
                .HasForeignKey(d => d.IdNl)
                .HasConstraintName("SYS_C007827");
        });

        modelBuilder.Entity<Ctxk>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("CTXK");

            entity.Property(e => e.IdNl)
                .HasPrecision(8)
                .HasColumnName("ID_NL");
            entity.Property(e => e.IdXk)
                .HasPrecision(8)
                .HasColumnName("ID_XK");
            entity.Property(e => e.Soluong)
                .HasPrecision(3)
                .HasColumnName("SOLUONG");

            entity.HasOne(d => d.IdNlNavigation).WithMany()
                .HasForeignKey(d => d.IdNl)
                .HasConstraintName("SYS_C007830");

            entity.HasOne(d => d.IdXkNavigation).WithMany()
                .HasForeignKey(d => d.IdXk)
                .HasConstraintName("SYS_C007829");
        });

        modelBuilder.Entity<Hoadon>(entity =>
        {
            entity.HasKey(e => e.IdHoadon).HasName("SYS_C007811");

            entity.ToTable("HOADON");

            entity.Property(e => e.IdHoadon)
                .HasPrecision(8)
                .ValueGeneratedNever()
                .HasColumnName("ID_HOADON");
            entity.Property(e => e.CodeVoucher)
                .HasMaxLength(210)
                .IsUnicode(false)
                .HasColumnName("CODE_VOUCHER");
            entity.Property(e => e.IdBan)
                .HasPrecision(8)
                .HasColumnName("ID_BAN");
            entity.Property(e => e.IdKh)
                .HasPrecision(8)
                .HasColumnName("ID_KH");
            entity.Property(e => e.Ngayhd)
                .HasColumnType("DATE")
                .HasColumnName("NGAYHD");
            entity.Property(e => e.Tiengiam)
                .HasPrecision(8)
                .HasColumnName("TIENGIAM");
            entity.Property(e => e.Tienmonan)
                .HasPrecision(8)
                .HasColumnName("TIENMONAN");
            entity.Property(e => e.Tongtien)
                .HasPrecision(10)
                .HasColumnName("TONGTIEN");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.CodeVoucherNavigation).WithMany(p => p.Hoadons)
                .HasForeignKey(d => d.CodeVoucher)
                .HasConstraintName("SYS_C007821");

            entity.HasOne(d => d.IdBanNavigation).WithMany(p => p.Hoadons)
                .HasForeignKey(d => d.IdBan)
                .HasConstraintName("SYS_C007820");

            entity.HasOne(d => d.IdKhNavigation).WithMany(p => p.Hoadons)
                .HasForeignKey(d => d.IdKh)
                .HasConstraintName("SYS_C007819");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.IdKh).HasName("SYS_C007807");

            entity.ToTable("KHACHHANG");

            entity.Property(e => e.IdKh)
                .HasPrecision(8)
                .ValueGeneratedNever()
                .HasColumnName("ID_KH");
            entity.Property(e => e.Diemtichluy)
                .HasPrecision(5)
                .HasDefaultValueSql("0")
                .HasColumnName("DIEMTICHLUY");
            entity.Property(e => e.Doanhso)
                .HasPrecision(10)
                .HasDefaultValueSql("0")
                .HasColumnName("DOANHSO");
            entity.Property(e => e.IdNd)
                .HasPrecision(8)
                .HasColumnName("ID_ND");
            entity.Property(e => e.Ngaythamgia)
                .HasColumnType("DATE")
                .HasColumnName("NGAYTHAMGIA");
            entity.Property(e => e.Tenkh)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TENKH");

            entity.HasOne(d => d.IdNdNavigation).WithMany(p => p.Khachhangs)
                .HasForeignKey(d => d.IdNd)
                .HasConstraintName("SYS_C007816");
        });

        modelBuilder.Entity<Kho>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("KHO");

            entity.Property(e => e.IdNl)
                .HasPrecision(8)
                .HasColumnName("ID_NL");
            entity.Property(e => e.Slton)
                .HasPrecision(3)
                .HasDefaultValueSql("0\n")
                .HasColumnName("SLTON");

            entity.HasOne(d => d.IdNlNavigation).WithMany()
                .HasForeignKey(d => d.IdNl)
                .HasConstraintName("SYS_C007824");
        });

        modelBuilder.Entity<Monan>(entity =>
        {
            entity.HasKey(e => e.IdMonan).HasName("SYS_C007810");

            entity.ToTable("MONAN");

            entity.Property(e => e.IdMonan)
                .HasPrecision(8)
                .ValueGeneratedNever()
                .HasColumnName("ID_MONAN");
            entity.Property(e => e.Dongia)
                .HasPrecision(8)
                .HasColumnName("DONGIA");
            entity.Property(e => e.Loai)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("LOAI");
            entity.Property(e => e.Tenmon)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TENMON");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TRANGTHAI");
        });

        modelBuilder.Entity<Nguoidung>(entity =>
        {
            entity.HasKey(e => e.IdNd).HasName("SYS_C007806");

            entity.ToTable("NGUOIDUNG");

            entity.Property(e => e.IdNd)
                .HasPrecision(8)
                .ValueGeneratedNever()
                .HasColumnName("ID_ND");
            entity.Property(e => e.Email)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(220)
                .IsUnicode(false)
                .HasColumnName("MATKHAU");
            entity.Property(e => e.Trangthai)
                .HasMaxLength(210)
                .IsUnicode(false)
                .HasDefaultValueSql("''")
                .HasColumnName("TRANGTHAI");
            entity.Property(e => e.Vaitro)
                .HasMaxLength(220)
                .IsUnicode(false)
                .HasColumnName("VAITRO");
            entity.Property(e => e.Verifycode)
                .HasMaxLength(210)
                .IsUnicode(false)
                .HasDefaultValueSql("null")
                .HasColumnName("VERIFYCODE");
        });

        modelBuilder.Entity<Nguyenlieu>(entity =>
        {
            entity.HasKey(e => e.IdNl).HasName("SYS_C007813");

            entity.ToTable("NGUYENLIEU");

            entity.Property(e => e.IdNl)
                .HasPrecision(8)
                .ValueGeneratedNever()
                .HasColumnName("ID_NL");
            entity.Property(e => e.Dongia)
                .HasPrecision(8)
                .HasColumnName("DONGIA");
            entity.Property(e => e.Donvitinh)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("DONVITINH");
            entity.Property(e => e.Tennl)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TENNL");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.IdNv).HasName("SYS_C007808");

            entity.ToTable("NHANVIEN");

            entity.Property(e => e.IdNv)
                .HasPrecision(8)
                .ValueGeneratedNever()
                .HasColumnName("ID_NV");
            entity.Property(e => e.Chucvu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CHUCVU");
            entity.Property(e => e.IdNd)
                .HasPrecision(8)
                .HasColumnName("ID_ND");
            entity.Property(e => e.IdNql)
                .HasPrecision(8)
                .HasDefaultValueSql("null")
                .HasColumnName("ID_NQL");
            entity.Property(e => e.Ngayvl)
                .HasColumnType("DATE")
                .HasColumnName("NGAYVL");
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.Tennv)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TENNV");
            entity.Property(e => e.Tinhtrang)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TINHTRANG");

            entity.HasOne(d => d.IdNdNavigation).WithMany(p => p.Nhanviens)
                .HasForeignKey(d => d.IdNd)
                .HasConstraintName("SYS_C007817");

            entity.HasOne(d => d.IdNqlNavigation).WithMany(p => p.InverseIdNqlNavigation)
                .HasForeignKey(d => d.IdNql)
                .HasConstraintName("SYS_C007818");
        });

        modelBuilder.Entity<Phieunk>(entity =>
        {
            entity.HasKey(e => e.IdNk).HasName("SYS_C007814");

            entity.ToTable("PHIEUNK");

            entity.Property(e => e.IdNk)
                .HasPrecision(8)
                .ValueGeneratedNever()
                .HasColumnName("ID_NK");
            entity.Property(e => e.IdNv)
                .HasPrecision(8)
                .HasColumnName("ID_NV");
            entity.Property(e => e.Ngaynk)
                .HasColumnType("DATE")
                .HasColumnName("NGAYNK");
            entity.Property(e => e.Tongtien)
                .HasPrecision(10)
                .HasDefaultValueSql("0\n")
                .HasColumnName("TONGTIEN");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.Phieunks)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("SYS_C007825");
        });

        modelBuilder.Entity<Phieuxk>(entity =>
        {
            entity.HasKey(e => e.IdXk).HasName("SYS_C007815");

            entity.ToTable("PHIEUXK");

            entity.Property(e => e.IdXk)
                .HasPrecision(8)
                .ValueGeneratedNever()
                .HasColumnName("ID_XK");
            entity.Property(e => e.IdNv)
                .HasPrecision(8)
                .HasColumnName("ID_NV");
            entity.Property(e => e.Ngayxk)
                .HasColumnType("DATE")
                .HasColumnName("NGAYXK");

            entity.HasOne(d => d.IdNvNavigation).WithMany(p => p.Phieuxks)
                .HasForeignKey(d => d.IdNv)
                .HasConstraintName("SYS_C007828");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.CodeVoucher).HasName("SYS_C007812");

            entity.ToTable("VOUCHER");

            entity.Property(e => e.CodeVoucher)
                .HasMaxLength(210)
                .IsUnicode(false)
                .HasColumnName("CODE_VOUCHER");
            entity.Property(e => e.Diem)
                .HasPrecision(8)
                .HasColumnName("DIEM");
            entity.Property(e => e.Loaima)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("LOAIMA");
            entity.Property(e => e.Mota)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("MOTA");
            entity.Property(e => e.Phantram)
                .HasPrecision(3)
                .HasColumnName("PHANTRAM");
            entity.Property(e => e.Soluong)
                .HasPrecision(3)
                .HasColumnName("SOLUONG");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
