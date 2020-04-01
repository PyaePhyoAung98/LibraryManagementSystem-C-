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
    public partial class Issue_Books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Acer\Documents\LMS.mdf;Integrated Security=True;Connect Timeout=30");
        public Issue_Books()
        {
            InitializeComponent();
         
        }

     
      

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

       
        

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                string query = "insert into borrow_info values(@Student_Name,@Studnet_Roll,@Book_Id,@Book_Name,@Author_Name,@Book_Borrow_Date,@Remarks,@Return_Date)";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@Student_Name",txtname.Text);
               cmd.Parameters.AddWithValue("@Studnet_Roll",txtroll.Text);
                cmd.Parameters.AddWithValue("@Book_Id", txtid.Text);
                cmd.Parameters.AddWithValue("@Book_Name", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Author_Name",txtauthorname.Text);
                cmd.Parameters.AddWithValue("@Book_Borrow_Date", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@Remarks","Borrowed");
                cmd.Parameters.AddWithValue("@Return_Date","No Return");
                da.InsertCommand = cmd;
                da.InsertCommand.ExecuteNonQuery(); 
                MessageBox.Show("Borrow Susseful");
              
                txtid.Clear();
                txtname.Clear();
                txtroll.Clear();
                txtauthorname.Clear();
            }
            catch(Exception exx){
                MessageBox.Show(exx.Message);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Issue_Books_Load(object sender, EventArgs e)
        {
            if(con.State==ConnectionState.Open){
                con.Close();
            } con.Open();
            try
            {
                
                comboBox1.Items.Clear();
                string query = "select Book_Name from bookinfo ";
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    comboBox1.Items.Add(dr["Book_Name"].ToString());
                }
            }
            catch(Exception ea){
                MessageBox.Show(ea.ToString());
            }
           
            
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }



        private void searchbtn_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from student_info where Roll_No='" + txtsearch.Text + "'" ;
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    MessageBox.Show("This Roll Number not Found");
                }
                else
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        txtname.Text = dr["Student_Name"].ToString();
                        txtroll.Text = dr["Roll_No"].ToString();
                    }
                }
            }
            catch(Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtbookname_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            SqlCommand cmdd = con.CreateCommand();
            cmdd.CommandType = CommandType.Text;
            cmdd.CommandText = "select * from bookinfo where Book_Name='" + comboBox1.Text + "'";
            cmdd.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmdd.ExecuteReader();
            while(dr.Read())
            {
                string id=(string)dr["Id"].ToString();
                txtid.Text = id;
                string author=(string)dr["Author_Name"].ToString();
                txtauthorname.Text = author;
            }

            dr.Close();
            
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
            
        }
    }
}
