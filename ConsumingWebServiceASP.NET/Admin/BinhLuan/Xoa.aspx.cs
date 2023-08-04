﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_BaiViet_Xoa : System.Web.UI.Page
{
    string conStr = "Data Source=.;Initial Catalog=BaoMoi;Integrated Security=True";

    public bool IsNumeric(string input)
    {
        bool isNumber = int.TryParse(input, out _);
        return isNumber;
    }
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
    protected void Page_Load(object sender, EventArgs e)
    {
        var MaBinhLuan = Request.QueryString["MaBinhLuan"];
        bool isNumber = IsNumeric(MaBinhLuan);
        if (string.IsNullOrWhiteSpace(Request.QueryString["MaBinhLuan"]) || isNumber == false)
        {
            Response.Redirect("../404.aspx");
        }

        if (!String.IsNullOrEmpty(Request.QueryString["MaBinhLuan"]))
        {
            int count = LayDuLieu("BinhLuan where MaBinhLuan = '" + MaBinhLuan + "' ").Tables[0].Rows.Count;
            if (count > 0)
            {
                XoaDuLieu("BinhLuan", "MaBinhLuan = '" + MaBinhLuan + "'");
                Session["DeleteStatus"] = "ok";
                Response.Redirect("DanhSach.aspx");
            }
            else
            {
                Response.Redirect("../404.aspx");
            }
        }
        else
        {
            Response.Write("<script>window.addEventListener('load', (event) => { $.toast({heading: 'Thông báo',text: 'Xóa thất bại',position: 'top-right',loaderBg: '#923f50',bgColor:'#fa5c7c '}) });</script>");

        }

    }
}