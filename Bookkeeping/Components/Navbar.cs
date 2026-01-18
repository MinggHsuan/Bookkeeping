using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Bookkeeping.Components
{
    public partial class Navbar : UserControl
    {
        public static Form lastForm = null;
        public Navbar()
        {
            InitializeComponent();
        }
        public void ChoosePage(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (lastForm != null)
            {
                lastForm.Hide();
            }
            lastForm = SignletonForm.GetForm(button.Text);
            lastForm.Show();
        }
    }
}
