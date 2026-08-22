using Bookkeeping.Contract;
using Bookkeeping.Presenter;
using Bookkeeping.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Bookkeeping.Views
{
    public partial class 圖表分析 : Form, ChartContract.IView
    {
        public List<string> groups = new List<string>();
        public Dictionary<string, List<string>> filters = new Dictionary<string, List<string>>();
        public ChartContract.IPresenter presenter;
        public 圖表分析()
        {
            InitializeComponent();
            flowLayoutPanel3.GroupInit(OnGroups_CheckedChanged, OnFilters_CheckedChanged);
            flowLayoutPanel4.FilterInit(OnFilters_CheckedChanged);
            presenter = new ChartPresenter(this);
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if ((string)comboBox1.SelectedItem == "折線圖")
            {
                ComboBox comboBox = new ComboBox();
                comboBox.Name = "comboBox2";
                comboBox.Items.AddRange(new object[] { "本週", "本月" });
                comboBox.SelectedIndexChanged += WeekAndMonth_SelectedIndexChanged;
                panel1.Controls.Add(comboBox);
            }
            else
            {
                panel1.Controls.RemoveByKey("comboBox2");
            }
        }

        private void WeekAndMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            presenter.GetChart(comboBox1.SelectedIndex, (string)((ComboBox)sender).SelectedItem, startTimePicker.Value.Date, endTimePicker.Value.Date, groups, filters);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            presenter.GetChart(comboBox1.SelectedIndex, "本週", startTimePicker.Value.Date, endTimePicker.Value.Date, groups, filters);
        }
        public void OnGetChart(Chart chart)
        {
            chart.Width = flowLayoutPanel1.Width;
            chart.Height = flowLayoutPanel1.Height;
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(chart);
        }
        private void OnGroups_CheckedChanged(object sender, EventArgs args)
        {
            var checkbox = (CheckBox)sender;
            if (checkbox.Checked == true)
            {
                groups.Add(checkbox.Text);
            }
            else
            {
                groups.Remove(checkbox.Text);
            }

        }

        private void OnFilters_CheckedChanged(object sender, EventArgs args)
        {
            var checkbox = (CheckBox)sender;
            var panel = (FlowLayoutPanel)checkbox.Parent;
            if (checkbox.Checked == true)
            {
                if (!filters.ContainsKey(panel.Name))
                {
                    List<string> deatil = new List<string> { checkbox.Text };
                    filters.Add(panel.Name, deatil);
                }
                else
                {
                    filters[panel.Name].Add(checkbox.Text);
                }
            }
            else
            {
                filters[panel.Name].Remove(checkbox.Text);
                if (filters[panel.Name].Count == 0)
                {
                    filters.Remove(panel.Name);
                }
            }

        }


    }
}
