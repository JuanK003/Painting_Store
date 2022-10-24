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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form19 form19 = new Form19();
            form19.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form18 form18 = new Form18();
            form18.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form20 form20 = new Form20();
            form20.ShowDialog();
        }
    }
}
