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
namespace Library_Management_System_CUKTG_
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con =new SqlConnection( @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Acer\Documents\LMS.mdf;Integrated Security=True;Connect Timeout=30");
            string query = @"select password from login where password='"+txtcurrent.Text+"'";

            
            SqlDataAdapter da = new SqlDataAdapter(query,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count.ToString() == "1")
            {
                if (txtnew.Text == txtretype.Text)
                {
                    con.Open();
                    string pass = "update login set password='"+txtretype.Text+"' where password='"+txtcurrent.Text+"'";
                    SqlCommand cmd = new SqlCommand(pass,con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Password Changed");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("New password and Confirm should be same!");
                }
            }
            else
            {
                MessageBox.Show("Check your old password or enter data");
            }
            
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtcurrent.UseSystemPasswordChar = false;
                txtnew.UseSystemPasswordChar = false;
                txtretype.UseSystemPasswordChar = false;
              
            }
            else
            {
                txtcurrent.UseSystemPasswordChar = true;
                txtnew.UseSystemPasswordChar = true;
                txtretype.UseSystemPasswordChar = true;
             
            
            
            }
        }
    }
}
