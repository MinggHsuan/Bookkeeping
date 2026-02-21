using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookkeeping.Models
{
    public class RecordModel
    {
        [DisplayName("日期")]
        public string Date { get; set; }
        [DisplayName("金額")]
        public string Price { get; set; }
        [DisplayName("類型")]
        public string Type { get; set; }
        [DisplayName("細項")]
        public string Detail { get; set; }
        [DisplayName("對象")]
        public string Target { get; set; }
        [DisplayName("支付方式")]
        public string PaymentMethods { get; set; }
        [DisplayName("圖檔1")]
        public string Image1 { get; set; }
        [DisplayName("圖檔2")]
        public string Image2 { get; set; }
        //[DisplayName("圖片1")]
        //public Image ImageIcon1 { get; set; }
        //[DisplayName("圖片2")]
        //public Image ImageIcon2 { get; set; }
        public RecordModel(string date, string price, string type, string detail, string target, string payment, string image1, string image2)
        {
            this.Date = date;
            this.Price = price;
            this.Type = type;
            this.Detail = detail;
            this.Target = target;
            this.PaymentMethods = payment;
            this.Image1 = image1;
            this.Image2 = image2;
            //this.ImageIcon1 = ImageIcon1;
            //this.ImageIcon2 = ImageIcon2;
        }


        public RecordModel()
        {
        }
    }
}
