namespace WebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Configuration;
    using System.Data;
    using System.Data.Entity.Spatial;
    using System.Data.SqlClient;

    [Table("BaiViet")]
    public partial class BaiViet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaiViet()
        {
            BinhLuans = new HashSet<BinhLuan>();
            FileUpLoads = new HashSet<FileUpLoad>();
        }

        [Key]
        public int MaBaiViet { get; set; }

        [Required]
        [StringLength(255)]
        public string TieuDe { get; set; }

        [Required]
        [StringLength(255)]
        public string TomTat { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string NoiDung { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string HinhThuNho { get; set; }

        [StringLength(100)]
        public string ChuThichHinh { get; set; }

        public int LuotXem { get; set; }

        public DateTime NgayDang { get; set; }

        public int MaNguoiDung { get; set; }

        public int MaDanhMuc { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FileUpLoad> FileUpLoads { get; set; }
        string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public bool ThemMoi()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertBaiViet", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tieude", TieuDe);
                cmd.Parameters.AddWithValue("@tomtat", TomTat);
                cmd.Parameters.AddWithValue("@noidung", NoiDung);
                cmd.Parameters.AddWithValue("@hinhthunho", HinhThuNho);
                cmd.Parameters.AddWithValue("@chuthichhinh", ChuThichHinh);
                cmd.Parameters.AddWithValue("@luotxem", LuotXem);
                cmd.Parameters.AddWithValue("@ngaydang", NgayDang);
                cmd.Parameters.AddWithValue("@manguoidung", MaNguoiDung);
                cmd.Parameters.AddWithValue("@madanhmuc", MaDanhMuc);
                con.Open();
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        public bool CapNhat()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_updatebaiViet", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mabaiviet", MaBaiViet);
                cmd.Parameters.AddWithValue("@tieude", TieuDe);
                cmd.Parameters.AddWithValue("@tomtat", TomTat);
                cmd.Parameters.AddWithValue("@noidung", NoiDung);
                cmd.Parameters.AddWithValue("@hinhthunho", HinhThuNho);
                cmd.Parameters.AddWithValue("@chuthichhinh", ChuThichHinh);
                cmd.Parameters.AddWithValue("@luotxem", LuotXem);
                cmd.Parameters.AddWithValue("@ngaydang", NgayDang);
                cmd.Parameters.AddWithValue("@manguoidung", MaNguoiDung);
                cmd.Parameters.AddWithValue("@madanhmuc", MaDanhMuc);
                con.Open();
                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
    }
}
