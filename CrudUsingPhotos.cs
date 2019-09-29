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
using System.Globalization;
using System.Text.RegularExpressions;
using System.IO;


namespace CrudTutor
{
    public partial class Form1 : Form
    {
        SqlConnection koneksi = new SqlConnection(@"Data Source=ACER-PC\SQLEXPRESS;Initial Catalog=db_CrudTutor;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
            display_data();
            clear();
        }
        string jenis_kelamin;
        string imgLocation = "";
        SqlCommand cmd;


        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            jenis_kelamin = "Pria";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {


        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            byte[] images = null;
            FileStream streem = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(streem);
            images = brs.ReadBytes((int)streem.Length);
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into [tbl_Siswa] (NIs,Nama,Kelas,Jurusan,Tempat_lahir,Tanggal_lahir,jenis_kelamin,Alamat,Foto) values ('" + txt_Nis.Text + "','"
                + txt_Nama.Text + "','" + txt_Kelas.Text + "','" + txt_Jurusan.Text + "','"
                + txt_Tempat.Text + "','" + dt_Tanggal.Text + "','" + jenis_kelamin + "','" 
                + txt_Alamat.Text + "',@images)";
            cmd.Parameters.Add(new SqlParameter("@images", images));
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Data Berhasil Disimpan ");
            display_data();
            
        }

        private void CWanita_CheckedChanged(object sender, EventArgs e)
        {
            jenis_kelamin = "Wanita";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|all files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;

            }
        }
        public void display_data()
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from [tbl_Siswa]";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter datadp = new SqlDataAdapter(cmd);
            datadp.Fill(dta);
            dataGridView1.DataSource = dta;
            koneksi.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from [tbl_Siswa] where Nis = '" + txt_Nis.Text + "'";
            cmd.ExecuteNonQuery();
            koneksi.Close();
            MessageBox.Show("Delete Data Sukses");
            display_data();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            byte[] images = null;
            FileStream streem  = new FileStream(imgLocation,FileMode.Open,FileAccess.Read);
            BinaryReader brs = new BinaryReader(streem);
            images = brs.ReadBytes((int)streem.Length);
            koneksi.Open();
            SqlCommand cmd = koneksi.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update [tbl_Siswa] set Nis='" + this.txt_Nis.Text + "', Nama='" + this.txt_Nama.Text + "' ,kelas='"
                + this.txt_Kelas.Text + "', Jurusan='" + this.txt_Jurusan.Text + "' ,Tempat_lahir ='"
                + this.txt_Tempat.Text + "' ,Tanggal_lahir='" + this.dt_Tanggal.Text + "',jenis_kelamin='" + jenis_kelamin + "',Alamat='" + this.txt_Alamat.Text + "',Foto=@images where Nis ='"+this.txt_Nis.Text+"'";
            cmd.Parameters.Add(new SqlParameter("@images",images));

            cmd.ExecuteNonQuery();
            koneksi.Close();
            display_data();
            MessageBox.Show("Data Berhasil");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            txt_Nis.Text = dataGridView1.Rows[row].Cells[0].Value.ToString();
            txt_Nama.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            txt_Kelas.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
            txt_Jurusan.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();
            txt_Tempat.Text = dataGridView1.Rows[row].Cells[4].Value.ToString();
            dt_Tanggal.Text = dataGridView1.Rows[row].Cells[5].Value.ToString();
            jenis_kelamin= dataGridView1.Rows[row].Cells[6].Value.ToString();
            txt_Alamat.Text = dataGridView1.Rows[row].Cells[7].Value.ToString();
        }
        public void clear()
        {
            txt_Nis.Text = "";
            txt_Nama.Text = "";
            txt_Kelas.Text = "";
            txt_Jurusan.Text = "";
            txt_Tempat.Text = "";
            dt_Tanggal.Text = "";
            jenis_kelamin = "";
            txt_Alamat.Text = "";

        }

    }
}
