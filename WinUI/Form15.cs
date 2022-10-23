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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinUI
{
    public partial class Form15 : Form
    {
        ClassLogicaJC logica = new ClassLogicaJC();
        ClassMessageManager messageManager = new ClassMessageManager();
        MyProgramUtils programUtils = new MyProgramUtils();
        public Form15()
        {
            InitializeComponent();
        }

        void refreshgrid()
        {
            dataGridView1.DataSource = logica.ListarEntradaProductos();
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int idrol = (int)programUtils.getFieldOfComboBoxSelectedItem(comboBox1, 0);
                logica.NuevoEntradaProducto(dateTimePicker1.Value, int.Parse(textBox7.Text), idrol);
                messageManager.Show(this, "Ítem agregado con éxito!");
                refreshgrid();
                textBox7.Text = "";
            }
            catch (Exception err)
            {
                messageManager.Show(this, err.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Editar")
            {
                try
                {
                    textBox7.Text = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 2) + "";
                    dateTimePicker1.Value = (DateTime)programUtils.getFieldOfSelectedCell(dataGridView1, 1);

                    for (int i = 0; i < comboBox1.Items.Count; i++)
                    {
                        int id1 = (int)programUtils.getItemOfRowComboBox(comboBox1, i, 0);
                        int id2 = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 3);

                        if (id1 == id2)
                        {
                            comboBox1.SelectedIndex = i;
                            break;
                        }
                    }

                    button2.Text = "Salvar";
                    button1.Enabled = false;
                    button3.Enabled = false;
                    dataGridView1.Enabled = false;
                }
                catch (Exception ex)
                {
                    messageManager.Show(this, "Debe seleccionar un ítem a editar válido!" + ex.Message);
                }
            }
            else
            {
                try
                {
                    int idrol = (int)programUtils.getFieldOfComboBoxSelectedItem(comboBox1, 0);
                    int original_id = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 0);
                    logica.ActualizarEntradaProducto(original_id, dateTimePicker1.Value, int.Parse(textBox7.Text), idrol);

                    messageManager.Show(this, "Entrada de Producto actualizado con éxito!");
                    refreshgrid();
                    textBox7.Text = "";
                    button2.Text = "Editar";
                    button1.Enabled = true;
                    button3.Enabled = true;
                    dataGridView1.Enabled = true;
                }
                catch
                {
                    messageManager.Show(this, "Recuerde ingresar datos válidos!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int idproduct = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 0);
                DialogResult result = MessageBox.Show("Esta seguro de que desea eliminar la Marca seleccionado?", "Advetencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    logica.EliminarEntradaProducto(idproduct);
                    messageManager.Show(this, "Entrada de Producto eliminado con éxito!");
                    refreshgrid();
                }
            }
            catch
            {
                messageManager.Show(this, "Recuerde seleccionar un ítem a eliminar!");
            }
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            refreshgrid();
            comboBox1.DataSource = logica.ListarPedidoProductos();
            comboBox1.DisplayMember = "IdPedidoProducto";
        }
    }
}
