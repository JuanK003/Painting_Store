using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageManager
{
    internal class ClassMessageManager
    {
        public ClassMessageManager()
        {

        }

        public void Show(System.Windows.Forms.IWin32Window owner, string message)
        {
            if (message.ToLower().Contains("error"))
            {
                MessageBox.Show(owner, message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(owner, message, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
