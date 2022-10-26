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
    public partial class Form19 : Form
    {
        ClassLogicaJP logica = new ClassLogicaJP();
        MyProgramUtils utils = new MyProgramUtils();
        ClassMessageManager msmanager = new ClassMessageManager();

        public Form19()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = logica.ListarFacturas();
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataTable[] tablas = logica.ListarDetallesFactura((string)utils.getFieldOfSelectedCell(dataGridView1, 0));

                dataGridView2.DataSource = tablas[0];
                dataGridView3.DataSource = tablas[1];
            }
            catch (Exception ex)
            {
                msmanager.Show(this, "ERROR: " + ex.Message);
            }
        }
    }
}
