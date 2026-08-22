using Bookkeeping.Contract;
using Bookkeeping.Models;
using Bookkeeping.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Bookkeeping.Presenter
{
    public class GroupRecordPresenter : GroupRecordContract.IPresenter
    {
        private IRecordRepository recordRepository;
        private GroupRecordContract.IView View { get; set; }
        public GroupRecordPresenter(GroupRecordContract.IView _View)
        {
            View = _View;
            recordRepository = new IRepository();
        }

        public void GetResult(DateTime start, DateTime end, List<string> groups, Dictionary<string, List<string>> filters)
        {
            var groupRecords = Service.AnalyzeService(recordRepository, start, end, groups, filters);
            View.OnGetResult(groupRecords);
        }
    }
}
