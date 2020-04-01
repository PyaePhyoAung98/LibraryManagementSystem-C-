using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System_CUKTG_
{
    public partial class Home : Form
    {
        Add_New_Books ab; View_Books vb; Add_Students AddS; View_Students_Information vsi;
        Issue_Books ib; Return_Books rb; About about;
        public Home()
        {
            InitializeComponent();
        }

        private void addNewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
             ab = new Add_New_Books();
          
            ab.Visible=true;
            
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
             vb = new View_Books();
           
            vb.Show();
           
        }

        private void addStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
          AddS=new Add_Students();
        
           AddS.Show();
          
          

        }

        private void studentsInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
             vsi = new View_Students_Information();
             
            vsi.Show();
            
        }

        private void issueBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ib = new Issue_Books();
        
            ib.Show();
            
        }

       

        private void returnBooksToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rb = new Return_Books();
            
            rb.Show();
           
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about = new About();
         
            about.Show();
            
           
        }

        private void Home_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Home_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control==true && e.KeyCode==Keys.A)
            {
                addNewBooksToolStripMenuItem.PerformClick();
            }
            else if(e.Control==true && e.KeyCode==Keys.V)
            {
                viewBooksToolStripMenuItem.PerformClick();
            }
            else if (e.Control == true && e.KeyCode == Keys.B)
            {
                  issueBooksToolStripMenuItem.PerformClick();
            }
            else if (e.Control == true && e.KeyCode == Keys.R)
            {
                returnBooksToolStripMenuItem1.PerformClick();
            }
            else if (e.Control == true && e.KeyCode == Keys.Z)
            {
                
                Application.Exit();
            }
            else if (e.Control == true && e.KeyCode == Keys.S)
            {

               addStudentsToolStripMenuItem.PerformClick();
            }
            else if (e.Control == true && e.KeyCode == Keys.T)
            {
                studentsInfoToolStripMenuItem.PerformClick();
            }
        }

        private void eXITCtrlZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      /*  private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            View_borrow_Book vbb = new View_borrow_Book();
            vbb.MdiParent = this;
            vbb.Show();
            
        }*/
    }
}
