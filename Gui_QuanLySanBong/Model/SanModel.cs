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
    class SanModel
    {
        SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        KetNoi kn = new KetNoi();
        //đóng mở kết nối csdl
        DataSet ds_San = new DataSet();
        SqlDataAdapter loaisan;

        //Load dữ liệu cho datagidview
        public DataTable HienThiDuLieuSan() //trả về 1 bảng
        {
            conn = kn.conDB();
            conn.Open();
            string sql = "SELECT * FROM San";
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
            loaisan.Fill(ds_San, "Loai_San");
            conn.Close();
            return ds_San.Tables["Loai_San"];
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
        public bool kiemTraTonTaiMaSan(string maSan)
        {
            conn = kn.conDB();
            conn.Open();
            bool tatkt = false;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Ma_San FROM San where Ma_San='" + maSan + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (maSan == dr.GetString(0))
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
        
        public bool ThemSan(string masan, string loaisan, string tensan)
        {
            string sqlThem = "INSERT INTO [San] ([Ma_San], [Loai_San],[Ten_San]) VALUES ('" + masan + "','" + loaisan + "', N'" + tensan + "')";
            bool kt = false;
            if (ExecuteNonQuery(sqlThem) > 0)
            {
                kt = true;
            }
            return kt;
        }

        public bool XoaSan(string maSan)
        {
            string sqlXoa = "DELETE FROM San WHERE Ma_San= '" + maSan + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlXoa) > 0)
            {
                kt = true;
            }
            return kt;
        }
        public bool SuaSan(string masan, string loaisan, string tensan)
        {
            string sqlSua = "UPDATE San set Loai_San= '" + loaisan + "', Ten_San= N'" + tensan + "' where Ma_San= '" + masan + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
        public DataTable HienThiDuLieuTimKiem(string maSan) //trả về 1 bảng
        {
            conn = kn.conDB();
            conn.Open();
            string sql = "SELECT * FROM San where Ma_San LIKE '%" + maSan + "%' OR Loai_San LIKE'%" + maSan + "%' OR Ten_San LIKE'%" + maSan + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
       
    }
}
