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

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            BaiViets = new HashSet<BaiViet>();
            BinhLuans = new HashSet<BinhLuan>();
        }

        [Key]
        public int MaNguoiDung { get; set; }

        [Required]
        [StringLength(50)]
        public string TenNguoiDung { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string MatKhau { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string HinhDaiDien { get; set; }

        public DateTime NgaySinh { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string DiaChi { get; set; }

        public int SDT { get; set; }

        public byte GioiTinh { get; set; }

        public int VaiTro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiViet> BaiViets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        public virtual VaiTro VaiTro1 { get; set; }
        string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public bool themmoi()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertNguoiDung", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tennguoidung", TenNguoiDung);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@matkhau", MatKhau);
                cmd.Parameters.AddWithValue("@hinhdaidien", HinhDaiDien);
                cmd.Parameters.AddWithValue("@ngaysinh", NgaySinh);
                cmd.Parameters.AddWithValue("@diachi", DiaChi);
                cmd.Parameters.AddWithValue("@sdt", SDT);
                cmd.Parameters.AddWithValue("@gioitinh", GioiTinh);
                cmd.Parameters.AddWithValue("@vaitro", VaiTro);
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
        public bool CapNhap()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_updateNguoiDung", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@manguoidung", MaNguoiDung);
                cmd.Parameters.AddWithValue("@tennguoidung", TenNguoiDung);
                cmd.Parameters.AddWithValue("@email", Email);
                cmd.Parameters.AddWithValue("@matkhau", MatKhau);
                cmd.Parameters.AddWithValue("@hinhdaidien", HinhDaiDien);
                cmd.Parameters.AddWithValue("@ngaysinh", NgaySinh);
                cmd.Parameters.AddWithValue("@diachi", DiaChi);
                cmd.Parameters.AddWithValue("@sdt", SDT);
                cmd.Parameters.AddWithValue("@gioitinh", GioiTinh);
                cmd.Parameters.AddWithValue("@vaitro", VaiTro);
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
