using Bookkeeping.Models;
using CSVlibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookkeeping.Views
{
    public partial class 記帳本 : Form
    {
        //public Dictionary<string, DataGridViewImageColumn> dict = new Dictionary<string, DataGridViewImageColumn>();
        public 記帳本()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<RecordModel> recordModel = CSVHelper.Read<RecordModel>("filePath.csv");
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = recordModel;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                if (dataGridView1.Columns[i].HeaderText == "類型")
                {
                    DataGridViewComboBoxColumn TypeComboBoxColumn = new DataGridViewComboBoxColumn();
                    TypeComboBoxColumn.HeaderText = "類型選單";
                    TypeComboBoxColumn.DataSource = DataModel.Type;
                    dataGridView1.Columns[i].Visible = false;
                    dataGridView1.Columns.Insert(i + 1, TypeComboBoxColumn);
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        dataGridView1.Rows[j].Cells[i + 1].Value = dataGridView1.Rows[j].Cells[i].Value;
                    }
                }
                if (dataGridView1.Columns[i].HeaderText == "對象")
                {
                    DataGridViewComboBoxColumn TargetComboBoxColumn = new DataGridViewComboBoxColumn();
                    TargetComboBoxColumn.HeaderText = "對象選單";
                    TargetComboBoxColumn.DataSource = DataModel.Target;
                    dataGridView1.Columns[i].Visible = false;
                    dataGridView1.Columns.Insert(i + 1, TargetComboBoxColumn);
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        dataGridView1.Rows[j].Cells[i + 1].Value = dataGridView1.Rows[j].Cells[i].Value;
                    }
                }
                if (dataGridView1.Columns[i].HeaderText == "支付方式")
                {
                    DataGridViewComboBoxColumn PayComboBoxColumn = new DataGridViewComboBoxColumn();
                    PayComboBoxColumn.HeaderText = "支付方式選單";
                    PayComboBoxColumn.DataSource = DataModel.PaymentMethods;
                    dataGridView1.Columns[i].Visible = false;
                    dataGridView1.Columns.Insert(i + 1, PayComboBoxColumn);
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        dataGridView1.Rows[j].Cells[i + 1].Value = dataGridView1.Rows[j].Cells[i].Value;
                    }
                }
                if (dataGridView1.Columns[i].HeaderText == "圖檔1" || dataGridView1.Columns[i].HeaderText == "圖檔2")
                {
                    DataGridViewImageColumn ImageColumn = new DataGridViewImageColumn();
                    ImageColumn.HeaderText = dataGridView1.Columns[i].HeaderText.Replace("檔", "片");
                    ImageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    dataGridView1.Columns[i].Visible = false;
                    dataGridView1.Columns.Insert(i + 1, ImageColumn);
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        dataGridView1.Rows[j].Cells[i + 1].Value = Image.FromFile($@"C:\Users\user\Desktop\CsharpClass\Bookkeeping\Bookkeeping\bin\Debug\{dataGridView1.Rows[j].Cells[i].Value.ToString()}");
                        dataGridView1.Rows[j].Height = 120;
                    }
                }
            }
            // DaaGridView構成
            // DataGridViewColumn(欄) : 用反射抓取所有公開屬性,將每一個公開屬性都創建: DataGridViewTextBoxColumn
            // DataGridViewRow(列): 對list跑for迴圈創建每一個DataGridViewRow
            // DAtaGRidViewCell(格) : 對list當中的每一個item都創建一個DaaGridViewCel

            //HW: 隱藏原本圖片路徑欄位，新增圖片欄位，針對當前圖片路徑改成 DataGridViewImageColumn
        }
    }
}
