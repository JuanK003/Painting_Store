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
    public partial class Form20 : Form
    {
        ClassLogicaJP logica = new ClassLogicaJP();
        ClassMessageManager msmanager = new ClassMessageManager();

        public Form20()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string msg = logica.AnularFactura(textBox1.Text);

            msmanager.Show(this, msg);

            if (msg.ToLower().StartsWith("info"))
            {
                this.Dispose();
            }
        }
    }
}
