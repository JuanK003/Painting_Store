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
    public partial class Form14 : Form
    {
        ClassLogicaJC logica = new ClassLogicaJC();
        ClassLogicaJP logicaJP = new ClassLogicaJP();
        ClassMessageManager messageManager = new ClassMessageManager();
        MyProgramUtils programUtils = new MyProgramUtils();
        public Form14()
        {
            InitializeComponent();
        }

        void refreshgrid()
        {
            dataGridView1.DataSource = logica.ListarPedidoProductos();
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int idrol = (int)programUtils.getFieldOfComboBoxSelectedItem(comboBox1, 0);
                int idrol2 = (int)programUtils.getFieldOfComboBoxSelectedItem(comboBox2, 0);
                logica.NuevoPedidoProducto(int.Parse(textBox7.Text), dateTimePicker1.Value, idrol, idrol2);
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
                    textBox7.Text = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 1) + "";
                    dateTimePicker1.Value = (DateTime)programUtils.getFieldOfSelectedCell(dataGridView1, 2);

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

                    for (int i = 0; i < comboBox2.Items.Count; i++)
                    {
                        int id1 = (int)programUtils.getItemOfRowComboBox(comboBox2, i, 0);
                        int id2 = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 4);

                        if (id1 == id2)
                        {
                            comboBox2.SelectedIndex = i;
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
                    int idrol2 = (int)programUtils.getFieldOfComboBoxSelectedItem(comboBox2, 0);
                    int original_id = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 0);
                    logica.ActualizarPedidoProducto(original_id, int.Parse(textBox7.Text), dateTimePicker1.Value, idrol, idrol2);

                    messageManager.Show(this, "Pedido de Producto actualizado con éxito!");
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
                    logica.EliminarPedidoProducto(idproduct);
                    messageManager.Show(this, "Pedido de Producto eliminado con éxito!");
                    refreshgrid();
                }
            }
            catch
            {
                messageManager.Show(this, "Recuerde seleccionar un ítem a eliminar!");
            }
        }
        private void Form14_Load(object sender, EventArgs e)
        {
            refreshgrid();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss";

            dateTimePicker1.Value = DateTime.Now;

            comboBox1.DataSource = logicaJP.ListarProveedores();
            comboBox1.DisplayMember = "NombreProveedor";

            comboBox2.DataSource = logica.ListarProductos();
            comboBox2.DisplayMember = "NombreProducto";
        }
    }
}
