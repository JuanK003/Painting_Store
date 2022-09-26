using DAL.DataSetPSTableAdapters;
using System.Data;

namespace BLL
{
    public class ClassLogicaJP
    {
        private ClienteTableAdapter _clientes;
        private ProveedorTableAdapter _proveedores;
        public ClassLogicaJP()
        {
            _clientes = new ClienteTableAdapter();
            _proveedores = new ProveedorTableAdapter();
        }

        // Tabla Proveedores
        public DataTable ListarProveedores()
        {
            return _proveedores.GetData();
        }

        public string NuevoProveedor(string nombre, string telefono, string direccion, string contacto)
        {
            try
            {
                _proveedores.InsertQueryProveedor(nombre, telefono, direccion, contacto);
                return "INFO: Se ha guardado el nuevo proveedor de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string ActualizarProveedor(int id, string nombre, string telefono, string direccion, string contacto)
        {
            try
            {
                _proveedores.UpdateQueryProveedor(nombre, telefono, direccion, contacto, id);
                return "INFO: Proveedor actualizado con exito!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string EliminarProveedor(int id)
        {
            try
            {
                _proveedores.DeleteQueryProveedor(id);
                return "INFO: Proveedor eliminado con exito!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        // Tabla Clientes
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