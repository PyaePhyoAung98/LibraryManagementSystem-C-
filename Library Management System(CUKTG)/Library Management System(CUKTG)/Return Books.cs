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
    public partial class Return_Books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Acer\Documents\LMS.mdf;Integrated Security=True;Connect Timeout=30");
        public Return_Books()
        {
            InitializeComponent();
        }

        private void Return_Books_Load(object sender, EventArgs e)
        {
           

           
            if(con.State==ConnectionState.Open){
                con.Close();
            }
            con.Open();
            try
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from borrow_info";
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
               
                dataGridView1.DataSource = dt;
            }
            catch
                (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

       

        private void Save_Click(object sender, EventArgs e)
        {
          
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Returnbook_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Acer\Documents\LMS.mdf;Integrated Security=True;Connect Timeout=30");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
           cmd.CommandText = "select * from borrow_info where Remarks='Returned' order by Return_Date";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            con.Close();
        }

        private void Save_Click_1(object sender, EventArgs e)
        {
           try
           {
                string query = @"update [borrow_info] set Return_Date=@Return_Date,Remarks=@Remarks where Book_Id=@bid";

                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                cmd.Parameters.AddWithValue("@bid",txtid.Text);
                cmd.Parameters.AddWithValue("@Remarks", "Returned");

                cmd.Parameters.AddWithValue("@Return_Date",dateTimePicker2.Value.ToString());

                da.UpdateCommand = cmd;

                da.UpdateCommand.ExecuteNonQuery();
                MessageBox.Show("Return Sucessful");
            
           }
            catch(Exception ex){
              MessageBox.Show(ex.Message);
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from borrow_info where Student_Roll='%" + textBox1.Text + "%'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
           
            dataGridView1.DataSource = dt;
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show("This Roll Number not Found");
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtstudentname.Text=dr["Student_Name"].ToString();
                    txtid.Text = dr["Book_Id"].ToString();
                    txtbookname.Text = dr["Book_Name"].ToString();
                }
            }
            
           
         
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from borrow_info where Student_Roll like('%" + textBox1.Text + "%')";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
                
            
            
          
        }

        private void vborrow_Click_1(object sender, EventArgs e)
        {
           
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from borrow_info where Remarks='Borrowed' order by Date";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
           dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow selectrow = dataGridView1.Rows[index];
            txtstudentname.Text = selectrow.Cells[0].Value.ToString();
         txtid.Text = selectrow.Cells[2].Value.ToString();
            txtbookname.Text = selectrow.Cells[3].Value.ToString();
           
        }
    }
}
