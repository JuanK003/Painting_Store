<<<<<<< HEAD
﻿using System;
=======
﻿using BLL;
using MessageManager;
using System;
>>>>>>> origin/pruebacrudclientes
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
=======
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
>>>>>>> origin/pruebacrudclientes

namespace WinUI
{
    public partial class Form12 : Form
    {
<<<<<<< HEAD
=======
        ClassLogicaJC LogicaJC = new ClassLogicaJC();
        ClassMessageManager messageManager = new ClassMessageManager();
>>>>>>> origin/pruebacrudclientes
        public Form12()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
        private void Form12_Load(object sender, EventArgs e)
        {

=======
        void listar()
        {
            dataGridView1.DataSource = LogicaJC.ListarMetodoPago();
            dataGridView1.Refresh();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            listar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string resp = "";
            if (button1.Text.ToLower().Contains("nuevo"))
            {
                resp = LogicaJC.NuevoMetodoPago(textBox3.Text);

                if (!resp.ToLower().Contains("error"))
                {
                    textBox3.Text = "";
                }
            }
            else
            {
                int idx = dataGridView1.SelectedCells[0].RowIndex;
                int idpresentacionproducto = (int)dataGridView1.Rows[idx].Cells[0].Value;
                resp = LogicaJC.ActualizarMetodoPago(idpresentacionproducto, textBox3.Text);

                if (!resp.ToLower().Contains("error"))
                {
                    textBox3.Text = "";
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
                DialogResult result = MessageBox.Show("Esta seguro de que desea eliminar el Método de Pago seleccionado?", "Advetencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int idx = dataGridView1.SelectedCells[0].RowIndex;
                    int idpresentacionproducto = (int)dataGridView1.Rows[idx].Cells[0].Value;
                    LogicaJC.EliminarMetodoPago(idpresentacionproducto);
                    messageManager.Show(this, "INFO: Método de Pago eliminado con exito!");
                }

                listar();
            }
            else
            {
                messageManager.Show(this, "ERROR: No se ha seleccionado algun item para editarlo!");
            }
>>>>>>> origin/pruebacrudclientes
        }
    }
}
