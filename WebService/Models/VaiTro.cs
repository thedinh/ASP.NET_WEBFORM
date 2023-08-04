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

    [Table("VaiTro")]
    public partial class VaiTro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VaiTro()
        {
            NguoiDungs = new HashSet<NguoiDung>();
        }

        [Key]
        public int MaVaiTro { get; set; }

        [Required]
        [StringLength(255)]
        public string TenVaiTro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NguoiDung> NguoiDungs { get; set; }
        string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; // tạo kết nối tới sql bằng config

        public bool ThemMoi()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertVaiTro", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tenvaitro", TenVaiTro);
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
                SqlCommand cmd = new SqlCommand("sp_updateVaiTro", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mavaitro", MaVaiTro);
                cmd.Parameters.AddWithValue("@tenvaitro", TenVaiTro);
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
