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
    public partial class View_Books : Form
    {
       
        int index;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Acer\Documents\LMS.mdf;Integrated Security=True;Connect Timeout=30");
      
        public View_Books()
        {
            InitializeComponent();
         
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
     /*   private void panel3_Paint(object sender, PaintEventArgs e)
        {
         
        } */

        private void View_Books_Load(object sender, EventArgs e)
        {
           con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from bookinfo";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
           
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


            index = e.RowIndex;
            DataGridViewRow selectrow = dataGridView1.Rows[index];
            bookid.Text = selectrow.Cells[0].Value.ToString();
            bookname.Text = selectrow.Cells[1].Value.ToString();
            bookauthor.Text = selectrow.Cells[2].Value.ToString();
            bookpublication.Text = selectrow.Cells[3].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(selectrow.Cells[4].Value.ToString());
            bookprice.Text = selectrow.Cells[5].Value.ToString();
            bookquantity.Text = selectrow.Cells[6].Value.ToString();

           
            
        } 

        private void button1_Click(object sender, EventArgs e)
        {
           
               
            }
      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        

        private void button3_Click(object sender, EventArgs e)
        { 
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
                con.Open();

                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from bookinfo where Author_Name like('%" + search_text.Text + "%')";
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                
           
            con.Close();
        }

        private void search_text_KeyUp(object sender, KeyEventArgs e)
        {

            con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from bookinfo where Author_Name like('%" + search_text.Text + "%')";
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            DataGridViewRow newDatarow = dataGridView1.Rows[index];
            newDatarow.Cells[0].Value = bookid.Text;
            newDatarow.Cells[1].Value = bookname.Text;
            newDatarow.Cells[2].Value = bookauthor.Text;
            newDatarow.Cells[3].Value = bookpublication.Text;
            newDatarow.Cells[4].Value = dateTimePicker1.Value.ToString();
            newDatarow.Cells[5].Value = bookprice.Text;
            newDatarow.Cells[6].Value = bookquantity.Text;
        }

      private void button4_Click(object sender, EventArgs e)
        {
        /*   MessageBox.Show("Delete","sure",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
           
                con.Open();
                string query = "delete from bookinfo where Id=@Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", bookid.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.DeleteCommand = cmd;
                da.DeleteCommand.ExecuteNonQuery();
               
                con.Close();
                bookauthor.Clear();
                bookname.Clear();
                bookid.Clear();
                bookprice.Clear();
                bookquantity.Clear();
                bookpublication.Clear();

         */
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();


        }
    }
        
     

    }

