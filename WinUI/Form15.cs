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

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form15_Load(object sender, EventArgs e)
        {
            refreshgrid();
            comboBox1.DataSource = logica.ListarPedidoProductos();
            comboBox1.DisplayMember = "NombreMarca";
        }
    }
}
