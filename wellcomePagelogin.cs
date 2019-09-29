using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LksSofwareNews
{
    public partial class StudentNavigation : Form
    {
        public StudentNavigation()
        {
            InitializeComponent();
        }
        private String uname;
        public String Uname
        {
            get { return uname; }
            set { uname = value; }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            new FrmEditProfile().Show();
        }

        private void btnTeaching_Click(object sender, EventArgs e)
        {
            new FrmManageClass().Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            new FrmLogin().Show();
            this.Hide();
        }

        private void StudentNavigation_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome " + Uname;
        }
    }
}
