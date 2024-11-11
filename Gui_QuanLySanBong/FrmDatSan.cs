using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GUI_QuanLySanBong.Controller;
using GUI_QuanLySanBong.Model;
using System.Data.SqlClient;
using System.Diagnostics;

namespace GUI_QuanLySanBong
{
    public partial class FrmDatSan : Form
    {
        ThueSanController ThuesanControl = new ThueSanController();
        HoaDonController hd = new HoaDonController();
        DataTable dtthuesan = new DataTable();
        KetNoi kn = new KetNoi();
        SqlConnection con;
        SqlCommand cm;
        public FrmDatSan()
        {
            InitializeComponent();
            dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dataGridView1.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            cbbLoaiThue.SelectedIndex = 0;
            dateBD.Value = DateTime.Now;
            dateKT.Value = DateTime.Now;
            dtGioBatDau.Value = DateTime.Now;
            dtGioKetThuc.Value = DateTime.Now.AddHours(1);

        }

        private void FrmDatSan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLySanBongDataSet.ThueSan' table. You can move, or remove it, as needed.
            this.thuesanTableAdapter.Fill(this.quanLySanBongDataSet1.ThueSan);
            LoadThuesan();
            cbbsan.DataSource = ThuesanControl.HienThiDuLieuCbox();
            cbbsan.DisplayMember = "Ten_San";
            cbbsan.ValueMember = "Ma_San";
            cbbsan.SelectedValue = "Ma_San";

            cbbmakh.DataSource = ThuesanControl.HienThiDuLieuCboxKH();
            cbbmakh.DisplayMember = "Ten_KhachHang";
            cbbmakh.ValueMember = "Ma_KhachHang";

            cbbsan.SelectedIndex = 0;

            //if (ThuesanControl.KiemTraDuLieuSAN1())
            //{
            //    btnSan1.Enabled = false;
            //}
            //else
            //{
            //    btnSan1.Enabled = true;
            //}

        }
        public void LoadThuesan()
        {
            try
            {
                dataGridView1.AutoGenerateColumns = false;
                dtthuesan = ThuesanControl.HienThiDuLieu();
                dataGridView1.DataSource = dtthuesan;
                dataGridView1.Columns[0].DataPropertyName = "Ma_ThueSan";
                dataGridView1.Columns[1].DataPropertyName = "Ma_San";
                dataGridView1.Columns[2].DataPropertyName = "Ma_KhachHang";
                dataGridView1.Columns[3].DataPropertyName = "ThoiGianBatDau";
                dataGridView1.Columns[4].DataPropertyName = "ThoiGianKetThuc";
                dataGridView1.Columns[5].DataPropertyName = "LoaiThue";
                dataGridView1.Columns[6].DataPropertyName = "DonGia";
                dataGridView1.Columns[7].DataPropertyName = "ThanhTien";
            }
            catch
            {   
                //MessageBox.Show("Lỗi");
            }
        }

