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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;

namespace WinUI
{
    public partial class Form13 : Form
    {
        ClassLogicaJC logica = new ClassLogicaJC();
        ClassMessageManager messageManager = new ClassMessageManager();
        MyProgramUtils programUtils = new MyProgramUtils();

        public Form13()
        {
            InitializeComponent();
        }

        void refreshgrid()
        {
            dataGridView1.DataSource = logica.ListarProductos();
            dataGridView1.Refresh();
        }

        private void Form13Form_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int idrol = (int)programUtils.getFieldOfComboBoxSelectedItem(comboBox1, 0);
                int idrol2 = (int)programUtils.getFieldOfComboBoxSelectedItem(comboBox2, 0);
                int idrol3 = (int)programUtils.getFieldOfComboBoxSelectedItem(comboBox3, 0);
                logica.NuevoProducto(textBox1.Text, textBox2.Text, decimal.Parse(textBox3.Text),int.Parse(textBox4.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text), idrol, idrol2, idrol3);
                messageManager.Show(this, "Ítem agregado con éxito!");
                refreshgrid();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
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
                    textBox6.Text = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 6)+ "";
                    textBox5.Text = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 5) + "";
                    textBox1.Text = (string)programUtils.getFieldOfSelectedCell(dataGridView1, 1);
                    textBox2.Text = (string)programUtils.getFieldOfSelectedCell(dataGridView1, 2);
                    textBox3.Text = (double)programUtils.getFieldOfSelectedCell(dataGridView1, 3) + "";
                    textBox4.Text = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 4) + "";

                    for (int i = 0; i < comboBox1.Items.Count; i++)
                    {
                        int id1 = (int)programUtils.getItemOfRowComboBox(comboBox1, i, 0);
                        int id2 = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 7);

                        if (id1 == id2)
                        {
                            comboBox1.SelectedIndex = i;
                            break;
                        }
                    }

                    for (int i = 0; i < comboBox2.Items.Count; i++)
                    {
                        int id1 = (int)programUtils.getItemOfRowComboBox(comboBox2, i, 0);
                        int id2 = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 8);

                        if (id1 == id2)
                        {
                            comboBox2.SelectedIndex = i;
                            break;
                        }
                    }

                    for (int i = 0; i < comboBox3.Items.Count; i++)
                    {
                        int id1 = (int)programUtils.getItemOfRowComboBox(comboBox3, i, 0);
                        int id2 = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 9);

                        if (id1 == id2)
                        {
                            comboBox3.SelectedIndex = i;
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
                    int idrol3 = (int)programUtils.getFieldOfComboBoxSelectedItem(comboBox3, 0);
                    int original_id = (int)programUtils.getFieldOfSelectedCell(dataGridView1, 0);
                    logica.ActualizarProducto(original_id, textBox1.Text, textBox2.Text, float.Parse(textBox3.Text), int.Parse(textBox4.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text), idrol, idrol2, idrol3);

                    messageManager.Show(this, "Producto actualizado con éxito!");
                    refreshgrid();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
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
                    logica.EliminarProducto(idproduct);
                    messageManager.Show(this, "Producto eliminado con éxito!");
                    refreshgrid();
                }
            }
            catch
            {
                messageManager.Show(this, "Recuerde seleccionar un ítem a eliminar!");
            }
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            refreshgrid();
            comboBox1.DataSource = logica.ListarMarca();
            comboBox1.DisplayMember = "NombreMarca";

            comboBox2.DataSource = logica.ListarAplicacion();
            comboBox2.DisplayMember = "NombreAplicacion";

            comboBox3.DataSource = logica.ListarPresentacionProducto();
            comboBox3.DisplayMember = "NombrePresentacion";
        }
    }
}
