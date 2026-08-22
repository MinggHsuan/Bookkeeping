using Bookkeeping.Models;
using Bookkeeping.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookkeeping.Contract
{
    public class GroupRecordContract
    {
        public interface IView
        {
            void OnGetResult(List<GroupRecord> groupRecords);
        }
        public interface IPresenter
        {
            void GetResult(DateTime start, DateTime end, List<string> groups, Dictionary<string, List<string>> filters);
        }
    }
}
