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

namespace GUI_QuanLySanBong
{
    public partial class FrmQuanLyKinhDoanh : Form
    {
        KhachHangController KHControl = new KhachHangController();
        HoaDonController HDControl = new HoaDonController();
        public FrmQuanLyKinhDoanh()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            cboThang.SelectedIndex = 0;
            cboNam.SelectedIndex = 0;
        }

        private void dtgvTTKH_Show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grTTKH_TimKiem_Enter(object sender, EventArgs e)
        {

        }
        public void LoadKH()
        {
            try
            {
                dtgvTTKH_Show.AutoGenerateColumns = false;
                DataTable dtKH = new DataTable();
                dtKH = KHControl.HienThiDuLieu();
                dtgvTTKH_Show.DataSource = dtKH;
                dtgvTTKH_Show.Columns[0].DataPropertyName = "Ma_KhachHang";
                dtgvTTKH_Show.Columns[1].DataPropertyName = "Ten_KhachHang";
                dtgvTTKH_Show.Columns[2].DataPropertyName = "DiaChi_KhachHang";
                dtgvTTKH_Show.Columns[3].DataPropertyName = "Sdt_KhachHang";

            }
            catch
            {
                //MessageBox.Show("Lỗi");
            }
        }
        private void FrmQuanLyKinhDoanh_Load(object sender, EventArgs e)
        {
            LoadKH();
            LoadHoaDon();
            LoadDoanhThu();
            cmbKH.DataSource = HDControl.HienThiDuLieuCboxKH();
            cmbKH.DisplayMember = "Ma_KhachHang";
            cmbKH.ValueMember = "Ma_KhachHang";
        }

        private void grTTKH_ThongTin_Enter(object sender, EventArgs e)
        {

        }

