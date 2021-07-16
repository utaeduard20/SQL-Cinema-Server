using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Platforma6
{
 public partial class Form2 : Form
 {
   public Form2()
   {
     InitializeComponent();
   }

   private void btn_OK_Click(object sender, EventArgs e)
   {
     if (textBox1.Text != "" && 
       textBox2.Text != "" && 
       textBox3.Text != "" && 
       textBox4.Text != "" && 
       textBox5.Text != "" && 
       textBox6.Text != "")
     {
       SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;"+
           "Initial Catalog=online_tv;Integrated Security=SSPI;");
       string query = "INSERT INTO movies " +
                    "(movie_title, movie_date_add, movie_file_name,"+
                    " movie_length_seconds, movie_width, movie_height, movie_upload_user_id) " +
                    "values ('" + textBox1.Text + 
                    "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") +
                    "', '" + textBox2.Text +
                    "', '" + textBox3.Text +
                    "', '" + textBox4.Text +
                    "', '" + textBox5.Text +
                    "', '" + textBox6.Text + "');";
       SqlCommand cmd = new SqlCommand(query,conn);
       conn.Open();
       cmd.ExecuteReader();
       conn.Close();
       cmd.Dispose();
       conn.Dispose();
       this.Close();
     }
     else
     {
       MessageBox.Show("Introduceti date in toate campurile!",
                       "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button1);
     }
   }

   private void btn_Cancel_Click(object sender, EventArgs e)
   {
     this.Close();
   }

   private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
   {
     if (!char.IsControl(e.KeyChar)
         && !char.IsDigit(e.KeyChar))
     {
       e.Handled = true;
     }
   }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
