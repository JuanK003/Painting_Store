using BLL;
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
    }
}
