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

namespace DisenioInterfacesBD2
{
    public partial class Form8 : Form
    {
        ClassLogicaJP classLogicaJP = new ClassLogicaJP();
        ClassMessageManager messageManager = new ClassMessageManager();

        public Form8()
        {
            InitializeComponent();
        }

        void listar()
        {
            dataGridView1.DataSource = classLogicaJP.ListarProveedores();
            dataGridView1.Refresh();
            label3.Text = classLogicaJP.numeroProveedores() + "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string resp = "";

            if (button1.Text.ToLower().Contains("nuevo"))
            {
                resp = classLogicaJP.NuevoProveedor(textBox3.Text, textBox4.Text, textBox5.Text, textBox7.Text);

                if (!resp.ToLower().Contains("error"))
                {
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox7.Text = "";
                }
            }
            else
            {
                int idx = dataGridView1.SelectedCells[0].RowIndex;
                int idproveedor = (int)dataGridView1.Rows[idx].Cells[0].Value;

                resp = classLogicaJP.ActualizarProveedor(idproveedor, textBox3.Text, textBox4.Text, textBox5.Text, textBox7.Text);

                if (!resp.ToLower().Contains("error"))
                {
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox7.Text = "";
                    dataGridView1.Enabled = true;
                    button2.Enabled = true;
                    button1.Enabled = true;
                    button3.Enabled = true;
                    button1.Text = "Nuevo";
                }
            }

            messageManager.Show(this, resp);
            listar();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            listar();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DialogResult result = MessageBox.Show("Esta seguro de que desea eliminar al proveedor seleccionado?", "Advetencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int idx = dataGridView1.SelectedCells[0].RowIndex;
                    int idproveedor = (int)dataGridView1.Rows[idx].Cells[0].Value;
                    classLogicaJP.EliminarProveedor(idproveedor);
                    messageManager.Show(this, "INFO: Proveedor eliminado con exito!");
                }

                listar();
            }
            else
            {
                messageManager.Show(this, "ERROR: No se ha seleccionado algun item para eliminar!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int idx = dataGridView1.SelectedCells[0].RowIndex;

                textBox3.Text = dataGridView1.Rows[idx].Cells[1].Value + "";
                textBox4.Text = dataGridView1.Rows[idx].Cells[2].Value + "";
                textBox5.Text = dataGridView1.Rows[idx].Cells[3].Value + "";
                textBox7.Text = dataGridView1.Rows[idx].Cells[4].Value + "";

                dataGridView1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button1.Text = "Guardar";
            }
            else
            {
                messageManager.Show(this, "ERROR: No se ha seleccionado algun item para editarlo!");
            }
        }
    }
}
