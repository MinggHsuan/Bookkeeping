using Bookkeeping.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookkeeping.Utility
{
    public static class Extension
    {
        private static System.Threading.Timer timer;
        private static Form mainForm;
        private static object action;
        private static object number;
        public static void DebounceTime<T>(this Form form, Action<T> callback, T t, int delay)
        {
            number = t;
            action = callback;
            mainForm = form;
            TimerCallback doSomething = new TimerCallback(DoSomething);
            if (timer == null)
            {
                timer = new System.Threading.Timer(doSomething, t, delay, -1);
            }
            timer.Change(delay, -1);
        }
        public static void DebounceTime(this Form form, Action callback, int delay)
        {
            action = callback;
            mainForm = form;
            TimerCallback doSomething = new TimerCallback(DoSomething);
            if (timer == null)
            {
                timer = new System.Threading.Timer(doSomething, null, delay, -1);
            }
            timer.Change(delay, -1);
        }
        private static void DoSomething(object t)
        {
            mainForm.Invoke(new Action(() =>
            {
                action.GetType().GetMethod("Invoke").Invoke(action, null);
            }));
        }

        private static FlowLayoutPanel GroupPanel;
        private static FlowLayoutPanel Filterpanel;
        public static void GroupInit(this FlowLayoutPanel flowLayoutPanel, EventHandler groups, EventHandler filter)
        {
            var props = typeof(RecordModel).GetProperties();
            FlowLayoutPanel panel = new FlowLayoutPanel { Width = flowLayoutPanel.Width, Height = 30 };
            foreach (var prop in props)
            {
                string headerText = prop.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                if (headerText == "日期" || headerText == "金額" || headerText == "圖檔1" || headerText == "圖檔2" || headerText == "細項")
                {
                    continue;
                }
                CheckBox checkBox = new CheckBox { Width = 80, Text = headerText };
                checkBox.CheckedChanged += groups;
                if (checkBox.Text == "類型")
                {
                    checkBox.CheckedChanged += TypeBox_CheckedChanged;
                    checkBox.Tag = new List<FlowLayoutPanel> { new FlowLayoutPanel { Width = flowLayoutPanel.Width, Height = 30 }, new FlowLayoutPanel { Width = flowLayoutPanel.Width, Height = 30, Tag = filter } };
                }
                panel.Controls.Add(checkBox);
            }
            flowLayoutPanel.Controls.Add(panel);
            GroupPanel = flowLayoutPanel;
        }

        public static void FilterInit(this FlowLayoutPanel flowLayoutPanel, EventHandler filter)
        {
            var fields = typeof(DataModel).GetFields().Where(x => x.FieldType.Name == "String[]" && x.Name != "Type");
            FlowLayoutPanel panel = new FlowLayoutPanel { Width = flowLayoutPanel.Width, Height = 30 };

            foreach (var field in fields)
            {
                panel = new FlowLayoutPanel { Width = flowLayoutPanel.Width, Height = 30, Name = field.Name };
                var modelList = (Array)field.GetValue(new DataModel());
                foreach (var item in modelList)
                {
                    CheckBox checkBox = new CheckBox { Text = item.ToString(), Width = 80 };
                    checkBox.CheckedChanged += filter;
                    panel.Controls.Add(checkBox);
                }
                flowLayoutPanel.Controls.Add(panel);
            }
            Filterpanel = flowLayoutPanel;
        }
        private static void TypeBox_CheckedChanged(object sender, EventArgs e)
        {
            var typebox = (CheckBox)sender;
            var panelList = (List<FlowLayoutPanel>)typebox.Tag;
            DataModel dataModel = new DataModel();
            if (typebox.Checked == true)
            {
                foreach (var item in dataModel.Type)
                {
                    CheckBox itemBox = new CheckBox();
                    itemBox.Text = item;
                    itemBox.Name = item;
                    itemBox.Width = 80;
                    itemBox.Tag = panelList[1];
                    itemBox.CheckedChanged += ItemBox_CheckedChanged;
                    panelList[0].Controls.Add(itemBox);
                }
                GroupPanel.Controls.Add(panelList[0]);
            }
            else
            {
                GroupPanel.Controls.Remove(panelList[0]);
                foreach (var item in dataModel.Type)
                {
                    Filterpanel.Controls.RemoveByKey(item);
                }
                typebox.Tag = new List<FlowLayoutPanel> { new FlowLayoutPanel { Width = GroupPanel.Width, Height = 30 }, new FlowLayoutPanel { Width = GroupPanel.Width, Height = 30 } };
            }
        }

        private static void ItemBox_CheckedChanged(object sender, EventArgs e)
        {
            var itembox = (CheckBox)sender;
            var itempanel = (FlowLayoutPanel)itembox.Tag;
            if (itembox.Checked == true)
            {
                CheckBox selectAll = new CheckBox { Text = "全選", Width = 80, Tag = false };
                selectAll.CheckedChanged += SelectAll_CheckedChanged;
                FlowLayoutPanel panel = new FlowLayoutPanel { Width = GroupPanel.Width, Height = 30 };
                panel.Name = itembox.Text;
                panel.Controls.Add(selectAll);
                foreach (var item in DataModel.Details[itembox.Text])
                {
                    CheckBox checkBox = new CheckBox { Text = item.ToString(), Width = 80 };
                    checkBox.CheckedChanged += (EventHandler)itempanel.Tag;
                    checkBox.CheckedChanged += CheckedChanged;
                    panel.Controls.Add(checkBox);
                }
                itempanel.Controls.Add(panel);
                itembox.Tag = itempanel;
                Filterpanel.Controls.Add(panel);
            }
            else
            {
                Filterpanel.Controls.RemoveByKey(itembox.Text);
            }
        }

        private static void CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            var panel = (FlowLayoutPanel)checkbox.Parent;
            var selectAll = (CheckBox)panel.Controls[0];

            if ((bool)selectAll.Tag == true)
            {
                return;
            }

            selectAll.Tag = true;
            foreach (CheckBox item in panel.Controls)
            {
                if (item.Text == "全選")
                {
                    continue;
                }
                if (item.Checked == false)
                {
                    selectAll.Checked = false;
                    selectAll.Tag = false;
                    return;
                }
            }
            selectAll.Checked = true;
            selectAll.Tag = false;
        }

        private static void SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;
            var panel = (FlowLayoutPanel)checkbox.Parent;
            if ((bool)checkbox.Tag == true)
            {
                return;
            }
            checkbox.Tag = true;
            foreach (CheckBox item in panel.Controls)
            {
                item.Checked = checkbox.Checked;
            }
            checkbox.Tag = false;
        }
    }
}
