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
    public partial class FrmHeThong : Form
    {
        AccountController AccountControl = new AccountController();
 
        public FrmHeThong()
        {
            InitializeComponent();

        }

        private void FrmHeThong_Load(object sender, EventArgs e)
        {
            LoadAcc();
            cbbQuyen.SelectedIndex = 0;
        }
        public void LoadAcc()
        {
            try
            {
                dtgvQLTK_Show.AutoGenerateColumns = false;
                DataTable dtAc = new DataTable();
                dtAc = AccountControl.HienThiDuLieu();
                dtgvQLTK_Show.DataSource = dtAc;
                dtgvQLTK_Show.Columns[0].DataPropertyName = "UserName";
                dtgvQLTK_Show.Columns[1].DataPropertyName = "DisplayName";
                dtgvQLTK_Show.Columns[2].DataPropertyName = "PassWord";
                dtgvQLTK_Show.Columns[3].DataPropertyName = "Quyen";

            }
            catch
            {
                //MessageBox.Show("Lỗi");
            }
        }    

        private void dtgvShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvQLTK_Show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            try
            {
                numrow = e.RowIndex;
                txtUserName.Text = dtgvQLTK_Show.Rows[numrow].Cells[0].Value.ToString();
                txtDisplayName.Text = dtgvQLTK_Show.Rows[numrow].Cells[1].Value.ToString();
                txtPassWord.Text = dtgvQLTK_Show.Rows[numrow].Cells[2].Value.ToString();
                cbbQuyen.Text = dtgvQLTK_Show.Rows[numrow].Cells[3].Value.ToString();
            }
            catch
            {
                //MessageBox.Show("Thành Công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtgvQLTK_Show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private bool KTNhap()
        {
            if (txtUserName.TextLength == 0)
            {
                txtUserName.Focus();
                MessageBox.Show("Bạn chưa nhập tên tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtDisplayName.TextLength == 0)
            {
                txtDisplayName.Focus();
                MessageBox.Show("Bạn chưa nhập DisplayName!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtPassWord.TextLength == 0)
            {
                txtPassWord.Focus();
                MessageBox.Show("Bạn chưa nhập Password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
          
        }



        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dtgvQLTK_Show.AutoGenerateColumns = false;
                DataTable dtAc = new DataTable();
                dtAc = AccountControl.HienThiDuLieuTimKiem(txtSearchUser.Text);
                dtgvQLTK_Show.DataSource = dtAc;
                dtgvQLTK_Show.Columns[0].DataPropertyName = "UserName";
                dtgvQLTK_Show.Columns[1].DataPropertyName = "DisplayName";
                dtgvQLTK_Show.Columns[2].DataPropertyName = "PassWord";
                dtgvQLTK_Show.Columns[3].DataPropertyName = "Quyen";

            }
            catch
            {
                //MessageBox.Show("Lỗi");
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!KTNhap())
            {
                return;
            }

            if (AccountControl.KiemTraDuLieuAccount(txtUserName.Text))
            {
                MessageBox.Show("Tên tài khoản đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    AccountControl.ThemDuLieuAccount(txtUserName.Text, txtDisplayName.Text, txtPassWord.Text, cbbQuyen.Text);
                    MessageBox.Show("Thành công!");
                    LoadAcc();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (AccountControl.KiemTraDuLieuAccount(txtUserName.Text))
            {
                try
                {
                    AccountControl.XoaDuLieuAccount(txtUserName.Text);
                    LoadAcc();
                    MessageBox.Show("Xoá tài khoản " + txtUserName.Text + " thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex);
                }
            }
            else
            {
                MessageBox.Show("Không thể xoá tài khoản " + txtUserName.Text + " chưa tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (AccountControl.KiemTraDuLieuAccount(txtUserName.Text))
                {
                    try
                    {
                        AccountControl.SuaDuLieuAccount(txtUserName.Text, txtDisplayName.Text, txtPassWord.Text, cbbQuyen.Text);
                        MessageBox.Show("Thành công!");
                        LoadAcc();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex);
                    }
                }
                else
                {
                    MessageBox.Show("Tên tài khoản chưa đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearchUser.Text = "";
            txtUserName.Text = "";
            txtPassWord.Text = "";
            txtDisplayName.Text = "";
            txtUserName.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
                Application.Exit();
        }

        private void txtSearchUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
