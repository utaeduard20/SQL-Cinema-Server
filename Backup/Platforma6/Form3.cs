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
 public partial class Form3 : Form
  {
   public void FillCbUsers(ComboBox cbTemp)
   {
     SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;" +
        "Initial Catalog=online_tv;Integrated Security=SSPI;");
     SqlCommand sqlcmd = new SqlCommand("SELECT user_id, user_name from users order by user_name", conn);            
     SqlDataAdapter sa = new SqlDataAdapter(sqlcmd);        
     DataTable dt = new DataTable();
     conn.Open();
     sa.Fill(dt);
     conn.Close();
     sa.Dispose();
     sqlcmd.Dispose();
     conn.Dispose();
     try
     {
      cbTemp.DataSource = dt;
      cbTemp.DisplayMember = "user_name";
      cbTemp.ValueMember = "user_id";
      cbTemp.SelectedIndex = -1;
      cbTemp.Text = "nume";
     }
     catch (Exception ex)
     {
      MessageBox.Show(ex.Message);
     }
   }
   public void Clear()
   {
    textBox1.Text = "";
    textBox2.Text = "";
    textBox3.Text = "";
    textBox4.Text = "";
    dateTimePicker1.Value = DateTime.Today;
   }
   public Form3()
   {
    InitializeComponent();
            
    FillCbUsers(comboBox1);
   }
   private void Form3_Load(object sender, EventArgs e)
        {
            
        }

   private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
   {
    if(comboBox1.SelectedIndex > -1)
    {
     SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;" + 
         "Initial Catalog=online_tv;Integrated Security=SSPI;");
     SqlCommand sqlcmd = new SqlCommand("SELECT * FROM users WHERE user_id='" + 
         comboBox1.SelectedValue.ToString() + "'", conn);
     SqlDataAdapter sa = new SqlDataAdapter(sqlcmd);
     DataTable dt = new DataTable();
     conn.Open();
     sa.Fill(dt);
     conn.Close();
     sa.Dispose();
     sqlcmd.Dispose();
     conn.Dispose();
     textBox1.Text = Convert.ToString(dt.Rows[0]["user_name"]);
     textBox2.Text = Convert.ToString(dt.Rows[0]["user_pass"]);
     dateTimePicker1.Value = Convert.ToDateTime(dt.Rows[0]["user_register_date"]);
     textBox3.Text = Convert.ToString(dt.Rows[0]["user_country_code"]);
     textBox4.Text = Convert.ToString(dt.Rows[0]["user_id"]);
    }
   }

   private void button1_Click(object sender, EventArgs e)
   {
    if (textBox1.Text != "" &&
        textBox2.Text != "" &&
        textBox3.Text != "")
    {
     SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;" + 
         "Initial Catalog=online_tv;Integrated Security=SSPI;");
     string query = "INSERT INTO users " + 
               "(user_name, user_pass, user_register_date, user_country_code)" +
               "values ('" + textBox1.Text +
                "', '" + textBox2.Text +
                "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") +
                "', '" + textBox3.Text + "');";
     SqlCommand cmd = new SqlCommand(query, conn);
     conn.Open();
     cmd.ExecuteReader();
     conn.Close();
     cmd.Dispose();
     conn.Dispose();
     FillCbUsers(comboBox1);
     Clear();
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
    if (comboBox1.SelectedIndex > -1)
    {
     if (textBox1.Text != "" &&
         textBox2.Text != "" &&
         textBox3.Text != "")
     {
      SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;" + 
          "Initial Catalog=online_tv;Integrated Security=SSPI;");
      string query = "UPDATE users SET " +
            "user_name='" + textBox1.Text + "'," +
            "user_pass='" + textBox2.Text + "'," +
            "user_register_date='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'," +
            "user_country_code='" + textBox3.Text + "'" +
            "WHERE user_id='" + comboBox1.SelectedValue.ToString() + "';";
            SqlCommand cmd = new SqlCommand(query, conn);
      conn.Open();
      cmd.ExecuteReader();
      conn.Close();
      cmd.Dispose();
      conn.Dispose();
      FillCbUsers(comboBox1);
      Clear();
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
    if (comboBox1.SelectedIndex > -1)
    {
     SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;" + 
         "Initial Catalog=online_tv;Integrated Security=SSPI;");
     SqlCommand cmd = new SqlCommand("DELETE FROM users WHERE user_id=" + 
         comboBox1.SelectedValue.ToString() + ";", conn);
     conn.Open();
     cmd.ExecuteReader();
     conn.Close();
     cmd.Dispose();
     conn.Dispose();
     FillCbUsers(comboBox1);
     Clear();
    }
   }

    }
}
