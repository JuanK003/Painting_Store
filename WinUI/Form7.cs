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
    public partial class Form7 : Form
    {
        ClassLogicaJP LogicaJP = new ClassLogicaJP();
        ClassMessageManager messageManager = new ClassMessageManager();

        public Form7()
        {
            InitializeComponent();
        }

        void listar()
        {
            dataGridView1.DataSource = LogicaJP.Listar();
            dataGridView1.Refresh();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            listar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string resp = "";
            
            if (button1.Text.ToLower().Contains("nuevo"))
            {
                resp = LogicaJP.NuevoCliente(textBox3.Text, textBox4.Text, textBox5.Text, textBox7.Text);

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
                int idcliente = (int)dataGridView1.Rows[idx].Cells[0].Value;

                resp = LogicaJP.ActualizarCliente(idcliente, textBox3.Text, textBox4.Text, textBox5.Text, textBox7.Text);

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

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                DialogResult result = MessageBox.Show("Esta seguro de que desea eliminar al cliente seleccionado?", "Advetencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int idx = dataGridView1.SelectedCells[0].RowIndex;
                    int idcliente = (int)dataGridView1.Rows[idx].Cells[0].Value;
                    LogicaJP.EliminarCliente(idcliente);
                    messageManager.Show(this, "INFO: Cliente eliminado con exito!");
                }

                listar();
            }
            else
            {
                messageManager.Show(this, "ERROR: No se ha seleccionado algun item para eliminar!");
            }
        }
    }
}
