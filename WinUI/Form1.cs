using BLL;

namespace DisenioInterfacesBD2
{
    public partial class Form1 : Form
    {
        ClassLogicaJP classLogicaJP = new ClassLogicaJP();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 form = new Form8();
            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            classLogicaJP.restoreNivelesAcceso();
        }
    }
}