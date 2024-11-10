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
    class KhachHangModel
    {
        SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        KetNoi kn = new KetNoi();
        private int maKhachHang;

        public int MaKhachHang
        {
            get { return maKhachHang; }
            set { maKhachHang = value; }
        }

        //đóng mở kết nối csdl

        //Load dữ liệu cho datagidview
        public DataTable HienThiDuLieu() //trả về 1 bảng
        {
            conn = kn.conDB();
            conn.Open();
            string sql = "SELECT * FROM KhachHang";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable HienThiDuLieuTimKiem(string maKH) //trả về 1 bảng
        {
            conn = kn.conDB();
            conn.Open();
            string sql = "SELECT * FROM KhachHang where Ma_KhachHang LIKE '%" + maKH + "%' OR Ten_KhachHang LIKE'%" + maKH + "%' OR Sdt_KhachHang LIKE'%" + maKH + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
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
        public bool ThemKH(string makh, string tenkh, string diachi, string sdt)
        {
            string sqlThem = "INSERT INTO [KhachHang] ([Ma_KhachHang], [Ten_KhachHang],[DiaChi_KhachHang], [Sdt_KhachHang]) VALUES ('" + makh + "',N'" + tenkh + "', N'" + diachi + "','" + sdt + "')";
            bool kt = false;
            if (ExecuteNonQuery(sqlThem) > 0)
            {
                kt = true;
            }
            return kt;
        }
        public bool kiemTraTonTai(string maKH)
        {
            conn = kn.conDB();
            conn.Open();
            bool tatkt = false;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Ma_KhachHang FROM KhachHang where Ma_KhachHang='" + maKH + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (maKH == dr.GetString(0))
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
        public bool XoaKH(string maKH)
        {
            string sqlXoa = "DELETE FROM KhachHang WHERE Ma_KhachHang= '" + maKH + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlXoa) > 0)
            {
                kt = true;
            }
            return kt;
        }
        public bool SuaKH(string makh, string tenkh, string diachi, string sdt)
        {
            string sqlSua = "UPDATE KhachHang set Ten_KhachHang= N'" + tenkh + "', DiaChi_KhachHang= N'" + diachi + "',Sdt_KhachHang = '" + sdt + "' where Ma_KhachHang= '" + makh + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
        
        public KhachHangModel()
        {
        }
        public KhachHangModel(int makhachhang)
        {
            this.MaKhachHang = makhachhang;
        }
    }
}
