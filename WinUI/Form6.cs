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
    public partial class Form6 : Form
    {
        ClassLogicaJP classLogicaJP = new ClassLogicaJP();
        ClassMessageManager messageManager = new ClassMessageManager();

        public Form6()
        {
            InitializeComponent();
        }

        void listarEmpleados()
        {
            dataGridView1.DataSource = classLogicaJP.ListarEmpleados();
            dataGridView1.Refresh();
        }

        void listarNivelesAcceso()
        {
            dataGridView2.DataSource = classLogicaJP.ListarNivelesAcceso();
            dataGridView2.Refresh();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            listarEmpleados();
            listarNivelesAcceso();
        }


        int getIdSelectedNivelAcceso()
        {
            int idxrow = dataGridView2.SelectedCells[0].RowIndex;
            int idnivel = (int)dataGridView2.Rows[idxrow].Cells[0].Value;
            return idnivel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string resp = "";

            try
            {
                if (button1.Text.ToLower().Contains("nuevo"))
                {
                    resp = classLogicaJP.NuevoEmpleado(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Value, textBox7.Text, getIdSelectedNivelAcceso());

                    if (!resp.ToLower().Contains("error"))
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                        textBox7.Text = "";
                    }
                }
                else
                {
                    int idx = dataGridView1.SelectedCells[0].RowIndex;
                    int idempleado = (int)dataGridView1.Rows[idx].Cells[0].Value;

                    resp = classLogicaJP.ActualizarEmpleado(idempleado, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, dateTimePicker1.Value, textBox7.Text, getIdSelectedNivelAcceso());
                    
                    if (!resp.ToLower().Contains("error"))
                    {
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                        textBox7.Text = "";

                        dataGridView1.Enabled = true;
                        button2.Enabled = true;
                        button1.Enabled = true;
                        button3.Enabled = true;
                        button1.Text = "Nuevo";
                    }
                }

                messageManager.Show(this, resp);
                listarEmpleados();
            }
            catch
            {
                messageManager.Show(this, "ERROR: Recuerde ingresar datos y seleccionar un nivel de acceso valido!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int idx = dataGridView1.SelectedCells[0].RowIndex;
                int idacceso = (int)dataGridView1.Rows[idx].Cells[8].Value;

                textBox1.Text = dataGridView1.Rows[idx].Cells[1].Value + "";
                textBox2.Text = "";
                textBox3.Text = dataGridView1.Rows[idx].Cells[3].Value + "";
                textBox4.Text = dataGridView1.Rows[idx].Cells[4].Value + "";
                textBox5.Text = dataGridView1.Rows[idx].Cells[5].Value + "";
                dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[idx].Cells[6].Value + "");
                textBox7.Text = dataGridView1.Rows[idx].Cells[7].Value + "";

                


                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    if (idacceso == (int)dataGridView2.Rows[i].Cells[0].Value)
                    {
                        dataGridView2.Rows[i].Selected = true;
                    }
                    else
                    {
                        dataGridView2.Rows[i].Selected = false;
                    }
                }

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
                DialogResult result = MessageBox.Show("Esta seguro de que desea eliminar al empleado seleccionado?", "Advetencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int idx = dataGridView1.SelectedCells[0].RowIndex;
                    int idempleado = (int)dataGridView1.Rows[idx].Cells[0].Value;
                    classLogicaJP.EliminarEmpleado(idempleado);
                    messageManager.Show(this, "INFO: Empleado eliminado con exito!");
                }

                listarEmpleados();
            }
            else
            {
                messageManager.Show(this, "ERROR: No se ha seleccionado algun item para eliminar!");
            }
        }
    }
}
