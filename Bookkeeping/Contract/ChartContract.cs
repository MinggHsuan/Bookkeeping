using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Bookkeeping.Contract
{
    public class ChartContract
    {
        public interface IView
        {
            void OnGetChart(Chart chart);
        }
        public interface IPresenter
        {
            void GetChart(int chartIndex, string weekOrMonth, DateTime start, DateTime end, List<string> groups, Dictionary<string, List<string>> filters);

        }
    }
}
