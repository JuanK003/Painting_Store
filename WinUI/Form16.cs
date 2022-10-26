using BLL;
using MessageManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinUI
{
    public partial class Form16 : Form
    {
        MyProgramUtils programUtils = new MyProgramUtils();
        ClassLogicaJP logica = new ClassLogicaJP();
        ClassMessageManager msmanager = new ClassMessageManager();
        DataTable listaproductos = new DataTable()
        {
            Columns = { "Id", "IdProducto", "NombreProducto", "Precio", "Cantidad", "Subtotal" }
        };

        DataTable metodosparapagar = new DataTable()
        {
            Columns = { "Id", "IdTipoMetodo", "TipoMetodo", "Datos", "Cantidad" }
        };

        public Form16()
        {
            InitializeComponent();
        }

        /*public void printDocument()
        {

        }*/

        private void button3_Click(object sender, EventArgs e)
        {
            this.printDocument1.Print();
            // antes de imprimir
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 14);
            int ancho = 1000;
            int y = 20;

            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------- ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("                                                 Encabezado de factura", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("                                                 Empleado " + comboBox1.Text.ToString() + "                               ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("                                                 No. Cliente: " + comboBox2.Text.ToString() + "                               ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("                                                 Tipo de pago " + comboBox3.Text.ToString() + "                               ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("                                                 Fecha " + DateTime.Now.ToString() + "                               ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------------------------n", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));

            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------------------------", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("                                                 Detalles de productos", font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
            e.Graphics.DrawString("-------------------------------------------------------------------------------------------------------------------------------------------------------n", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));

            for (int i = 0; this.dataGridView2.Rows.Count -1 > i; i++)
            {
                e.Graphics.DrawString(dataGridView2.Rows[i].Cells[0].Value.ToString() + "           " + dataGridView2.Rows[i].Cells[1].Value.ToString() + "            " + dataGridView2.Rows[i].Cells[2].Value.ToString() + "            " + dataGridView2.Rows[i].Cells[3].Value.ToString() + "         " + dataGridView2.Rows[i].Cells[4].Value.ToString(), font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
                y += 25;
            }

            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------- ", font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));
            e.Graphics.DrawString("                                                  Total " + textBox2.Text.ToString(), font, Brushes.Black, new RectangleF(0, y += 30, ancho, 20));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------------------------------------------------------------------- ",font, Brushes.Black, new RectangleF(0, y += 20, ancho, 20));

        }

        private void Form16_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = logica.ListarEmpleados();
            comboBox1.DisplayMember = "NombreEmpleado";

            comboBox2.DataSource = logica.ListarClientes();
            comboBox2.DisplayMember = "NombreCliente";

            comboBox3.DataSource = logica.ListarMetodosPago();
            comboBox3.DisplayMember = "NombreMetodoPago";

            dataGridView1.DataSource = logica.ListarProductosConNombres();
            dataGridView1.Refresh();

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double cantidad = Convert.ToDouble(domainUpDown1.Text);

                if (dataGridView1.SelectedCells.Count > 0 && cantidad > 0)
                {
                    int idprod = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 0);
                    string pnombre = (string)programUtils.getFieldOfSelectedCell(dataGridView1, 1);
                    double precio = (double)programUtils.getFieldOfSelectedCell(dataGridView1, 3);
                    double subtotal = precio * cantidad;

                    // { "Id", "IdProducto", "NombreProducto", "Precio", "Cantidad", "Subtotal" }
                    listaproductos.Rows.Add(new Object[] { listaproductos.Rows.Count + 1, idprod, pnombre, precio, cantidad, subtotal });
                    refreshlistafactura();
                }
                else
                {
                    msmanager.Show(this, "ERROR: Debe seleccionar un ítem de la lista y debe comprar al menos un elemento del ítem seleccionado de la lista de productos!");
                }
            }
            catch (Exception ex)
            {
                msmanager.Show(this, "ERROR: " + ex.Message);
            }
            
        }

        void refreshlistafactura()
        {
            double sum = 0;
            for (int i = 1; i <= listaproductos.Rows.Count; i++)
            {
                listaproductos.Rows[i - 1][0] = i;
                sum += double.Parse((string)listaproductos.Rows[i - 1][5]);
            }

            dataGridView3.DataSource = listaproductos;
            dataGridView3.Refresh();
            textBox3.Text = sum + "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedCells.Count > 0)
            {
                listaproductos.Rows.RemoveAt(dataGridView3.SelectedCells[0].RowIndex);
                refreshlistafactura();
            }
            else
            {
                msmanager.Show(this, "ERROR: Debe seleccionar al menos un item de la factura a retirar!");
            }
        }

        void refreshlistametodospago()
        {
            double sum = 0;
            for (int i = 1; i <= metodosparapagar.Rows.Count; i++)
            {
                metodosparapagar.Rows[i - 1][0] = i;
                sum += double.Parse((string)metodosparapagar.Rows[i - 1][metodosparapagar.Columns.Count - 1]);
            }

            dataGridView2.DataSource = metodosparapagar;
            dataGridView2.Refresh();
            textBox5.Text = sum + "";
        }


        private void button4_Click(object sender, EventArgs e)
        {
            // metodosparapagar 
            // { "Id", "IdTipoMetodo", "TipoMetodo", "Datos", "Cantidad" }
            
            try
            {
                if (textBox4.Text != "")
                {
                    double cantidad = double.Parse(textBox2.Text);
                    metodosparapagar.Rows.Add(new Object[] { metodosparapagar.Rows.Count + 1, programUtils.getFieldOfComboBoxSelectedItem(comboBox3, 0), programUtils.getFieldOfComboBoxSelectedItem(comboBox3, 1), textBox4.Text, cantidad });
                    refreshlistametodospago();
                }
            }
            catch (Exception ex)
            {
                msmanager.Show(this, "ERROR: " + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                metodosparapagar.Rows.RemoveAt(dataGridView2.SelectedCells[0].RowIndex);
                refreshlistametodospago();
            }
            else
            {
                msmanager.Show(this, "ERROR: Debe seleccionar al menos una opcion de pago para remover!");
            }
        }
    }
}
