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
    public partial class Reporte2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void LoadTotalProducts()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PaintingStore"].ConnectionString))
            {
                if (TextBox1.Text == "" || TextBox2.Text == "")
                {
                    Panel1.Visible = true;
                }
                else
                {
                    Panel1.Visible = false;
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Reporte2";
                    cmd.Parameters.Add("@fechainicio", System.Data.SqlDbType.DateTime).Value = TextBox1.Text;
                    cmd.Parameters.Add("@fechafin", System.Data.SqlDbType.DateTime).Value = TextBox2.Text;
                    cmd.Connection = conn;
                    conn.Open();
                    ContentGrid2.DataSource = cmd.ExecuteReader();
                    ContentGrid2.DataBind();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LoadTotalProducts();
        }
    }
}