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
 public partial class Form4 : Form
 {
  public void LoadFiles(DataGridView table)
  {
   SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BG3I6S7\SQLEXPRESS;" + 
       "Initial Catalog=files;Integrated Security=SSPI;");
   SqlCommand cmd = new SqlCommand("SELECT * from files", conn);
   SqlDataAdapter sa = new SqlDataAdapter(cmd);
   DataTable dt = new DataTable();
   conn.Open();
   sa.Fill(dt);
   conn.Close();
   sa.Dispose();
   cmd.Dispose();
   conn.Dispose();
   //table.DataSource = dt;
   //table.Columns["file_id"].Visible = false;
   //table.Columns["upload_user_id"].Visible = false;
  }
  public void Clear()
  {
   textBox1.Text = "";
   textBox2.Text = "";
   textBox3.Text = "";
   textBox4.Text = "";
   textBox5.Text = "";
  }

  public Form4()
  {
   InitializeComponent();
   LoadFiles(dataGridView1);
  }
     
  private void Form4_Load(object sender, EventArgs e)
  {
  }

  private void button1_Click(object sender, EventArgs e)
  {
   if (textBox1.Text != "" &&
       textBox2.Text != "" &&
       textBox3.Text != "" &&
       textBox4.Text != "")
   {
    SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BG3I6S7\SQLEXPRESS;" +
        "Initial Catalog=files;Integrated Security=SSPI;");
    string query = "INSERT INTO files " +
        "(file_name, file_size, file_type, upload_user_id)" +
         "values ('" + textBox1.Text +
         "', '" + textBox2.Text +
         "', '" + textBox3.Text +
         "', '" + textBox4.Text + "');";
    SqlCommand cmd = new SqlCommand(query, conn);
    conn.Open();
    cmd.ExecuteReader();
    conn.Close();
    cmd.Dispose();
    conn.Dispose();
    LoadFiles(dataGridView1);
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

  private void button2_Click(object sender, EventArgs e)
  {
   if (dataGridView1.SelectedRows.Count > 0)
   {
    if (textBox1.Text != "" &&
        textBox2.Text != "" &&
        textBox3.Text != "" &&
        textBox4.Text != "")
    {
     SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BG3I6S7\SQLEXPRESS;" +
         "Initial Catalog=files;Integrated Security=SSPI;");
     string query = "UPDATE files SET " +
            "file_name='" + textBox1.Text + "'," +
            "file_size='" + textBox2.Text + "'," +
            "file_type='" + textBox3.Text + "'," +
            "upload_user_id='" + textBox4.Text + "'" +
            "WHERE file_id='" + 
            dataGridView1.SelectedRows[0].Cells["file_id"].Value.ToString() + 
            "';";
     SqlCommand cmd = new SqlCommand(query, conn);
     conn.Open();
     cmd.ExecuteReader();
     conn.Close();
     cmd.Dispose();
     conn.Dispose();
     LoadFiles(dataGridView1);
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
  }
        
  private void button3_Click(object sender, EventArgs e)
  {
   if (dataGridView1.SelectedRows.Count > 0)
   {
    SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BG3I6S7\SQLEXPRESS;" +
        "Initial Catalog=files;Integrated Security=SSPI;");
    SqlCommand cmd = new SqlCommand("DELETE FROM files WHERE file_id=" + 
        dataGridView1.SelectedRows[0].Cells["file_id"].Value.ToString() + ";", conn);
    conn.Open();
    cmd.ExecuteReader();
    conn.Close();
    cmd.Dispose();
    conn.Dispose();
    LoadFiles(dataGridView1);
   }
  }

  private void dataGridView1_SelectionChanged(object sender, EventArgs e)
  {
   Clear();
   if (dataGridView1.SelectedRows.Count > 0)
   {
    textBox1.Text = dataGridView1.SelectedRows[0].Cells["file_name"].Value.ToString();
    textBox2.Text = dataGridView1.SelectedRows[0].Cells["file_size"].Value.ToString();
    textBox3.Text = dataGridView1.SelectedRows[0].Cells["file_type"].Value.ToString();
    textBox4.Text = dataGridView1.SelectedRows[0].Cells["upload_user_id"].Value.ToString();
    textBox5.Text = dataGridView1.SelectedRows[0].Cells["file_id"].Value.ToString();
   }
  }

  private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