        private void dtgvTTKH_Show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            try
            {
                numrow = e.RowIndex;
                txtMaKhachHang.Text = dtgvTTKH_Show.Rows[numrow].Cells[0].Value.ToString();
                txtTenKhachHang.Text = dtgvTTKH_Show.Rows[numrow].Cells[1].Value.ToString();
                txtDiaChi.Text = dtgvTTKH_Show.Rows[numrow].Cells[2].Value.ToString();
                txtSoDienThoai.Text = dtgvTTKH_Show.Rows[numrow].Cells[3].Value.ToString();
            }
            catch
            {
                //MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dtgvTTKH_Show.AutoGenerateColumns = false;
                DataTable dtKH = new DataTable();
                dtKH = KHControl.HienThiDuLieuTimKiem(txtSearchKH.Text);
                dtgvTTKH_Show.DataSource = dtKH;
                dtgvTTKH_Show.Columns[0].DataPropertyName = "Ma_KhachHang";
                dtgvTTKH_Show.Columns[1].DataPropertyName = "Ten_KhachHang";
                dtgvTTKH_Show.Columns[2].DataPropertyName = "DiaChi_KhachHang";
                dtgvTTKH_Show.Columns[3].DataPropertyName = "Sdt_KhachHang";

            }
            catch
            {
                //MessageBox.Show("Lỗi");
            }
        }
        private bool KTNhap()
        {
            if (txtMaKhachHang.TextLength == 0)
            {
                txtMaKhachHang.Focus();
                MessageBox.Show("Bạn chưa nhập mã khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtTenKhachHang.TextLength == 0)
            {
                txtTenKhachHang.Focus();
                MessageBox.Show("Bạn chưa nhập tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtDiaChi.TextLength == 0)
            {
                txtDiaChi.Focus();
                MessageBox.Show("Bạn chưa nhập địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }         
            return true;
        }
        private bool KTNhapHD()
        {
            if (txtMasan.TextLength == 0)
            {
                txtMasan.Focus();
                MessageBox.Show("Bạn chưa mã sân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtTongphutda.TextLength == 0)
            {
                txtTongphutda.Focus();
                MessageBox.Show("Bạn chưa nhập số phút đá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtDonGia.TextLength == 0)
            {
                txtDonGia.Focus();
                MessageBox.Show("Bạn chưa nhập đơn giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtTongTien.TextLength == 0)
            {
                txtTongTien.Focus();
                MessageBox.Show("Bạn chưa nhập tổng tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        private void txtMaKhachHang_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void dtgvHD_Show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        public void LoadHoaDon()
        {
            try
            {
                dgrvHD_Show.AutoGenerateColumns = false;
                DataTable dtHD = new DataTable();
                dtHD = HDControl.HienThiDuLieu();
                dgrvHD_Show.DataSource = dtHD;
                dgrvHD_Show.Columns[0].DataPropertyName = "Ma_HD";
                dgrvHD_Show.Columns[1].DataPropertyName = "Ma_KhachHang";
                dgrvHD_Show.Columns[2].DataPropertyName = "Ma_San";
                dgrvHD_Show.Columns[3].DataPropertyName = "NgayLap_HD";
                dgrvHD_Show.Columns[4].DataPropertyName = "TongPhut_Da";
                dgrvHD_Show.Columns[5].DataPropertyName = "DonGia";
                dgrvHD_Show.Columns[6].DataPropertyName = "TongTien_HD";
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        public void LoadDoanhThu()
        {
            try
            {
                dtgv_doanhthu.AutoGenerateColumns = false;
                DataTable dtHD = new DataTable();
                dtHD = HDControl.HienThiDuLieuDoanhThu();
                dtgv_doanhthu.DataSource = dtHD;
                dtgv_doanhthu.Columns[0].DataPropertyName = "Ma_KhachHang";
                dtgv_doanhthu.Columns[1].DataPropertyName = "Ma_San";
                dtgv_doanhthu.Columns[2].DataPropertyName = "NgayLap_HD";
                dtgv_doanhthu.Columns[3].DataPropertyName = "TongPhut_Da";
                dtgv_doanhthu.Columns[4].DataPropertyName = "DonGia";
                dtgv_doanhthu.Columns[5].DataPropertyName = "TongTien_HD";
            }
            catch
            {
                MessageBox.Show("Lỗi");
            }
        }

        private void btn_ThongKeNam_Click(object sender, EventArgs e)
        {
            try
            {
                dtgv_doanhthu.AutoGenerateColumns = false;
                DataTable dtHD = new DataTable();
                dtHD = HDControl.HienThiDuLieuTheoNam(comboBox1.Text);
                dtgv_doanhthu.DataSource = dtHD;
                dtgv_doanhthu.Columns[0].DataPropertyName = "Ma_KhachHang";
                dtgv_doanhthu.Columns[1].DataPropertyName = "Ma_San";
                dtgv_doanhthu.Columns[2].DataPropertyName = "NgayLap_HD";
                dtgv_doanhthu.Columns[3].DataPropertyName = "TongPhut_Da";
                dtgv_doanhthu.Columns[4].DataPropertyName = "DonGia";
                dtgv_doanhthu.Columns[5].DataPropertyName = "TongTien_HD";
            }
            catch
            {
           
            }
            tong();
        }
        public void tong()
        {
            int tien = dtgv_doanhthu.Rows.Count;
            float thanhtien = 0;
            for (int i = 0; i < tien; i++)
            {
                thanhtien += float.Parse(dtgv_doanhthu.Rows[i].Cells[5].Value.ToString());
            }
            label30.Text ="Tổng doanh thu: "+ thanhtien.ToString() +" VNĐ";
        }

        private void btnThang_Click(object sender, EventArgs e)
        {
            try
            {
                dtgv_doanhthu.AutoGenerateColumns = false;
                DataTable dtHD = new DataTable();
                dtHD = HDControl.HienThiDuLieuTheoThang(cboThang.Text,cboNam.Text);
                dtgv_doanhthu.DataSource = dtHD;
                dtgv_doanhthu.Columns[0].DataPropertyName = "Ma_KhachHang";
                dtgv_doanhthu.Columns[1].DataPropertyName = "Ma_San";
                dtgv_doanhthu.Columns[2].DataPropertyName = "NgayLap_HD";
                dtgv_doanhthu.Columns[3].DataPropertyName = "TongPhut_Da";
                dtgv_doanhthu.Columns[4].DataPropertyName = "DonGia";
                dtgv_doanhthu.Columns[5].DataPropertyName = "TongTien_HD";
            }
            catch
            {

            }
            tong();
        }

        private void cboNam_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgrvHD_Show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            try
            {
                numrow = e.RowIndex;
                cmbKH.Text = dgrvHD_Show.Rows[numrow].Cells[1].Value.ToString();
                txtMasan.Text = dgrvHD_Show.Rows[numrow].Cells[2].Value.ToString();
                dtNgayLap.Text = dgrvHD_Show.Rows[numrow].Cells[3].Value.ToString();
                txtTongphutda.Text = dgrvHD_Show.Rows[numrow].Cells[4].Value.ToString();
                txtDonGia.Text = dgrvHD_Show.Rows[numrow].Cells[5].Value.ToString();
                txtTongTien.Text = dgrvHD_Show.Rows[numrow].Cells[6].Value.ToString();
            }
            catch
            {
                //MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maHD = null;
            if (dgrvHD_Show.CurrentRow != null)
            {
                maHD = dgrvHD_Show.CurrentRow.Cells[0].Value.ToString();
            }
            if (maHD == null)
                return;
            if (HDControl.KiemTraDuLieuHD(maHD))
            {
                try
                {
                    HDControl.XoaDuLieuHD(maHD);
                    LoadHoaDon();
                    MessageBox.Show("Xoá hóa đơn " + maHD + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
            }
            else
            {
                MessageBox.Show("Không thể xoá hóa đơn " + maHD + " chưa tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KTNhapHD())
            {
                return;
            }

            string maHD = null;
            if (dgrvHD_Show.CurrentRow != null)
            {
                maHD = dgrvHD_Show.CurrentRow.Cells[0].Value.ToString();
            }
            if (maHD == null)
                return;

            if (HDControl.KiemTraDuLieuHD(maHD))
            {
                try
                {
                    HDControl.SuaDuLieuHD(maHD, cmbKH.Text, txtMasan.Text, dtNgayLap.Text, txtTongphutda.Text, txtDonGia.Text, txtTongTien.Text);
                    MessageBox.Show("Thành công!");
                    LoadHoaDon();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
            }
            else
            {
                MessageBox.Show("Hóa đơn chưa đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
                Application.Exit();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string maHD = null;
            if (dgrvHD_Show.CurrentRow != null)
            {
                maHD = dgrvHD_Show.CurrentRow.Cells[0].Value.ToString();
            }
            if (maHD == null)
                return;
            if (HDControl.KiemTraDuLieuHD(maHD))
            {
                try
                {
                    HDControl.LuuDuLieuHD(maHD);
                    LoadDoanhThu();
                    MessageBox.Show("Luu hóa đơn " + maHD + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHoaDon();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
            }
            else
            {
                MessageBox.Show("Không thể xoá hóa đơn " + maHD + " chưa tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if (!KTNhap())
            {
                return;
            }

            if (KHControl.KiemTraDuLieuKH(txtMaKhachHang.Text))
            {
                MessageBox.Show("Tên khách hàng đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    KHControl.ThemDuLieuKH(txtMaKhachHang.Text, txtTenKhachHang.Text, txtDiaChi.Text, txtSoDienThoai.Text);
                    MessageBox.Show("Thành công!");
                    LoadKH();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (KHControl.KiemTraDuLieuKH(txtMaKhachHang.Text))
            {
                try
                {
                    KHControl.XoaDuLieuKH(txtMaKhachHang.Text);                  
                    MessageBox.Show("Xoá khách hàng " + txtMaKhachHang.Text + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadKH();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
            }
            else
            {
                MessageBox.Show("Không thể xoá " + txtMaKhachHang.Text + " chưa tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (!KTNhap())
            {
                return;
            }
            else
            {
                if (KHControl.KiemTraDuLieuKH(txtMaKhachHang.Text))
                {
                    try
                    {
                        KHControl.SuaDuLieuKH(txtMaKhachHang.Text, txtTenKhachHang.Text, txtDiaChi.Text, txtSoDienThoai.Text);
                        MessageBox.Show("Thành công!");
                        LoadKH();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Tên khách hàng chưa đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            txtMaKhachHang.Text = "";
            txtTenKhachHang.Text = "";
            txtDiaChi.Text = "";
            txtSoDienThoai.Text = "";
            txtMaKhachHang.Focus();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
                Application.Exit();
        }

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {
            if (txtSoDienThoai.TextLength > 0)
            {
                if (!char.IsDigit(txtSoDienThoai.Text[txtSoDienThoai.TextLength - 1]))
                {
                    this.errorProvider1.SetError(txtSoDienThoai, "Bạn phải nhập số lớn hơn 0");
                }
                else
                    this.errorProvider1.Clear();
            }
        }

        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '-'))
                e.Handled = true;
            if (e.KeyChar == '-')
            {
                int k = 0;
                for (int i = 0; i < txtSoDienThoai.Text.Length; i++)
                {
                    if (txtSoDienThoai.Text[i] == '-')
                        k++;
                }
                if (k == 0)
                    e.Handled = false;
                if (k == 1)
                    e.Handled = true;
            }
        }

        private void txtTongphutda_TextChanged(object sender, EventArgs e)
        {
            if (txtTongphutda.TextLength > 0)
            {
                if (!char.IsDigit(txtTongphutda.Text[txtTongphutda.TextLength - 1]))
                {
                    this.errorProvider1.SetError(txtTongphutda, "Bạn phải nhập số lớn hơn 0");
                }
                else
                    this.errorProvider1.Clear();
            }
        }

        private void txtTongphutda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '-'))
                e.Handled = true;
            if (e.KeyChar == '-')
            {
                int k = 0;
                for (int i = 0; i < txtTongphutda.Text.Length; i++)
                {
                    if (txtTongphutda.Text[i] == '-')
                        k++;
                }
                if (k == 0)
                    e.Handled = false;
                if (k == 1)
                    e.Handled = true;
            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
            if (txtDonGia.TextLength > 0)
            {
                if (!char.IsDigit(txtDonGia.Text[txtDonGia.TextLength - 1]))
                {
                    this.errorProvider1.SetError(txtDonGia, "Bạn phải nhập số lớn hơn 0");
                }
                else
                    this.errorProvider1.Clear();
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '-'))
                e.Handled = true;
            if (e.KeyChar == '-')
            {
                int k = 0;
                for (int i = 0; i < txtDonGia.Text.Length; i++)
                {
                    if (txtDonGia.Text[i] == '-')
                        k++;
                }
                if (k == 0)
                    e.Handled = false;
                if (k == 1)
                    e.Handled = true;
            }
        }

        private void txtTongTien_TextChanged(object sender, EventArgs e)
        {
            if (txtTongTien.TextLength > 0)
            {
                if (!char.IsDigit(txtTongTien.Text[txtTongTien.TextLength - 1]))
                {
                    this.errorProvider1.SetError(txtTongTien, "Bạn phải nhập số lớn hơn 0");
                }
                else
                    this.errorProvider1.Clear();
            }
        }

        private void txtTongTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '-'))
                e.Handled = true;
            if (e.KeyChar == '-')
            {
                int k = 0;
                for (int i = 0; i < txtTongTien.Text.Length; i++)
                {
                    if (txtTongTien.Text[i] == '-')
                        k++;
                }
                if (k == 0)
                    e.Handled = false;
                if (k == 1)
                    e.Handled = true;
            }
        }

       
    }
}
