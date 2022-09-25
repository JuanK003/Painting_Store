using DAL.DataSetPSTableAdapters;
using System.Data;

namespace BLL
{
    public class ClassLogicaJP
    {
        private ClienteTableAdapter _clientes;

        public ClassLogicaJP()
        {
            _clientes = new ClienteTableAdapter();
        }

        public DataTable Listar()
        {
            return _clientes.GetData();
        }

        public string NuevoCliente(string nombre, string direccion, string telefono, string nit)
        {
            try
            {
                int countNit = (int)_clientes.ScalarQueryExistsNIT(nit);

                if (countNit == 0)
                {
                    _clientes.InsertQueryCliente(nombre, direccion, telefono, nit);
                    return "INFO: Se ha guardado el cliente de forma exitosa!";
                }
                else
                {
                    return "ERROR: Un cliente con el mismo NIT ya existe!";
                }
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }


    }
}