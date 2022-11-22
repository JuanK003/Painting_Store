using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ConecctionDB
    {
        static private string connectionString = "Server=(LocalDB)\\MSSQLLocalDB; DataBase=C:\\USERS\\ACER\\SOURCE\\REPOS\\PAINTING_STORE - COPIA\\DATABASE\\PAINTINGSTOREDATABASE.MDF; Integrated Security = true";
        private SqlConnection connec = new SqlConnection(connectionString);

        public SqlConnection ConnectionOpen()
        {
            if (connec.State == ConnectionState.Closed)
            {
                connec.Open();
            }
            return connec;
        }
        
        public SqlConnection ConnectionClose()
        {
            if (connec.State == ConnectionState.Open)
            {
                connec.Close();
            }
            return connec;
        }
    }
}
