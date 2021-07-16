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
public partial class Form1 : Form
{
   DataTable dt = new DataTable();
   public void LoadData()
   {
     SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;"+
         "Initial Catalog=online_tv;Integrated Security=SSPI;");
     SqlCommand cmd = new SqlCommand("SELECT movies.* FROM movies", conn);
     SqlDataAdapter sa = new SqlDataAdapter(cmd);
     conn.Open();
     sa.Fill(dt);
     conn.Close();
     sa.Dispose();
     cmd.Dispose();
     conn.Dispose();
   }

   public class MyMovie
   {
     public int id;
     public string title;
     public override string ToString()
     {
       return title;
     }
   }

   public void ShowMovies()
   {
     int i;
     for (i = 0; i < dt.Rows.Count; i++)
     {
       MyMovie movie = new MyMovie();
       movie.id = Convert.ToInt32(dt.Rows[i]["movie_id"]);
       movie.title = Convert.ToString(dt.Rows[i]["movie_title"]);

       listBox1.Items.Add(movie);
      }
    }
    public Form1()
    {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
       LoadData();
       ShowMovies();
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      int index = listBox1.SelectedIndex;
      string info = "";
      int i;
      if(dt.Rows.Count > 0 && index >= 0)
      {
        for (i = 0; i < dt.Columns.Count; i++)
        {
          info += dt.Columns[i].ColumnName + ": " + 
              dt.Rows[index][dt.Columns[i].ColumnName] + "\r\n";
        }
      }
        textBox1.Text=info;
    }
    public void ClearAll()
    {
      dt = new DataTable();
      listBox1.Items.Clear();
      textBox1.Text = "";
    }
    private void btn_Add_Click(object sender, EventArgs e)
    {
      Form2 dialog = new Form2();
      dialog.ShowDialog();

      ClearAll();
      LoadData();
      ShowMovies();
    }
    private void btn_Remove_Click(object sender, EventArgs e)
    {
      int index = listBox1.SelectedIndex;
      if (index >= 0)
      {
        string movie_id = dt.Rows[index][dt.Columns[0].ColumnName].ToString();
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;"+
            "Initial Catalog=online_tv;Integrated Security=SSPI;");
        SqlCommand cmd = new SqlCommand("DELETE FROM movies WHERE movie_id="+ 
            movie_id + ";", conn);
        conn.Open();
        cmd.ExecuteReader();
        conn.Close();
        cmd.Dispose();
        conn.Dispose();
        ClearAll();
        LoadData();
        ShowMovies();
      }
    }
}
}
