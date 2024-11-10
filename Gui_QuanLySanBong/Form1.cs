using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLySanBong
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        string username1 = "", display1 = "", pass1 = "", quyen1 = "";
        public Form1()
        {
            InitializeComponent();
            random = new Random();
            this.Text = string.Empty;
            this.ControlBox = false;
        }

        public Form1(string username1, string display1, string pass1, string quyen1)
        {
            InitializeComponent();
            this.username1 = username1;
            this.display1 = display1;
            this.pass1 = pass1;
            this.quyen1 = quyen1;
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (panelMenu.Width == 250)
            {
                panelMenu.Width = 70;
            }
            else
                panelMenu.Width = 250;
        }

        private void iconcerrar_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
                Application.Exit();
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconrestaurar.Visible = true;
            iconmaximizar.Visible = false;
        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconrestaurar.Visible = false;
            iconmaximizar.Visible = true;
        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }

        private void AbrirFormEnPanel(object Formhijo)
        {
            if (this.panelDesktopPane.Controls.Count > 0)
                this.panelDesktopPane.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelDesktopPane.Controls.Add(fh);
            this.panelDesktopPane.Tag = fh;
            fh.Show();
        }
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelDesktopPane.BackColor = color;
                    panelTitleBar.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
            lblxinchao.Text =  display1 + "";
            if (quyen1 == "Admin")
            {
                btnHeThong.Visible = true;
           

            }
            else if (quyen1 == "User")
            {
                btnHeThong.Visible = false;
            }

        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            panelDesktopPane.Controls.Clear();
            FrmHeThong f = new FrmHeThong();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panelDesktopPane.Controls.Add(f);
            f.Show();
        }

        private void btnDatSan_Click(object sender, EventArgs e)
        {
            panelDesktopPane.Controls.Clear();
            FrmDatSan f = new FrmDatSan();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panelDesktopPane.Controls.Add(f);
            f.Show();
        }


        private void btnQuanLySan_Click(object sender, EventArgs e)
        {
            panelDesktopPane.Controls.Clear();
            FrmQuanLySan f = new FrmQuanLySan();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panelDesktopPane.Controls.Add(f);
            f.Show();
        }

        private void btnQuanLyKinhDoanh_Click(object sender, EventArgs e)
        {
            panelDesktopPane.Controls.Clear();
            FrmQuanLyKinhDoanh f = new FrmQuanLyKinhDoanh();
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            panelDesktopPane.Controls.Add(f);
            f.Show();
        }

        private void btnBaoCaoThongKe_Click(object sender, EventArgs e)
        {
            
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn đăng xuất không?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                this.Visible = false;
                FrmLogin login = new FrmLogin();
                login.Show();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }
        private void Reset()
        {
            DisableButton();
            lblTitle.Text = "HOME";
            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            btnlogo.BackColor = Color.FromArgb(39, 39, 58);
            currentButton = null;
            btnCloseChildForm.Visible = false;
        }

        private void btnlogo_Click(object sender, EventArgs e)
        {

        }
    }
}
