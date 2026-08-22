using Bookkeeping.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Bookkeeping.BuilderPattern
{
    internal abstract class Builder
    {

        public abstract Builder BuildChart();
        public abstract Builder BuildChartArea();
        public abstract Builder BuildLegend();
        public abstract Builder BuildSeries();
        public abstract Builder GetData(IRecordRepository recordRepository, DateTime start, DateTime end, List<string> groups, Dictionary<string, List<string>> filters, string weekOrMouth = "week");

        public abstract Chart Build();
    }
}
