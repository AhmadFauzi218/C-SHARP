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
        private String user;
        private void getTheName(String username)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=ACER-PC\SQLEXPRESS;Initial Catalog=DB_Lks_Latihan;Integrated Security=True";
            String query = "SELECT Username AS a FROM tbl_User WHERE Username = @Username";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.ExecuteScalar();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    user = rdr["a"].ToString();
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                con.Close();
            }
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
                     
                        TeacherNavigation fm = new TeacherNavigation();
                        this.getTheName(txtUsername.Text);
                        fm.Uname = user.Trim();
 
                        fm.Show();
                  
                    }
                    else if (dt.Rows[i]["Role"].ToString() == "Student")
                    {
                        StudentNavigation st = new StudentNavigation();
                        this.getTheName(txtUsername.Text);
                        st.Uname = user.Trim();
                        st.Show();
                    }
                    else if (dt.Rows[i]["Role"].ToString() == "Admin")
                    {
                        AdminNavigation adm = new AdminNavigation();
                        this.getTheName(txtUsername.Text);
                        adm.Uname = user.Trim();
                        adm.Show();
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
