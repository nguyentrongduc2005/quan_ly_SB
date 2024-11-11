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
    class ThueSan
    {
        SqlConnection conn;
        SqlCommand cmd = new SqlCommand();
        KetNoi kn = new KetNoi();
        //đóng mở kết nối csdl
        DataSet ds_San = new DataSet();
        SqlDataAdapter san;
        SqlDataAdapter matkhachang;

        //Load dữ liệu cho datagidview
        public DataTable HienThiDuLieu() //trả về 1 bảng
        {
            conn = kn.conDB();
            conn.Open();
            string sql = "SELECT * FROM thueSan";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public DataTable LoadMaSanCombobox()
        {
            conn = kn.conDB();
            conn.Open();
            san = new SqlDataAdapter("select * from San", conn);
            san.Fill(ds_San, "Ma_San");
            conn.Close();
            return ds_San.Tables["Ma_San"];
        }
        public DataTable LoadMaKHCombobox()
        {
            conn = kn.conDB();
            conn.Open();
            matkhachang = new SqlDataAdapter("select * from KhachHang", conn);
            matkhachang.Fill(ds_San, "Ma_KhachHang");
            conn.Close();
            return ds_San.Tables["Ma_KhachHang"];
        }
        public bool kiemTraSan1()
        {
            string san1 = "SAN1";
            conn = kn.conDB();
            conn.Open();
            bool tatkt = false;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Ma_San FROM ThueSan where Ma_San='SAN1'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (san1==dr.GetString(0))
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
        public bool ThemThueSan(string masan, string makh, string ngaythuesan, string gioBD, string gioKT)
        {
            string sqlThem = "INSERT INTO [ThueSan] ([Ma_San], [Ma_KhachHang],[NgayThue_San], [Gio_BD],[Gio_KT]) VALUES ('" + masan + "','" + makh + "', '" + ngaythuesan + "',N'" + gioBD + "',N'" + gioKT + "')";
            bool kt = false;
            if (ExecuteNonQuery(sqlThem) > 0)
            {
                kt = true;
            }
            return kt;
        }
        public bool kiemTraTonTai(string maThuesan)
        {
            conn = kn.conDB();
            conn.Open();
            bool tatkt = false;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Ma_ThueSan FROM ThueSan where Ma_ThueSan='" + maThuesan + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (maThuesan == dr.GetString(0))
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
        public bool KetQuaTruyVan { get; set; }
        public string ThongBaoTruyVan { get; set; }
        public DataTable CheckSuDung(string Ma_San, DateTime thoiGianBatDau)
        {
            DataTable tbl = new DataTable();
            conn = kn.conDB();
            try
            {
                // define INSERT query with parameters
                string query = "select * from ThueSan where Ma_San = @Ma_San and (ThoiGianBatDau < @ThoiGianBatDau and (ThoiGianKetThuc > @ThoiGianBatDau or ThoiGianKetThuc is null))";

                // create connection and command
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Ma_San", Ma_San);
                    cmd.Parameters.AddWithValue("@ThoiGianBatDau", thoiGianBatDau);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(tbl);
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
            return tbl;
        }
        public bool ThueSanTrucTiep(string masan, string makh, string loaithue, int dongia)
        {
            conn = kn.conDB();
            try
            {
                // define INSERT query with parameters
                string query = "insert into ThueSan(Ma_San, Ma_KhachHang,ThoiGianBatDau, LoaiThue, DonGia) values (@Ma_San, @Ma_KhachHang,@ThoiGianBatDau, @LoaiThue, @DonGia)";

                // create connection and command
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    // define parameters and their values
                    cmd.Parameters.AddWithValue("@Ma_San",masan );
                    cmd.Parameters.AddWithValue("@Ma_KhachHang", makh);
                    cmd.Parameters.AddWithValue("@ThoiGianBatDau", DateTime.Now);
                    cmd.Parameters.AddWithValue("@LoaiThue", loaithue);
                    cmd.Parameters.AddWithValue("@DonGia", dongia);
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
        public bool DatSan(string masan, string makh, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string loaiThue, int donGia, int thanhTien)
        {
            conn = kn.conDB();
            try
            {
                // define INSERT query with parameters
                string query = "insert into ThueSan(Ma_San, Ma_KhachHang, ThoiGianBatDau, ThoiGianKetThuc, LoaiThue, DonGia, ThanhTien) values (@Ma_San, @Ma_KhachHang, @ThoiGianBatDau, @ThoiGianKetThuc, @LoaiThue, @DonGia, @ThanhTien)";

                // create connection and command
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    // define parameters and their values
                    cmd.Parameters.AddWithValue("@Ma_San", masan);
                    cmd.Parameters.AddWithValue("@Ma_KhachHang", makh);
                    cmd.Parameters.AddWithValue("@ThoiGianBatDau", thoiGianBatDau);
                    cmd.Parameters.AddWithValue("@ThoiGianKetThuc", thoiGianKetThuc);
                    cmd.Parameters.AddWithValue("@LoaiThue", loaiThue);
                    cmd.Parameters.AddWithValue("@DonGia", donGia);
                    cmd.Parameters.AddWithValue("@ThanhTien", thanhTien);
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
        public bool TraSan(int Ma_ThueSan, DateTime thoiGianKetThuc, int donGia, int thanhTien)
        {
            /*conn = kn.conDB();
            try
            {
                // define INSERT query with parameters
                string query = "update ThueSan set ThoiGianKetThuc = @ThoiGianKetThuc, DonGia = @DonGia, ThanhTien = @ThanhTien where Ma_ThueSan = @Ma_ThueSan";

                // create connection and command
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    // define parameters and their values
                    cmd.Parameters.AddWithValue("@ThoiGianKetThuc", thoiGianKetThuc);
                    cmd.Parameters.AddWithValue("@DonGia", donGia);
                    cmd.Parameters.AddWithValue("@ThanhTien", thanhTien);
                    cmd.Parameters.AddWithValue("@Ma_ThueSan", Ma_ThueSan);
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
            return KetQuaTruyVan;*/
            Xoa(Ma_ThueSan);
            return true;
        }
        public bool Xoa(int Ma_ThueSan)
        {
            conn = kn.conDB();
            try
            {
                // define INSERT query with parameters
                string query = "delete from ThueSan where Ma_ThueSan = @Ma_ThueSan";
                
                // create connection and command
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    // define parameters and their values
                    cmd.Parameters.AddWithValue("@Ma_ThueSan", Ma_ThueSan);
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

    }
}
