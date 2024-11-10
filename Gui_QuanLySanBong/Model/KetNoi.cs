using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace GUI_QuanLySanBong.Model
{
    class KetNoi

    {
        public SqlConnection conDB()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-59558V0C\SQLEXPRESS;Initial Catalog=QuanLySanBong;Integrated Security=True");
            return con;
        }
    }
}
        