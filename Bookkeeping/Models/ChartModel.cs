using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookkeeping.Models
{
    internal class ChartModel
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public ChartModel(string date, string name, string value)
        {
            this.Date = date;
            this.Name = name;
            this.Value = value;
        }
    }
}
