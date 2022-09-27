using DAL.DataSetPSTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClassLogicaJC
    {
        private PresentacionProductoTableAdapter _presentacionProducto;
        private MetodoPagoTableAdapter _metodoPago;
        private MarcaProductoTableAdapter _marca;
        private AplicacionProductoTableAdapter _aplicacionProducto;
        public ClassLogicaJC()
        {
            _presentacionProducto = new PresentacionProductoTableAdapter();
            _metodoPago = new MetodoPagoTableAdapter();
            _marca = new MarcaProductoTableAdapter();
            _aplicacionProducto = new AplicacionProductoTableAdapter();

            _presentacionProducto.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _metodoPago.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _marca.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
            _aplicacionProducto.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "Database\\PaintingStoreDatabase.mdf; Integrated Security = True";
        }

        //-------------------------------------- CRUD PRESENTACIÓN PRODUCTO --------------------------------------
        public DataTable ListarPresentacionProducto()
        {
            return _presentacionProducto.GetData();
        }
        public string NuevoPresentacionProducto(float MedidaPresentacion, string NombrePresentacion)
        {
            try
            {
                _presentacionProducto.InsertQueryPresentacionProducto(MedidaPresentacion, NombrePresentacion);
                return "INFO: Se ha guardado la nueva Presentación del Producto de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string ActualizarPresentacioProducto(int id, float MedidaPresentacion, string NombrePresentacion)
        {
            try
            {
                _presentacionProducto.UpdateQueryPresentacionProducto(MedidaPresentacion, NombrePresentacion, id);
                return "INFO: Presentación del Producto actualizado de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string EliminarPresentacionProducto(int id)
        {
            try
            {
                _presentacionProducto.DeleteQueryPresentacionProducto(id);
                return "INFO: Presentación del Producto eliminada de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        //-------------------------------------- CRUD METODO PAGO --------------------------------------
        public DataTable ListarMetodoPago()
        {
            return _metodoPago.GetData();
        }
        public string NuevoMetodoPago(string nombreMetodoPago)
        {
            try
            {
                _metodoPago.InsertQueryMetodoPago(nombreMetodoPago);
                return "INFO: Se ha guardado el nuevo Método de Pago de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string ActualizarMetodoPago(int id, string nombreMetodoPago)
        {
            try
            {
                _metodoPago.UpdateQueryMetodoPago(nombreMetodoPago, id);
                return "INFO: Método de Pago actualizado de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string EliminarMetodoPago(int id)
        {
            try
            {
                _metodoPago.DeleteQueryMetodoPago(id);
                return "INFO: Método de Pago eliminada de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }
        //-------------------------------------- CRUD MARCA DEL PRODUCTO --------------------------------------
        public DataTable ListarMarca()
        {
            return _marca.GetData();
        }
        public string NuevoMarca(string nombreMarca)
        {
            try
            {
                _marca.InsertQueryMarca(nombreMarca);
                return "INFO: Se ha guardado la Marca de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string ActualizarMarca(int id, string nombreMarca)
        {
            try
            {
                _marca.UpdateQueryMarca(nombreMarca, id);
                return "INFO: Marca actualizada de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string EliminarMarca(int id)
        {
            try
            {
                _marca.DeleteQueryMarca(id);
                return "INFO: Marca eliminada de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }
        //-------------------------------------- CRUD APLICACIÓN DEL PRODUCTO --------------------------------------
        public DataTable ListarAplicacion()
        {
            return _aplicacionProducto.GetData();
        }
        public string NuevoAplicacion(string nombreAplicacion)
        {
            try
            {
                _aplicacionProducto.InsertQueryAplicacionProducto(nombreAplicacion);
                return "INFO: Se ha guardado la Aplicación del Producto de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string ActualizarAplicacion(int id, string nombreAplicacion)
        {
            try
            {
                _aplicacionProducto.UpdateQueryAplicacionProducto(nombreAplicacion, id);    
                return "INFO: Aplicación del Producto actualizada de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }

        public string EliminarAplicacion(int id)
        {
            try
            {
                _aplicacionProducto.DeleteQueryAplicacionProducto(id);
                return "INFO: Aplicación del Producto eliminada de forma exitosa!";
            }
            catch (Exception error)
            {
                return "ERROR: " + error.Message;
            }
        }
    }
}
