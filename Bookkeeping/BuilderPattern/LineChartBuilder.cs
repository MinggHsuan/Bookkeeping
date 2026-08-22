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
    internal class LineChartBuilder : Builder
    {
        public Chart chart = new Chart();
        public int diff;
        public List<ChartModel> lastChartModels;
        public List<ChartModel> currentModels;
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
            Series last = new Series("上週");
            last.ChartType = SeriesChartType.Line;
            last.Label = "#VAL";
            last.Points.DataBindY(lastChartModels, "Value");
            if (lastChartModels.Count != diff)
            {
                for (int i = 0; i < Math.Abs(diff - lastChartModels.Count); i++)
                {
                    last.Points.AddY(0);
                }
            }
            chart.Series.Add(last);

            Series current = new Series("本週");
            current.ChartType = SeriesChartType.Line;
            current.Label = "#VAL";
            //for (int i = 0; i < end.Subtract(start).Days + 1; i++)
            //{
            //    var currentday = start.AddDays(i).ToString("MM-dd");
            //    if (currentModel.Any(x => x.Date == currentday))
            //    {
            //        current.Points.AddXY(currentday, currentModel[i].Value);
            //    }
            //    current.Points.AddXY(currentday, 0);
            //}
            current.Points.DataBind(currentModels, "Date", "Value", "");
            if (currentModels.Count != diff)
            {
                for (int i = 0; i < Math.Abs(diff - currentModels.Count); i++)
                {
                    current.Points.AddY(0);
                }
            }
            chart.Series.Add(current);

            return this;
        }

        public override Builder GetData(IRecordRepository recordRepository, DateTime start, DateTime end, List<string> groups, Dictionary<string, List<string>> filters, string weekOrMonth)
        {
            var chartModels = Service.ChartAnalyzeService(recordRepository, start, end, groups, filters);
            (diff, lastChartModels) = Service.ChartAnalyzeService(weekOrMonth, recordRepository, start, end, groups, filters);

            currentModels = chartModels.GroupBy(x => x.Date)
                .Select(x =>
                {
                    return new ChartModel(x.Key, string.Join(",", x.GroupBy(y => y.Name).Select(z => z.Key)), x.Sum(z => int.Parse(z.Value)).ToString());
                }).ToList();

            return this;
        }

        public override Chart Build()
        {
            return chart;
        }
    }
}
