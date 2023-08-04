using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebService.Models
{
    public partial class ModelsClass : DbContext
    {
        public ModelsClass()
            : base("name=ModelsClass")
        {
        }

        public virtual DbSet<BaiViet> BaiViets { get; set; }
        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<FileUpLoad> FileUpLoads { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<VaiTro> VaiTroes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiViet>()
                .Property(e => e.HinhThuNho)
                .IsUnicode(false);

            modelBuilder.Entity<BaiViet>()
                .HasMany(e => e.BinhLuans)
                .WithRequired(e => e.BaiViet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaiViet>()
                .HasMany(e => e.FileUpLoads)
                .WithMany(e => e.BaiViets)
                .Map(m => m.ToTable("FileBaiViet").MapLeftKey("MaBaiViet").MapRightKey("MaFile"));

            modelBuilder.Entity<DanhMuc>()
                .HasMany(e => e.BaiViets)
                .WithRequired(e => e.DanhMuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FileUpLoad>()
                .Property(e => e.TenFile)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .Property(e => e.HinhDaiDien)
                .IsUnicode(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.BaiViets)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.BinhLuans)
                .WithRequired(e => e.NguoiDung)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VaiTro>()
                .HasMany(e => e.NguoiDungs)
                .WithRequired(e => e.VaiTro1)
                .HasForeignKey(e => e.VaiTro)
                .WillCascadeOnDelete(false);
        }
    }
}
