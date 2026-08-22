using AutoMapper.Internal;
using Bookkeeping.Contract;
using Bookkeeping.Models;
using Bookkeeping.Presenter;
using Bookkeeping.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Bookkeeping.Views
{
    public partial class 帳戶分析 : Form, GroupRecordContract.IView
    {

        public List<string> groups = new List<string>(); // 類型 細項 對象 支付方式
        public Dictionary<string, List<string>> filters = new Dictionary<string, List<string>>();
        private GroupRecordContract.IPresenter presenter;
        // 食 => 早餐 午餐
        // 支付方式 => 現金 信用卡

        public 帳戶分析()
        {
            InitializeComponent();
            presenter = new GroupRecordPresenter(this);
            flowLayoutPanel1.GroupInit(OnGroups_CheckedChanged, OnFilters_CheckedChanged);
            flowLayoutPanel2.FilterInit(OnFilters_CheckedChanged);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            presenter.GetResult(startTimePicker.Value.Date, endTimePicker.Value.Date, groups, filters);
        }
        public void OnGetResult(List<GroupRecord> groupRecords)
        {
            dataGridView1.DataSource = groupRecords;
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
