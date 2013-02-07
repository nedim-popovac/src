using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace KMWeb
{
    public partial class ArticleView : System.Web.UI.Page
    {
        static string connStr = ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
        SqlConnection connection = new SqlConnection(connStr);
        protected void Page_Load(object sender, EventArgs e)
        {
            string Article = Request.QueryString["ArticleId"];

            DataSet ds = new DataSet();
            connection.Open();
            SqlCommand cmd = new SqlCommand("Select Id,Naslov,Sadrzaj,DatumKreiranja from Clanci where Id=" + Article, connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtNaslov.Text = reader["Naslov"].ToString();
                txtSadrzaj.Text = reader["Sadrzaj"].ToString();
                txtDate.Text = reader["DatumKreiranja"].ToString();
                /*TextBox3.Text = reader["BRANCH"].ToString();
                TextBox4.Text = reader["ADDRESS"].ToString();
                TextBox5.Text = reader["PHNO"].ToString();
                TextBox6.Text = reader["STATE"].ToString();*/
                reader.Close();
                connection.Close();
            }



            /*DataTable dt = new DataTable();
            dt.Columns.Add("Naslov", typeof(string));
            dt.Columns.Add("Sadrzaj", typeof(string));
            //dt.Columns.Add("amount", typeof(int));

            da.Fill(ds, "Clanci");
            dt = ds.Tables[0];
            //da.Update(ds);*/

        }

        
    }
}