        private void btnDatSan_Click(object sender, EventArgs e)
        {
            DateTime tgHienTai = DateTime.Now;
            long timestampTgHienTai = new DateTimeOffset(tgHienTai).ToUnixTimeSeconds();


            DateTime datebatdau = dateBD.Value;
            DateTime dateketthuc = dateKT.Value;
            DateTime timeBatDau = dtGioBatDau.Value;
            DateTime timeKetThuc = dtGioKetThuc.Value;

            DateTime batdau = new DateTime(datebatdau.Year, datebatdau.Month, datebatdau.Day, timeBatDau.Hour, timeBatDau.Minute, 0);
            long timestampBatDau = new DateTimeOffset(batdau).ToUnixTimeSeconds();

            DateTime ketthuc = new DateTime(dateketthuc.Year, dateketthuc.Month, dateketthuc.Day, timeKetThuc.Hour, timeKetThuc.Minute, 0);
            long timestampKetThuc = new DateTimeOffset(ketthuc).ToUnixTimeSeconds();

            //Thuê sân
            if (cbbLoaiThue.SelectedIndex == 0)
            {
                //Check xem sân có đang trống trong khoảng thời gian đặt không
                if (ThuesanControl.CheckSuDung(cbbsan.SelectedValue.ToString(), DateTime.Now).Rows.Count > 0)
                {
                    MessageBox.Show("Sân đã được đặt trước trong khoảng thời gian này");
                    return;
                }

                bool ketQua = ThuesanControl.ThueSanTrucTiep(cbbsan.SelectedValue.ToString(), cbbmakh.SelectedValue.ToString(), cbbLoaiThue.Text, Convert.ToInt32(nbDonGia.Value));
                if (ketQua)
                {

                    MessageBox.Show("Thuê sân thành công");
                    LoadThuesan();

                }
                else
                {
                    MessageBox.Show(ThuesanControl.ThongBaoTruyVan);
                }
            }
            //Đặt sân
            else
            {
                Debug.WriteLine("aloooooooooo");
                Debug.WriteLine(timestampTgHienTai);
                Debug.WriteLine(timestampBatDau);
                Debug.WriteLine(timestampKetThuc);
                if (timestampBatDau < timestampTgHienTai)
                {
                    Debug.WriteLine("loi");
                    MessageBox.Show("thoi gian khong hop le 1");
                    return;
                }

                if (timestampKetThuc < timestampBatDau)
                {
                    Debug.WriteLine("loi");
                    MessageBox.Show("thoi gian khong hop le 2");
                    return;
                }

                if (timestampKetThuc - timestampBatDau < 3600)
                {
                    Debug.WriteLine("loi");
                    MessageBox.Show("khong du 60p");
                    return;
                }



                DateTime ngayBatDau = dateBD.Value.Date + dtGioBatDau.Value.TimeOfDay;
                DateTime ngayKetThuc = dateKT.Value.Date + dtGioKetThuc.Value.TimeOfDay;

                //Check xem sân có đang trống trong khoảng thời gian đặt không
                if (ThuesanControl.CheckSuDung(cbbsan.SelectedValue.ToString(), ngayBatDau).Rows.Count > 0)
                {
                    MessageBox.Show("Sân đã được đặt trước trong khoảng thời gian này");
                    return;
                }

                double tongSoPhut = Math.Round(ngayKetThuc.Subtract(ngayBatDau).TotalMinutes / 15.0) / 4;
                double soGio = Math.Floor(tongSoPhut);

                double soPhut = (tongSoPhut - soGio) * 60.0;
                int thanhTien = Convert.ToInt32(((double)nbDonGia.Value * soGio) + (soPhut * (double)nbDonGia.Value / 60));
                var xacNhan = MessageBox.Show("Tổng thời gian thuê: " + soGio + " tiếng " + soPhut + "phút." + Environment.NewLine + "Thành tiền: " + thanhTien.ToString("N0"), "Xác nhận", MessageBoxButtons.YesNo);
                if (xacNhan == DialogResult.Yes)
                {
                    bool ketQua = ThuesanControl.DatSan(cbbsan.SelectedValue.ToString(), cbbmakh.SelectedValue.ToString(), ngayBatDau, ngayKetThuc, cbbLoaiThue.Text, Convert.ToInt32(nbDonGia.Value), thanhTien);
                    if (ketQua)
                    {
                        MessageBox.Show("Đặt sân thành công");
                        LoadThuesan();
                        try
                        {
                            if (hd.ThemHoaDon(cbbmakh.SelectedValue.ToString(), cbbsan.SelectedValue.ToString(), ngayKetThuc, soGio, Convert.ToInt32(nbDonGia.Value), thanhTien)){
                                //MessageBox.Show("Thành công");
                            }
                            else
                            {
                                MessageBox.Show(hd.ThongBaoTruyVan);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Đã xảy ra lỗi ở bảng HĐ");
                        }
                    }
                    else
                    {
                        MessageBox.Show(ThuesanControl.ThongBaoTruyVan);
                    }
                }
            }
        }


 

        private void cbbsan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con = kn.conDB();
                con.Open();
                cm = new SqlCommand("SELECT GiaLoai_San FROM San, LoaiSan WHERE San.Loai_San = LoaiSan.Loai_San and San.Ma_San ='" + cbbsan.SelectedValue + "'", con);
                SqlDataReader reader = cm.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    string b = reader.GetDouble(0).ToString();
                    nbDonGia.Text = b.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
            con.Close();
        }

