namespace WebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;
    using System.Web.Services;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Xml;

    [Table("DanhMuc")]
    public partial class DanhMuc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhMuc()
        {
            BaiViets = new HashSet<BaiViet>();
        }

        [Key]
        public int MaDanhMuc { get; set; }

        [Required]
        [StringLength(50)]
        public string TenDanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiViet> BaiViets { get; set; }
        string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; // tạo kết nối tới sql bằng config

        public bool ThemMoi()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertDanhMuc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tendanhmuc", TenDanhMuc);
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
                SqlCommand cmd = new SqlCommand("sp_updateDanhMuc", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@madanhmuc", MaDanhMuc);
                cmd.Parameters.AddWithValue("@tendanhmuc", TenDanhMuc);
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
