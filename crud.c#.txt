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

namespace DataSiswa
{
    public partial class Form1 : Form
    {
        public string idterpilih;
        SqlConnection koneksi = new SqlConnection(DataSiswa.Properties.Resources.Koneksi.ToString());
        public SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
            tampildata();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tampildata()
        {
            SqlDataAdapter DA = new SqlDataAdapter("select * from siswa", koneksi);
            DataSet DS = new DataSet();
            DA.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void refresh()
        {
            koneksi.Close();
            tampildata();
            txtCari.Clear();
            txtNama.Clear();
            txtKelas.Clear();
        }

        private void tambah()
        {
            koneksi.Open();
            cmd = new SqlCommand("insert into siswa values('" + txtNis.Text + "','" + txtNama.Text + "','" + txtKelas.Text + "')", koneksi);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Anda Berhasil Menambahkan Data Baru", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void ubah()
        {
            koneksi.Open();
            cmd = new SqlCommand("update siswa set nis='" + txtNis.Text + "', nama='" + txtNama.Text + "', kelas='" + txtKelas.Text + "' where id='" + idterpilih + "'", koneksi);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Anda berhasil mengubah data", "informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void hapus()
        {
            koneksi.Open();
            cmd = new SqlCommand("delete from siswa where id='" + idterpilih + "'", koneksi);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Anda berhasil menghapus data ", "informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cari()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from siswa where nama LIKE '%'" + txtCari.Text + "'%'", koneksi);
            DataSet DS = new DataSet();
            da.Fill(DS);
            dataGridView1.DataSource = DS.Tables[0];
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex; 
            idterpilih = dataGridView1.Rows[row].Cells[0].Value.ToString();
            txtNis.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
            txtNama.Text = dataGridView1.Rows[row].Cells[2].Value.ToString();
            txtKelas.Text = dataGridView1.Rows[row].Cells[3].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cari();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tambah();
            refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ubah();
            refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hapus();
            refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
