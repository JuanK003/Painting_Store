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
    public partial class Reporte5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }
        public void LoadProducts()
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PaintingStore"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "Repoorte5";
                cmd.Connection = conn;
                conn.Open();
                ContentGrid1.DataSource = cmd.ExecuteReader();
                ContentGrid1.DataBind();
            }
        }
    }
}