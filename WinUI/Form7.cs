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
            string resp;
            resp = LogicaJP.NuevoCliente(textBox3.Text, textBox4.Text, textBox5.Text, textBox7.Text);
            messageManager.Show(this, resp);
        }
    }
}
