namespace GUI_QuanLySanBong
{
    partial class Form_Alert1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Alert1));
            this.lblMsg = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);

            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            //this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.ForeColor = System.Drawing.Color.White;
            this.lblMsg.Location = new System.Drawing.Point(65, 22);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(263, 23);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "Message Text";
            //this.lblMsg.Click += new System.EventHandler(this.lblMsg_Click);
            // 
            // timer1
            // 
            //this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gunaElipse1

            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GUI_QuanLySanBong.Properties.Resources.icons8_cancel_25px2;
            this.pictureBox2.Location = new System.Drawing.Point(352, 22);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(26, 30);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            //this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // Form_Alert1
            // 
            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            //this.BackColor = System.Drawing.SystemColors.Highlight;
            //this.ClientSize = new System.Drawing.Size(386, 74);
            //this.Controls.Add(this.pictureBox2);
            //this.Controls.Add(this.pictureBox1);
            //this.Controls.Add(this.lblMsg);
            //this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //this.Name = "Form_Alert1";
            //this.Text = "Form_Alert";
            //this.Load += new System.EventHandler(this.Form_Alert_Load);
            //((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            //this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.PictureBox pictureBox1;
        internal System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox2;

    }
}