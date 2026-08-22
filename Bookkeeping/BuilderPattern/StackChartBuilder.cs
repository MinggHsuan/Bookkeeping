using Bookkeeping.Models;
using Bookkeeping.Presenter;
using Bookkeeping.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Bookkeeping.BuilderPattern
{
    internal class StackChartBuilder : Builder
    {
        public Chart chart = new Chart();
        public List<ChartModel> chartModels;
        public override Builder BuildChart()
        {
            chart.Titles.Add("分析");
            return this;
        }

        public override Builder BuildChartArea()
        {
            ChartArea chartArea = new ChartArea();
            chart.ChartAreas.Add(chartArea);
            return this;
        }
        public override Builder BuildLegend()
        {
            Legend legend = new Legend();
            chart.Legends.Add(legend);
            return this;
        }
        public override Builder BuildSeries()
        {
            var charts = chartModels.GroupBy(x => x.Name).ToList();
            foreach (var model in charts)
            {
                Series series = new Series(model.Key);
                series.ChartType = SeriesChartType.StackedColumn;
                series.Label = "#VAL";
                series.ToolTip = "#VALX:#VAL-佔#PERCENT{P0}";
                series.Points.DataBind(model, "Date", "Value", "");
                chart.Series.Add(series);
            }
            return this;
        }



        public override Builder GetData(IRecordRepository recordRepository, DateTime start, DateTime end, List<string> groups, Dictionary<string, List<string>> filters, string weekOrMouth)
        {
            chartModels = Service.ChartAnalyzeService(recordRepository, start, end, groups, filters);
            return this;
        }

        public override Chart Build()
        {
            return chart;
        }
    }
}
