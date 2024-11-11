using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using GUI_QuanLySanBong.Model;
using GUI_QuanLySanBong.Properties;

namespace GUI_QuanLySanBong
{
    public partial class FrmLogin : Form
    {
        KetNoi kn = new KetNoi();
        SqlConnection con;
      
        string[] location = new string[25];
        public FrmLogin()
        {
            InitializeComponent();
            
        }
        //public void Alert(string msg, Form_Alert1.enmType type)
        //{
        //    Form_Alert1 frm = new Form_Alert1();
        //    frm.showAlert(msg, type);
        //}
        //private void tounage()
        //{
        //    for (int i = 0; i < 24; i++)
        //    {
        //        if (i > 0)
        //        {
        //            Bitmap bitmap = new Bitmap(Resources.textbox_user_1);
        //            images.Add(bitmap);
        //            Bitmap bitmap2 = new Bitmap(Resources.textbox_user_2);
        //            images.Add(bitmap2);
        //            Bitmap bitmap3 = new Bitmap(Resources.textbox_user_3);
        //            images.Add(bitmap3);
        //            Bitmap bitmap4 = new Bitmap(Resources.textbox_user_4);
        //            images.Add(bitmap4);
        //            Bitmap bitmap5 = new Bitmap(Resources.textbox_user_5);
        //            images.Add(bitmap5);
        //            Bitmap bitmap6 = new Bitmap(Resources.textbox_user_6);
        //            images.Add(bitmap6);
        //            Bitmap bitmap7 = new Bitmap(Resources.textbox_user_7);
        //            images.Add(bitmap7);
        //            Bitmap bitmap8 = new Bitmap(Resources.textbox_user_8);
        //            images.Add(bitmap8);
        //            Bitmap bitmap9 = new Bitmap(Resources.textbox_user_9);
        //            images.Add(bitmap9);
        //            Bitmap bitmap10 = new Bitmap(Resources.textbox_user_10);
        //            images.Add(bitmap10);
        //            Bitmap bitmap11 = new Bitmap(Resources.textbox_user_11);
        //            images.Add(bitmap11);
        //            Bitmap bitmap12 = new Bitmap(Resources.textbox_user_12);
        //            images.Add(bitmap12);
        //            Bitmap bitmap13 = new Bitmap(Resources.textbox_user_13);
        //            images.Add(bitmap13);
        //            Bitmap bitmap14 = new Bitmap(Resources.textbox_user_14);
        //            images.Add(bitmap14);
        //            Bitmap bitmap15 = new Bitmap(Resources.textbox_user_15);
        //            images.Add(bitmap15);
        //            Bitmap bitmap16 = new Bitmap(Resources.textbox_user_16);
        //            images.Add(bitmap16);
        //            Bitmap bitmap17 = new Bitmap(Resources.textbox_user_17);
        //            images.Add(bitmap17);
        //            Bitmap bitmap18 = new Bitmap(Resources.textbox_user_18);
        //            images.Add(bitmap18);
        //            Bitmap bitmap19 = new Bitmap(Resources.textbox_user_19);
        //            images.Add(bitmap19);
        //            Bitmap bitmap20 = new Bitmap(Resources.textbox_user_20);
        //            images.Add(bitmap20);
        //            Bitmap bitmap21 = new Bitmap(Resources.textbox_user_21);
        //            images.Add(bitmap21);
        //            Bitmap bitmap22 = new Bitmap(Resources.textbox_user_22);
        //            images.Add(bitmap22);
        //            Bitmap bitmap23 = new Bitmap(Resources.textbox_user_23);
        //            images.Add(bitmap23);
        //            Bitmap bitmap24 = new Bitmap(Resources.textbox_user_24);
        //            images.Add(bitmap24);

        //        }
        //    }
        //    images.Add(Properties.Resources.textbox_password);
        //}
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            con = kn.conDB();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Account where UserName='" + txtUserName.Text + "'and Password='" + txtPassWord.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
           
            try
            {
                if (dt.Rows.Count > 0)
                {
                    this.Hide();
                    Form1 fmain = new Form1(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString());
                    fmain.Show();
                    MessageBox.Show("Đăng Nhập thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Alert("Xin chào " + txtUserName.Text + "", Form_Alert1.enmType.Success);

                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch
            {
                MessageBox.Show("Không thể kết nối Server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
            con.Close();

        }
       
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        // rồi đó
        

        //private void txtUserName_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtUserName.Text.Length > 0 && txtUserName.Text.Length <= 15)
        //    {
        //        pictureBox1.Image = images[txtUserName.Text.Length - 1];
        //        pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
        //    }
        //    else if (txtUserName.Text.Length <= 0)
        //        pictureBox1.Image = Properties.Resources.debut;
        //    else
        //        pictureBox1.Image = images[22];
        //}

        //private void txtPassWord_Click(object sender, EventArgs e)
        //{
        //    Bitmap bmpass = new Bitmap(Resources.textbox_password);
        //    pictureBox1.Image = bmpass;
        //}

        private void txtPassWord_TextChanged(object sender, EventArgs e)
        {

        }

        //private void txtUserName_Click(object sender, EventArgs e)
        //{
        //    if (txtUserName.Text.Length > 0)
        //        pictureBox1.Image = images[txtUserName.Text.Length - 1];
        //    else
        //        pictureBox1.Image = Properties.Resources.debut;

        //}

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                con = kn.conDB();
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select * from Account where UserName='" + txtUserName.Text + "'and Password='" + txtPassWord.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        this.Hide();
                        Form1 fmain = new Form1(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString());
                        fmain.Show();
                        MessageBox.Show("Đăng Nhập thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Alert("Xin chào " + txtUserName.Text + "", Form_Alert1.enmType.Success);

                    }
                    else
                    {
                        MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch
                {
                    MessageBox.Show("Không thể kết nối Server", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                con.Close();
            }
        }
    }
}
