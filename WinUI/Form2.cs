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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7();
            form.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form8 form = new Form8();
            form.ShowDialog();
        }
    }
}
