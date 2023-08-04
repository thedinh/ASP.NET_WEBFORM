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

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [Key]
        public int MaBinhLuan { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string NoiDung { get; set; }

        public DateTime NgayDang { get; set; }

        public int MaNguoiDung { get; set; }

        public int MaBaiViet { get; set; }

        public virtual BaiViet BaiViet { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
        string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public bool ThemMoi()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertBinhLuan", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@noidung", NoiDung);
                cmd.Parameters.AddWithValue("@ngaydang", NgayDang);
                cmd.Parameters.AddWithValue("@manguoidung", MaNguoiDung);
                cmd.Parameters.AddWithValue("@mabaiviet", MaBaiViet);
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
                SqlCommand cmd = new SqlCommand("sp_updateBinhLuan", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mabinhluan", MaBinhLuan);
                cmd.Parameters.AddWithValue("@noidung", NoiDung);
                cmd.Parameters.AddWithValue("@ngaydang", NgayDang);
                cmd.Parameters.AddWithValue("@manguoidung", MaNguoiDung);
                cmd.Parameters.AddWithValue("@mabaiviet", MaBaiViet);
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
