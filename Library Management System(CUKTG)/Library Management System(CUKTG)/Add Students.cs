using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
namespace Library_Management_System_CUKTG_
{
    public partial class Add_Students : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Acer\Documents\LMS.mdf;Integrated Security=True;Connect Timeout=30");
     
        public Add_Students()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       
           private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

       


          
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Add_Students_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open){
                con.Close();
            }
            con.Open();
        }

        private void saveBtn_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void SaveBtn_Click_2(object sender, EventArgs e)
        {
            try
            {
                string query = "insert into student_info values(@Student_Name,@Roll_No,@Contact,@Email)";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Student_Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Roll_NO", txtroll.Text);
                cmd.Parameters.AddWithValue("@Contact", Convert.ToInt32(txtcontact.Text));
                cmd.Parameters.AddWithValue("@Email", txtemail.Text);

                da.InsertCommand = cmd;
                da.InsertCommand.ExecuteNonQuery();
                MessageBox.Show("Sucesssful");

                txtcontact.Clear();
                txtemail.Clear();
                txtname.Clear();
                txtroll.Clear();
            }
            catch(Exception ex){
                MessageBox.Show("Please Enter Data");
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

  

        
    }
}
