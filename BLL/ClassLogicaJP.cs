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

        public string ActualizarCliente(int id, string nombre, string direccion, string telefono, string nit)
        {
            try
            {
                _clientes.UpdateQueryCliente(nombre, direccion, telefono, nit, id);
                return "INFO: Cliente actualizado con exito!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string EliminarCliente(int id)
        {
            try
            {
                _clientes.DeleteQueryCliente(id);
                return "INFO: Cliente eliminado con exito!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }
    }
}