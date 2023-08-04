using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Xml;
using WebService.Models;
using Microsoft.SqlServer.Server;
using System.IO;
using System.Diagnostics;
using System.Web.UI.WebControls;

namespace WebService
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        public string checkSession()
        {
            return HttpContext.Current.Session.SessionID;
        }
        [WebMethod]
        public bool IsNumeric(string input)
        {
            bool isNumber = int.TryParse(input, out _);
            return isNumber;
        }
        string conStr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString; // tạo kết nối tới sql bằng config
        // lấy dữ liệu theo bảng bằng tham số được truyền
        [WebMethod]
        public DataSet LayDuLieu(string table)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_select", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tenbang", table);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }
        // Thêm danh mục
        [WebMethod]
        public bool ThemDuLieuDanhMuc(string tendanhmuc)
        {
            //using (SqlConnection con = new SqlConnection(conStr))
            //{
            //    SqlCommand cmd = new SqlCommand("sp_InsertDanhMuc", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@tendanhmuc", tendanhmuc);
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //}
            Models.DanhMuc DanhMuc = new Models.DanhMuc
            {
                TenDanhMuc = tendanhmuc
            };
            bool status = DanhMuc.ThemMoi();
            if (status == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Sửa danh mục
        [WebMethod]
        public bool CapNhatDuLieuDanhMuc(int madanhmuc, string tendanhmuc)
        {
            //using (SqlConnection con = new SqlConnection(conStr))
            //{
            //    SqlCommand cmd = new SqlCommand("sp_InsertDanhMuc", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@tendanhmuc", tendanhmuc);
            //    con.Open();
            //    cmd.ExecuteNonQuery();
            //}
            Models.DanhMuc DanhMuc = new Models.DanhMuc
            {
                MaDanhMuc = madanhmuc,
                TenDanhMuc = tendanhmuc
            };
            bool status = DanhMuc.CapNhat();
            if (status == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Thêm Bài Viết
        [WebMethod]
        public bool ThemDuLieuBaiViet(string tieude, string tomtat, string noidung, string hinhthunho, string chuthichhinh, int luotxem, DateTime ngaydang, int manguoidung, int madanhmuc)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                //SqlCommand cmd = new SqlCommand("sp_InsertBaiViet", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@tieude", tieude);
                //cmd.Parameters.AddWithValue("@tomtat", tomtat);
                //cmd.Parameters.AddWithValue("@noidung", noidung);
                //cmd.Parameters.AddWithValue("@hinhthunho", hinhthunho);
                //cmd.Parameters.AddWithValue("@chuthichhinh", chuthichhinh);
                //cmd.Parameters.AddWithValue("@luotxem", luotxem);
                //cmd.Parameters.AddWithValue("@ngaydang", ngaydang);
                //cmd.Parameters.AddWithValue("@manguoidung", manguoidung);
                //cmd.Parameters.AddWithValue("@madanhmuc", madanhmuc);
                //con.Open();
                //cmd.ExecuteNonQuery();
                Models.BaiViet baiViet = new Models.BaiViet
                {
                    TieuDe = tieude,
                    TomTat = tomtat,
                    NoiDung = noidung,
                    HinhThuNho = hinhthunho,
                    ChuThichHinh = chuthichhinh,
                    LuotXem = luotxem,
                    NgayDang = ngaydang,
                    MaNguoiDung = manguoidung,
                    MaDanhMuc = madanhmuc
                };
                bool status = baiViet.ThemMoi();
                if (status == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        // xóa dữ liệu theo bảng và điều kiện
        [WebMethod]
        public bool CapNhatDuLieuBaiViet(int mabaiviet, string tieude, string tomtat, string noidung, string hinhthunho, string chuthichhinh, int luotxem, DateTime ngaydang, int manguoidung, int madanhmuc)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                //SqlCommand cmd = new SqlCommand("sp_InsertBaiViet", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@tieude", tieude);
                //cmd.Parameters.AddWithValue("@tomtat", tomtat);
                //cmd.Parameters.AddWithValue("@noidung", noidung);
                //cmd.Parameters.AddWithValue("@hinhthunho", hinhthunho);
                //cmd.Parameters.AddWithValue("@chuthichhinh", chuthichhinh);
                //cmd.Parameters.AddWithValue("@luotxem", luotxem);
                //cmd.Parameters.AddWithValue("@ngaydang", ngaydang);
                //cmd.Parameters.AddWithValue("@manguoidung", manguoidung);
                //cmd.Parameters.AddWithValue("@madanhmuc", madanhmuc);
                //con.Open();
                //cmd.ExecuteNonQuery();
                Models.BaiViet baiViet = new Models.BaiViet
                {
                    MaBaiViet = mabaiviet,
                    TieuDe = tieude,
                    TomTat = tomtat,
                    NoiDung = noidung,
                    HinhThuNho = hinhthunho,
                    ChuThichHinh = chuthichhinh,
                    LuotXem = luotxem,
                    NgayDang = ngaydang,
                    MaNguoiDung = manguoidung,
                    MaDanhMuc = madanhmuc
                };
                bool status = baiViet.CapNhat();
                if (status == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        // Thêm mới dữ liệu người dùng
        [WebMethod]
        public bool ThemDuLieuNguoiDung(string TenNguoiDung, string Email, string MatKhau, string HinhDaiDien, DateTime NgaySinh, string DiaChi, int SDT, byte GioiTinh, int VaiTro)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                Models.NguoiDung Nguoidung = new Models.NguoiDung
                {
                    TenNguoiDung = TenNguoiDung,
                    Email = Email,
                    MatKhau = MatKhau,
                    HinhDaiDien = HinhDaiDien,
                    NgaySinh = NgaySinh,
                    DiaChi = DiaChi,
                    SDT = SDT,
                    GioiTinh = GioiTinh,
                    VaiTro = VaiTro
                };
                bool status = Nguoidung.themmoi();
                if (status == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        // Cập nhật dữ liệu người dùng

        [WebMethod]
        public bool CapNhatDuLieuNguoiDung(int manguoidung, string TenNguoiDung, string Email, string MatKhau, string HinhDaiDien, DateTime NgaySinh, string DiaChi, int SDT, byte GioiTinh, int VaiTro)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                Models.NguoiDung Nguoidung = new Models.NguoiDung
                {
                    MaNguoiDung = manguoidung,
                    TenNguoiDung = TenNguoiDung,
                    Email = Email,
                    MatKhau = MatKhau,
                    HinhDaiDien = HinhDaiDien,
                    NgaySinh = NgaySinh,
                    DiaChi = DiaChi,
                    SDT = SDT,
                    GioiTinh = GioiTinh,
                    VaiTro = VaiTro
                };
                bool status = Nguoidung.CapNhap();
                if (status == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        // Thêm mới dữ liệu bình luận
        [WebMethod]
        public bool ThemDuLieuBinhLuan(string noidung, DateTime ngaydang, int manguoidung, int mabaiviet)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                Models.BinhLuan binhluan = new Models.BinhLuan
                {
                    NoiDung = noidung,
                    NgayDang = ngaydang,
                    MaNguoiDung = manguoidung,
                    MaBaiViet = mabaiviet
                };
                bool status = binhluan.ThemMoi();
                if (status == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        // Cập nhật dữ liệu bình luận
        [WebMethod]
        public bool CapnhatDuLieuBinhLuan(int mabinhluan, string noidung, int manguoidung, int mabaiviet)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                Models.BinhLuan binhluan = new Models.BinhLuan
                {
                    MaBinhLuan = mabinhluan,
                    NoiDung = noidung,
                    NgayDang = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy")),
                    MaNguoiDung = manguoidung,
                    MaBaiViet = mabaiviet
                };
                bool status = binhluan.CapNhat();
                if (status == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        // xóa dữ liệu theo bảng và điều kiện
        [WebMethod]
        public bool ThemDuLieuFileUpload(string tenfile, string chuthichfile)
        {

            Models.FileUpLoad fileUpLoad = new Models.FileUpLoad()
            {
                TenFile = tenfile,
                ChuThichFile = chuthichfile
            };
            bool status = fileUpLoad.ThemMoi();
            if (status == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // File Upload
        [WebMethod]
        public void UploadFile(string fileName, string chuthichfile, string contentType, byte[] bytes)
        {
            string webRootPath = Server.MapPath("~");
            string docPath = Path.GetFullPath(Path.Combine(webRootPath, "../ConsumingWebServiceASP.NET/Uploads/", fileName));
            File.WriteAllBytes(docPath, bytes);
            ThemDuLieuFileUpload(fileName, chuthichfile);
        }

        [WebMethod]
        public string checkpath(string fileName, string rootPath)
        {
            //string filePath = Server.MapPath(string.Format(""));
            //File.WriteAllBytes(filePath, bytes);
            string webRootPath = Server.MapPath("~");
            string docPath = Path.GetFullPath(Path.Combine(webRootPath, "../'" + rootPath + "'/Uploads/", fileName));
            return docPath;
        }
        // Thêm vai trò
        [WebMethod]
        public bool ThemDuLieuVaiTro(string tenvaitro)
        {

            Models.VaiTro vaiTro = new Models.VaiTro()
            {
                TenVaiTro = tenvaitro,
            };
            bool status = vaiTro.ThemMoi();
            if (status == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        // Thêm vai trò
        [WebMethod]
        public bool CapnhatDuLieuVaiTro(int mavaitro, string tenvaitro)
        {

            Models.VaiTro vaiTro = new Models.VaiTro()
            {
                MaVaiTro = mavaitro,
                TenVaiTro = tenvaitro,
            };
            bool status = vaiTro.CapNhat();
            if (status == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [WebMethod]
        public void XoaDuLieu(string tenbang, string dieukien)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("sp_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tenbang", tenbang);
                cmd.Parameters.AddWithValue("@dieukien", dieukien);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        [WebMethod]
        public DataSet LayDanhSachBaiViet()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("select BaiViet.*,DanhMuc.TenDanhMuc from baiviet inner join DanhMuc on BaiViet.MaDanhMuc = DanhMuc.MaDanhMuc", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }
        [WebMethod]
        public DataSet LayBaiVietMoiNhatTheoDanhMuc()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string sql = "SELECT bv.*, dm.TenDanhMuc\r\nFROM BaiViet bv\r\nINNER JOIN (\r\n    SELECT MaDanhMuc, MAX(NgayDang) AS MaxNgayDang\r\n    FROM BaiViet\r\n    GROUP BY MaDanhMuc\r\n) latest ON bv.MaDanhMuc = latest.MaDanhMuc AND bv.NgayDang = latest.MaxNgayDang\r\nINNER JOIN DanhMuc dm ON bv.MaDanhMuc = dm.MaDanhMuc";
                SqlCommand cmd = new SqlCommand(sql, con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }
        [WebMethod]
        public DataSet LayBaiVietLienQuan(int MaDanhMuc)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                SqlCommand cmd = new SqlCommand("select top 5 BaiViet.*,DanhMuc.TenDanhMuc from baiviet inner join DanhMuc on BaiViet.MaDanhMuc = DanhMuc.MaDanhMuc where BaiViet.MaDanhMuc = '"+MaDanhMuc+"'", con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }
        [WebMethod]
        public DataSet LayNhungBaiVietMoiNhat()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "select top 5 BaiViet.*,DanhMuc.TenDanhMuc from baiviet inner join DanhMuc on BaiViet.MaDanhMuc = DanhMuc.MaDanhMuc ORDER BY NgayDang DESC\r\n";
                SqlCommand cmd = new SqlCommand(query, con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }
        [WebMethod]
        public DataSet LayBinhLuan(int mabaiviet)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "select BinhLuan.*,NguoiDung.* from BinhLuan inner join NguoiDung on BinhLuan.MaNguoiDung = NguoiDung.MaNguoiDung where MaBaiViet = '"+ mabaiviet +"'";
                SqlCommand cmd = new SqlCommand(query, con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }
        [WebMethod]
        public int Authencation(string Email, string MatKhau,int VaiTro)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string query = "SELECT count(*) FROM NguoiDung where Email = '"+ Email + "' and MatKhau = '"+ MatKhau + "' and VaiTro = '"+ VaiTro+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
        }
        [WebMethod]
        public DataSet LoadBinhLuan()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string query = "select BinhLuan.*,NguoiDung.TenNguoiDung,BaiViet.TieuDe from BinhLuan inner join NguoiDung on BinhLuan.MaNguoiDung = NguoiDung.MaNguoiDung inner join BaiViet on BinhLuan.MaBaiViet = BaiViet.MaBaiViet";
                SqlCommand cmd = new SqlCommand(query, con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }
        [WebMethod]
        public bool DangKy(string UserName, string email,string pass,int vaitro)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "Insert Into NguoiDung(TenNguoiDung,Email,MatKhau,VaiTro) values('" + UserName+ "','"+email+"','"+pass+"','"+vaitro+"')";
                SqlCommand cmd = new SqlCommand(query, con);
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
        [WebMethod]
        public DataSet loadNguoiDung()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string query = "select *,VaiTro.TenVaiTro from NguoiDung inner join VaiTro on NguoiDung.VaiTro = VaiTro.MaVaiTro";
                SqlCommand cmd = new SqlCommand(query, con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }
        [WebMethod]
        public DataSet LoadDanhMuc(int Madanhmuc)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string query = "select * from BaiViet inner join DanhMuc on BaiViet.MaDanhMuc = DanhMuc.MaDanhMuc where BaiViet.MaDanhMuc = '"+Madanhmuc+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
        }
    }
}
