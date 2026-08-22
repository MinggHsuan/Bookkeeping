using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookkeeping.Models
{
    public class GroupRecord
    {
        [DisplayName("群組")]
        public string Name { get; set; }
        [DisplayName("金額")]
        public string Value { get; set; }

        public GroupRecord(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
