using Bookkeeping.Models;
using Bookkeeping.Presenter;
using Bookkeeping.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Bookkeeping.BuilderPattern
{
    internal class PieChartBuilder : Builder
    {
        public Chart chart = new Chart();
        public List<GroupRecord> groupRecords;
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
            Series series = new Series();
            chart.Series.Add(series);
            chart.Series[0].ChartType = SeriesChartType.Pie;
            chart.Series[0]["PieLabelStyle"] = "Outside";
            chart.Series[0]["PieLineColor"] = " Blue";
            chart.Series[0].Label = "#VAL";
            chart.Series[0].LegendText = "#VALX";
            chart.Series[0].ToolTip = "#VALX:#VAL-佔#PERCENT{P0}";
            chart.Series[0].Points.DataBind(groupRecords, "Name", "Value", "");
            return this;
        }


        public override Builder GetData(IRecordRepository recordRepository, DateTime start, DateTime end, List<string> groups, Dictionary<string, List<string>> filters, string weekOrMouth)
        {
            groupRecords = Service.AnalyzeService(recordRepository, start, end, groups, filters);
            return this;
        }

        public override Chart Build()
        {
            return chart;
        }


    }
}
