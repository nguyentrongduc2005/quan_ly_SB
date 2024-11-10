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
    class HoaDonModel
    {
        SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        KetNoi kn = new KetNoi();
        //đóng mở kết nối csdl
        DataSet ds_KH = new DataSet();
        SqlDataAdapter matkhachang;
        public bool KetQuaTruyVan { get; set; }
        public string ThongBaoTruyVan { get; set; }
        //Load dữ liệu cho datagidview
        public DataTable HienThiDuLieu() //trả về 1 bảng
        {
            conn = kn.conDB();
            conn.Open();
            string sql = "SELECT * FROM HoaDon";
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
        public bool ThemHoaDon(string makh, string masan,DateTime  ngaylaphd, double tongphutda,float dongia,float thanhtien)
        {
            string sqlThem = "INSERT INTO [HoaDon] ([Ma_KhachHang], [Ma_San],[NgayLap_HD], [TongPhut_Da],[DonGia],[TongTien_HD]) VALUES ('" + makh + "','" + masan + "', '" + ngaylaphd + "'," + tongphutda + "," + dongia + "," + thanhtien + ")";
            bool kt = false;
            if (ExecuteNonQuery(sqlThem) > 0)
            {
                kt = true;
            }
            return kt;
        }
        public bool ThemHD(string makh, string masan, DateTime ngaylaphd, double tongphutda, float dongia, float thanhtien)
        {
            conn = kn.conDB();
            try
            {
                // SỬA nhanh
                string query = "insert into HoaDon(Ma_KhachHang,Ma_San,NgayLap_HD, TongPhut_Da,DonGia,TongTien_HD) values (@Ma_KhachHang, @Ma_San, @ThoiGianBatDau,@phutda, @DonGia, @ThanhTien)";

                // create connection and command
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    // define parameters and their values
                    cmd.Parameters.AddWithValue("@Ma_San", masan);
                    cmd.Parameters.AddWithValue("@Ma_KhachHang", makh);
                    cmd.Parameters.AddWithValue("@ThoiGianBatDau", ngaylaphd);
                    cmd.Parameters.AddWithValue("@phutda", tongphutda);
                    cmd.Parameters.AddWithValue("@DonGia", dongia);
                    cmd.Parameters.AddWithValue("@ThanhTien", thanhtien);
                    cmd.ExecuteNonQuery();
                    KetQuaTruyVan = true;
                    conn.Close();
                }

                KetQuaTruyVan = true;
            }
            catch (Exception ex)
            {
                KetQuaTruyVan = false;
                ThongBaoTruyVan = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return KetQuaTruyVan;
        }
        public DataTable HienThiThongKeNam(string nam) //trả về 1 bảng
        {
            conn = kn.conDB();
            conn.Open();
            string sql = "SELECT * FROM HoaDon WHERE (YEAR(NgayLap_HD)) ='"+ nam + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable HienThiThongKeThang(string thang, string nam) //trả về 1 bảng
        {
            conn = kn.conDB();
            conn.Open();
            string sql = "SELECT * FROM HoaDon WHERE (Month(NgayLap_HD))='"+thang+ "' and (YEAR(NgayLap_HD)) ='"+nam+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable LoadMaKHCombobox()
        {
            conn = kn.conDB();
            conn.Open();
            matkhachang = new SqlDataAdapter("select * from KhachHang", conn);
            matkhachang.Fill(ds_KH, "Ma_KhachHang");
            conn.Close();
            return ds_KH.Tables["Ma_KhachHang"];
        }
        public bool kiemTraTonTai(string maHD)
        {
            conn = kn.conDB();
            conn.Open();
            bool tatkt = false;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT count(*) FROM HoaDon where Ma_HD='" + maHD + "'", conn);
                //SqlDataReader dr = cmd.ExecuteReader();
                int kt = (int)cmd.ExecuteScalar();
                conn.Close();
                if (kt > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            return tatkt;
        }
        public bool XoaHD(string maHD)
        {
            string sqlXoa = "DELETE FROM HoaDon WHERE Ma_HD= '" + maHD + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlXoa) > 0)
            {
                kt = true;
            }
            return kt;
        }
        public bool SuaHD(string maHD, string makh, string masan, string date, string tongphutda,string dongia,string tongtien)
        {
            string sqlSua = "UPDATE HoaDon set Ma_KhachHang= '" + makh + "', Ma_San= '" + masan + "',NgayLap_HD = '" + date + "',TongPhut_Da = '" + tongphutda + "',DonGia = '" + dongia + "',TongTien_HD = '" + tongtien + "' where Ma_HD= '" + maHD + "'";
            bool kt = false;
            if (ExecuteNonQuery(sqlSua) > 0)
            {
                kt = true;
            }
            return kt;
        }
    }
}
