using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace GUI_QuanLySanBong.Model
{
    class LoaiSanModel
    {
        SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        KetNoi kn = new KetNoi();
        //đóng mở kết nối csdl
        DataSet ds_San = new DataSet();
        SqlDataAdapter loaisan;

        public DataTable HienThiDuLieuLoaiSan() //trả về 1 bảng
        {
            conn = kn.conDB();
            conn.Open();
            string sql = "SELECT * FROM LoaiSan";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable LoadLoaiSanCombobox()
        {
            conn = kn.conDB();
            conn.Open();
            loaisan = new SqlDataAdapter("select * from LoaiSan", conn);
            loaisan.Fill(ds_San, "Ten_Loai");
            conn.Close();
            return ds_San.Tables["Ten_Loai"];
        }
        public int ExecuteNonQuery(string sql)
        {
            int dung = 0;
            try
            {
                conn = kn.conDB();
                conn.Open(); ;
                SqlCommand cmd = new SqlCommand(sql, conn);
                dung = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            { }
            return dung;
        }
        public bool kiemTraTonTaiLoaiSan(string loaiSan)
        {
            conn = kn.conDB();
            conn.Open();
            bool tatkt = false;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Loai_San FROM LoaiSan where Loai_San='" + loaiSan + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (loaiSan == dr.GetString(0))
                    {
                        tatkt = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            conn.Close();
            return tatkt;
        }
        public bool kiemTraTonTaiLoaiSan_San(string loaiSan)
        {
            conn = kn.conDB();
            conn.Open();
            bool tatkt = false;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Loai_San FROM San where Loai_San='" + loaiSan + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (loaiSan == dr.GetString(0))
                    {
                        tatkt = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            conn.Close();
            return tatkt;
        }
        public bool ThemLoaiSan(string loaisan, string tenloaisan, string gialoaisan)
        {
            string sqlThem = "INSERT INTO [LoaiSan] ([Loai_San], [Ten_Loai],[GiaLoai_San]) VALUES ('" + loaisan + "','" + tenloaisan + "', N'" + gialoaisan + "')";
            bool kt = false;
            if (ExecuteNonQuery(sqlThem) > 0)
            {
                kt = true;
            }
            return kt;
        }

        public bool XoaLoaiSan(string maLoaiSan)
        {
            string sqlXoa = "DELETE FROM LoaiSan WHERE Loai_San= '" + maLoaiSan + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlXoa) > 0)
            {
                kt = true;
            }
            return kt;
        }
        public bool SuaLoaiSan(string loaisan, string tenloaisan, string gialoaisan)
        {
            string sqlSua = "UPDATE LoaiSan set Ten_Loai= '" + tenloaisan + "', GiaLoai_San= N'" + gialoaisan + "' where Loai_San= '" + loaisan + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
    }
}
