using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebUI_2
{
    public partial class Reporte4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void LoadFactura()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PaintingStore"].ConnectionString))
            {
                if (TextBox1.Text == "")
                {
                    Panel1.Visible = true;
                }
                else
                {
                    Panel1.Visible = false;
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Reporte4";
                    cmd.Parameters.Add("@TEMPID", System.Data.SqlDbType.VarChar).Value = TextBox1.Text.Trim();
                    cmd.Connection = conn;
                    conn.Open();
                    ContentGrid1.DataSource = cmd.ExecuteReader();
                    ContentGrid1.DataBind();
                }
            }
        }

        public void LoadDetailFactura()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PaintingStore"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "Reporte4_1";
                cmd.Parameters.Add("@TEMPID", System.Data.SqlDbType.VarChar).Value = TextBox1.Text.Trim();
                cmd.Connection = conn;
                conn.Open();
                GridView2.DataSource = cmd.ExecuteReader();
                GridView2.DataBind();
            }
        }

        public void LoadPayFactura()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PaintingStore"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "Reporte4_2";
                cmd.Parameters.Add("@TEMPID", System.Data.SqlDbType.VarChar).Value = TextBox1.Text.Trim();
                cmd.Connection = conn;
                conn.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LoadFactura();
            LoadDetailFactura();
            LoadPayFactura();
        }
    }
}