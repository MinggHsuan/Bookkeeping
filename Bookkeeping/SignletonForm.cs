using Bookkeeping.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookkeeping
{
    public class SignletonForm
    {
        private static Dictionary<string, Form> dict = new Dictionary<string, Form>();
        public static Form lastForm = null;
        public static Form GetForm(string head)
        {
            if (lastForm != null)
            {
                lastForm.Hide();
            }
            if (!dict.ContainsKey(head))
            {
                Type type = Type.GetType($"Bookkeeping.Views.{head}");
                dict.Add(head, (Form)Activator.CreateInstance(type));
                dict[head].FormClosed += SignletonForm_FormClosed;
            }
            FieldInfo[] fields = dict[head].GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            var field = fields.Where(x => x.FieldType == typeof(Navbar)).First();
            Navbar navbar = (Navbar)field.GetValue(dict[head]);
            for (int i = 0; i < navbar.Controls[0].Controls.Count; i++)
            {
                if (navbar.Controls[0].Controls[i].Text == head)
                {
                    navbar.Controls[0].Controls[i].Enabled = false;
                }
            }
            lastForm = dict[head];
            return dict[head];
        }

        private static void SignletonForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
