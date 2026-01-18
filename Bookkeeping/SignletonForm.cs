using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookkeeping
{
    public class SignletonForm
    {
        private static Dictionary<string, Form> dict = new Dictionary<string, Form>();
        public static Form GetForm(string head)
        {
            if (!dict.ContainsKey(head))
            {
                Type type = Type.GetType($"Bookkeeping.{head}");
                dict.Add(head, (Form)Activator.CreateInstance(type));
                dict[head].FormClosed += SignletonForm_FormClosed;
            }
            return dict[head];
        }

        private static void SignletonForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
