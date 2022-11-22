using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
    public class Reportes
    {
        private ConecctionDB connection = new ConecctionDB();
        private SqlCommand command = new SqlCommand();
        private SqlDataReader readRows;

        public void Modo(string nom_pago, double monto_total)
        {
            command.Connection = connection.ConnectionOpen();
            command.CommandText = "insetar_monto_pagos";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@nom_pago", nom_pago);
            command.Parameters.AddWithValue("@monto_total", monto_total);
            command.ExecuteNonQuery();
            command.Parameters.Clear();
        }
    }
}