        private void cbbLoaiThue_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLoaiThue.SelectedIndex == 1)
            {
                dateBD.Enabled = true;
                dateKT.Enabled = true;
                dtGioBatDau.Enabled = true;
                dtGioKetThuc.Enabled = true;
            }
            else
            {
                dateBD.Enabled = false;
                dateKT.Enabled = false;
                dtGioBatDau.Enabled = false;
                dtGioKetThuc.Enabled = false;
            }
        }



        private void cbbLoaiThue_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbbLoaiThue.SelectedIndex == 1)
            {
                dateBD.Enabled = true;
                dateKT.Enabled = true;
                dtGioBatDau.Enabled = true;
                dtGioKetThuc.Enabled = true;
            }
            else
            {
                dateBD.Enabled = false;
                dateKT.Enabled = false;
                dtGioBatDau.Enabled = false;
                dtGioKetThuc.Enabled = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            try
            {
                btnHuySan.Enabled = true;
                dateBD.Enabled = true;
                dateKT.Enabled = true;
                dtGioBatDau.Enabled = true;
                dtGioKetThuc.Enabled = true;
                numrow = e.RowIndex;
                label4.Text= dataGridView1.Rows[numrow].Cells[0].Value.ToString();
                cbbsan.SelectedValue = dataGridView1.Rows[numrow].Cells[1].Value.ToString();
                cbbmakh.SelectedValue = dataGridView1.Rows[numrow].Cells[2].Value.ToString();
                dateBD.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
                dtGioBatDau.Text = dataGridView1.Rows[numrow].Cells[3].Value.ToString();
                dateKT.Text = dataGridView1.Rows[numrow].Cells[4].Value.ToString();
                dtGioKetThuc.Text = dataGridView1.Rows[numrow].Cells[4].Value.ToString();
                cbbLoaiThue.Text = dataGridView1.Rows[numrow].Cells[5].Value.ToString();
                nbDonGia.Text = dataGridView1.Rows[numrow].Cells[6].Value.ToString();
            }
            catch
            {
                //MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHuySan_Click(object sender, EventArgs e)
        {
           
            DateTime ngayBatDau = dateBD.Value.Date + dtGioBatDau.Value.TimeOfDay;
            DateTime ngayKetThuc = dateKT.Value.Date + dtGioKetThuc.Value.TimeOfDay;
            double tongSoPhut = Math.Round(ngayKetThuc.Subtract(ngayBatDau).TotalMinutes / 15.0) / 4;
            double soGio = Math.Floor(tongSoPhut);
            double soPhut = (tongSoPhut - soGio) * 60.0;
            int thanhTien = Convert.ToInt32(((double)nbDonGia.Value * soGio) + (soPhut * (double)nbDonGia.Value / 60));
            var xacNhan = MessageBox.Show("Tổng thời gian thuê: " + soGio + " tiếng " + soPhut + "phút." + Environment.NewLine + "Thành tiền: " + thanhTien.ToString("N0"), "Xác nhận", MessageBoxButtons.YesNo);
            if (xacNhan == DialogResult.Yes)
            {
                try {
                    bool ketQua = ThuesanControl.TraSan(Convert.ToInt32(label4.Text), ngayKetThuc, Convert.ToInt32(nbDonGia.Value), thanhTien);
                    if (ketQua)
                    {
                        MessageBox.Show("Trả sân thành công");
                        LoadThuesan();
                        dataGridView1.CurrentRow.Cells[0].Value.ToString();
                        try
                        {
                            if (hd.ThemHoaDon(cbbmakh.SelectedValue.ToString(), cbbsan.SelectedValue.ToString(), ngayKetThuc, soGio, Convert.ToInt32(nbDonGia.Value), thanhTien))
                            {
                                //MessageBox.Show("Thành công");
                            }
                            else
                            {
                                MessageBox.Show(hd.ThongBaoTruyVan);
                            }
                        }
                        catch
                        {
                            MessageBox.Show("Đã xảy ra lỗi ở bảng HĐ");
                        }
                    }
                    else
                    {
                        MessageBox.Show(ThuesanControl.ThongBaoTruyVan);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ThuesanControl.ThongBaoTruyVan +" "+ex );
                }
             
            }
        }

        private void btnSuaSan_Click(object sender, EventArgs e)
        {
            if(label4.Text.Equals(""))
            {
                MessageBox.Show("Vui lòng chọn Sân để xoá!!");
            }
            else
            {
                try
                {
                    DialogResult dlr = MessageBox.Show("Bạn có chắc chắn muốn xoá STT "+ label4.Text+" không?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
                    if (dlr == DialogResult.Yes)
                    {
                        ThuesanControl.Xoa(Convert.ToInt32(label4.Text));
                        LoadThuesan();
                        MessageBox.Show("Đã xoá thành công");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi: "+ex);
                }
            }
            
        }

        private void btnSan1_Click(object sender, EventArgs e)
        {

        }

        private void thueSanBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void sanBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void grThongTin_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
