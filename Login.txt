using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace LksSofwareNews
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=ACER-PC\SQLEXPRESS;Initial Catalog=DB_Lks_Latihan;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tbl_User WHERE Username='" + txtUsername.Text + "' AND Password = '" + txtPassword.Text + "'",con);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Role"].ToString() == "Teacher")
                    {
                        new TeacherNavigation().Show();
                    }
                    else if (dt.Rows[i]["Role"].ToString() == "Student")
                    {
                        new StudentNavigation().Show();
                    }
                    else if (dt.Rows[i]["Role"].ToString() == "Admin")
                    {
                        new AdminNavigation().Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Login");
                    }

                }

            }
            else
            {
                MessageBox.Show("Invalid Login");
            }

            con.Close();
        }
        
    }
}
