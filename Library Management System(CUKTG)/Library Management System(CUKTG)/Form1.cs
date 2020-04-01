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
using System.Threading;
namespace Library_Management_System_CUKTG_
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Acer\Documents\LMS.mdf;Integrated Security=True;Connect Timeout=30");
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(Splash));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }

        private void Splash()
        {
            Application.Run(new Loadind_Form());
            throw new NotImplementedException();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string query = "select * from login where username='" + comboBox1.Text.Trim() + "' and password='" + textBox2.Text.Trim() + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Wrong username or password");
            }
            else
            {
                this.Hide();
                Home home = new Home();
                home.Show();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ChangePassword change = new ChangePassword();
            change.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmdd = con.CreateCommand();
            cmdd.CommandType = CommandType.Text;
            cmdd.CommandText = "select * from login where username='" + comboBox1.Text + "'";

            cmdd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmdd.ExecuteReader();
            while (dr.Read())
            {
                string id = (string)dr["username"].ToString();
                comboBox1.Text = id;

            }

            dr.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            } con.Open();
            try
            {

                comboBox1.Items.Clear();
                string query = "select username from login ";
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add(dr["username"].ToString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
