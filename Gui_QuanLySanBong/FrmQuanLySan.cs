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
    public partial class FrmQuanLySan : Form
    {
        SanController SanControl = new SanController();
        LoaiSanController loaiSanControl = new LoaiSanController();
        public FrmQuanLySan()
        {
            InitializeComponent();

        }

        private void FrmQuanLySan_Load(object sender, EventArgs e)
        {
            LoadSan();
            LoadLoaiSan();
            cbbloaisan.DataSource = SanControl.HienThiDuLieuCbox();
            cbbloaisan.DisplayMember = "Loai_San";
            cbbloaisan.ValueMember = "Loai_San";

            //cbbtenloaisan.DataSource = loaiSanControl.HienThiDuLieuCbox();
            //cbbtenloaisan.DisplayMember = "Ten_Loai";
            //cbbtenloaisan.ValueMember = "Ten_Loai";
        }

        private void dtgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadSan()
        {
            try
            {
                dtgvQLS_Show.AutoGenerateColumns = false;
                DataTable dtSan = new DataTable();
                dtSan = SanControl.HienThiDuLieuSan();
                dtgvQLS_Show.DataSource = dtSan;
                dtgvQLS_Show.Columns[0].DataPropertyName = "Ma_San";
                dtgvQLS_Show.Columns[1].DataPropertyName = "Loai_San";
                dtgvQLS_Show.Columns[2].DataPropertyName = "Ten_San";
            }
            catch
            {
                //MessageBox.Show("Lỗi");
            }
        }
        public void LoadLoaiSan()
        {
            try
            {
                dtgvQLLS_Show.AutoGenerateColumns = false;
                DataTable dtloaiSan = new DataTable();
                dtloaiSan = loaiSanControl.HienThiDuLieuLoaiSan();
                dtgvQLLS_Show.DataSource = dtloaiSan;
                dtgvQLLS_Show.Columns[0].DataPropertyName = "Loai_San";
                dtgvQLLS_Show.Columns[1].DataPropertyName = "Ten_Loai";
                dtgvQLLS_Show.Columns[2].DataPropertyName = "GiaLoai_San";
            }
            catch
            {
                //MessageBox.Show("Lỗi");
            }
        }

       

        private void txtmasan_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void dtgvQLS_Show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            try
            {
                numrow = e.RowIndex;
                txtmasan.Text = dtgvQLS_Show.Rows[numrow].Cells[0].Value.ToString();
                cbbloaisan.Text = dtgvQLS_Show.Rows[numrow].Cells[1].Value.ToString();
                txttensan.Text = dtgvQLS_Show.Rows[numrow].Cells[2].Value.ToString();
            }
            catch
            {
                //MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtgvQLLS_Show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            try
            {
                numrow = e.RowIndex;
                txtloaisan.Text = dtgvQLLS_Show.Rows[numrow].Cells[0].Value.ToString();
                txtTenLoaiSan.Text = dtgvQLLS_Show.Rows[numrow].Cells[1].Value.ToString();
                txtgialoaisan.Text = dtgvQLLS_Show.Rows[numrow].Cells[2].Value.ToString();
            }
            catch
            {
            }
        }
        private bool KTNhap()
        {
            if (txtmasan.TextLength == 0)
            {
                txtmasan.Focus();
                MessageBox.Show("Bạn chưa nhập mã sân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txttensan.TextLength == 0)
            {
                txttensan.Focus();
                MessageBox.Show("Bạn chưa nhập tên sân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }            
            return true;
        }
        private bool KTNhapLS()
        {
            if (txtloaisan.TextLength == 0)
            {
                txtloaisan.Focus();
                MessageBox.Show("Bạn chưa nhập tên loại sân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtgialoaisan.TextLength == 0)
            {
                txtgialoaisan.Focus();
                MessageBox.Show("Bạn chưa nhập giá loại sân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

       

        private void btnQLS_Luu_Click(object sender, EventArgs e)
        {
            txtmasan.Text = "";
            cbbloaisan.Text = "";
            txttensan.Text = "";
            txtmasan.Focus();
        }

        private void btnQLS_Sua_Click(object sender, EventArgs e)
        {
            if (!KTNhap())
            {
                return;
            }
            else
            {
                if (SanControl.KiemTraDuLieuSan(txtmasan.Text))
                {
                    try
                    {
                        SanControl.SuaDuLieuSan(txtmasan.Text, cbbloaisan.Text, txttensan.Text);
                        MessageBox.Show("Thành công!");
                        LoadSan();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Mã sân chưa tồn tại chưa đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnQLS_Xoa_Click(object sender, EventArgs e)
        {
            if (SanControl.KiemTraDuLieuSan(txtmasan.Text))
            {
                try
                {
                    SanControl.XoaDuLieuSan(txtmasan.Text);
                    LoadSan();
                    MessageBox.Show("Xoá " + txttensan.Text + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
            }
            else
            {
                MessageBox.Show("Không thể xoá " + txttensan.Text + " chưa tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dtgvQLS_Show.AutoGenerateColumns = false;
                DataTable dtSan = new DataTable();
                dtSan = SanControl.HienThiDuLieuTimKiem(txtSearchUser.Text);
                dtgvQLS_Show.DataSource = dtSan;
                dtgvQLS_Show.Columns[0].DataPropertyName = "Ma_San";
                dtgvQLS_Show.Columns[1].DataPropertyName = "Loai_San";
                dtgvQLS_Show.Columns[2].DataPropertyName = "Ten_San";

            }
            catch
            {
            }
        }

        
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KTNhap())
            {
                return;
            }

            if (SanControl.KiemTraDuLieuSan(txtmasan.Text))
            {
                MessageBox.Show("Mã sân đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SanControl.ThemDuLieuSan(txtmasan.Text, cbbloaisan.Text, txttensan.Text);
                    MessageBox.Show("Thành công!");
                    LoadSan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (SanControl.KiemTraDuLieuSan(txtmasan.Text))
            {
                try
                {
                    SanControl.XoaDuLieuSan(txtmasan.Text);
                    LoadSan();
                    MessageBox.Show("Xoá " + txttensan.Text + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
            }
            else
            {
                MessageBox.Show("Không thể xoá " + txttensan.Text + " chưa tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!KTNhap())
            {
                return;
            }
            else
            {
                if (SanControl.KiemTraDuLieuSan(txtmasan.Text))
                {
                    try
                    {
                        SanControl.SuaDuLieuSan(txtmasan.Text, cbbloaisan.Text, txttensan.Text);
                        MessageBox.Show("Thành công!");
                        LoadSan();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Mã sân chưa tồn tại chưa đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtmasan.Text = "";
            cbbloaisan.Text = "";
            txttensan.Text = "";
            txtmasan.Focus();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            if (!KTNhapLS())
            {
                return;
            }

            if (loaiSanControl.KiemTraDuLieuLoaiSan(txtloaisan.Text))
            {
                MessageBox.Show("Loại sân đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    loaiSanControl.ThemDuLieuLoaiSan(txtloaisan.Text, txtTenLoaiSan.Text, txtgialoaisan.Text);
                    MessageBox.Show("Thành công!");
                    LoadLoaiSan();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (loaiSanControl.KiemTraDuLieuLoaiSan(txtloaisan.Text))
            {
                if(loaiSanControl.KiemTraDuLieuLoaiSan_SAN(txtloaisan.Text))
                {
                    MessageBox.Show("Không thể xoá " + txtloaisan.Text + " vì đã tồn tại trong bảng Sân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        loaiSanControl.XoaDuLieuLoaiSan(txtloaisan.Text);
                        LoadLoaiSan();
                        MessageBox.Show("Xoá " + txtloaisan.Text + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex);
                    }
                }
               
            }
            else
            {
                MessageBox.Show("Không thể xoá " + txtloaisan.Text + " chưa tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (!KTNhapLS())
            {
                return;
            }
            else
            {
                if (loaiSanControl.KiemTraDuLieuLoaiSan(txtloaisan.Text))
                {
                    try
                    {
                        loaiSanControl.SuaDuLieuLoaiSan(txtloaisan.Text, txtTenLoaiSan.Text, txtgialoaisan.Text);
                        MessageBox.Show("Thành công!");
                        LoadLoaiSan();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Loại sân chưa tồn tại chưa đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            txtloaisan.Text = "";
            txtTenLoaiSan.Text = "";
            txtgialoaisan.Text = "";
            txtloaisan.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
                Application.Exit();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
                Application.Exit();
        }

        private void txtgialoaisan_TextChanged(object sender, EventArgs e)
        {
            if (txtgialoaisan.TextLength > 0)
            {
                if (!char.IsDigit(txtgialoaisan.Text[txtgialoaisan.TextLength - 1]))
                {
                    this.errorProvider1.SetError(txtgialoaisan, "Bạn phải nhập số lớn hơn 0");
                }
                else
                    this.errorProvider1.Clear();
            }
        }

        private void txtgialoaisan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '-'))
                e.Handled = true;
            if (e.KeyChar == '-')
            {
                int k = 0;
                for (int i = 0; i < txtgialoaisan.Text.Length; i++)
                {
                    if (txtgialoaisan.Text[i] == '-')
                        k++;
                }
                if (k == 0)
                    e.Handled = false;
                if (k == 1)
                    e.Handled = true;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
