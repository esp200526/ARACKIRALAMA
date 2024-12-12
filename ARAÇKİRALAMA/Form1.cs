using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ARAÇKİRALAMA
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Server=.;Database=ARAÇKİRALAMADB;Integrated Security=True;");
        SqlCommand cmd;
        SqlDataAdapter da;
        void temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            comboBox1.Text = "";
            pictureBox1.ImageLocation = "";
        }
        void listele()
        {
            try
            {
                con.Open();
                da = new SqlDataAdapter("SELECT * FROM ARABALAR", con);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri listelenirken hata oluştu: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cmd = new  SqlCommand(" insert into ARABALAR (plaka, marka, model, uretimYili, km, renk, yakitTuru, kiraUcreti, durum, resim) values ('"+ textBox1.Text  + "', '"+ textBox2.Text  +"','"+ textBox3.Text  +"','"+ int.Parse(textBox4.Text)  +"','"+ int.Parse(textBox5.Text)  +"','"+ textBox6.Text  +"','"+ textBox7.Text  +"','"+ int.Parse(textBox8.Text)  + "','"+ comboBox1.Text  + "', '"+ pictureBox1.ImageLocation  +"'  )", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("kayit eklendi " );
            listele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofl= new OpenFileDialog();
            ofl.Filter = "Resim dosyalari |*.jpg;  *.png; *.tif; | Tum dosyalar |*.*";
            ofl.ShowDialog();
            pictureBox1.ImageLocation = ofl.FileName;


        }
    }
}
