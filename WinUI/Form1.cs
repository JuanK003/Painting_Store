using BLL;
using MessageManager;
using System.Windows.Forms;

namespace DisenioInterfacesBD2
{
    public partial class Form1 : Form
    {
        ClassLogicaJP classLogicaJP = new ClassLogicaJP();
        ClassMessageManager messageManager = new ClassMessageManager();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nivel = classLogicaJP.getNivelLogin(textBoxUser.Text, textBoxPassword.Text);

            if (nivel == 1)
            {
                Form2 form = new Form2();
                form.ShowDialog();

                textBoxUser.Text = "";
                textBoxPassword.Text = "";
            }
            else
            {
                if (nivel == 2)
                {
                    Form3 form = new Form3();
                    form.ShowDialog();

                    textBoxUser.Text = "";
                    textBoxPassword.Text = "";
                }
                else
                {
                    if (nivel == 3)
                    {
                        Form4 form = new Form4();
                        form.ShowDialog();

                        textBoxUser.Text = "";
                        textBoxPassword.Text = "";
                    }
                    else
                    {
                        if (nivel == 4)
                        {
                            Form5 form = new Form5();
                            form.ShowDialog();

                            textBoxUser.Text = "";
                            textBoxPassword.Text = "";
                        }
                        else
                        {
                            messageManager.Show(this, "ERROR: Credenciales incorrectas");
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Environment.CurrentDirectory);
            // La linea se ejecuta si los niveles de acceso no estan disponibles
            // classLogicaJP.restoreNivelesAcceso();
        }
    }
}