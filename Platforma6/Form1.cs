using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Platforma6
{
    public partial class Form1 : Form
{
   DataTable dt = new DataTable();
   public void LoadData()
   {
     SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BG3I6S7\SQLEXPRESS;" +
         "Initial Catalog=online_tv;Integrated Security=true;");
     SqlCommand cmd = new SqlCommand("SELECT * FROM online_tv", conn);
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
       movie.id = Convert.ToInt32(dt.Rows[i][6]);
       movie.title = Convert.ToString(dt.Rows[i][0]);

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
      //int index = listBox1.SelectedIndex;
      string nume = listBox1.SelectedItem.ToString();
      if (nume!="")
      {
        //string movie_id = dt.Rows[index][dt.Columns[0].ColumnName].ToString();
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-BG3I6S7\SQLEXPRESS;" +
            "Initial Catalog=online_tv;Integrated Security=true;");
        SqlCommand cmd = new SqlCommand("DELETE FROM online_tv WHERE movie_title ='"+ 
            nume + "';", conn);
        conn.Open();
        //cmd.ExecuteReader();
        cmd.ExecuteNonQuery();
        conn.Close();
        cmd.Dispose();
        conn.Dispose();
        ClearAll();
        LoadData();
        ShowMovies();
      }
    }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
