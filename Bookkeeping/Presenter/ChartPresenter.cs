using Bookkeeping.BuilderPattern;
using Bookkeeping.Contract;
using Bookkeeping.Models;
using Bookkeeping.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Bookkeeping.Presenter
{

    internal class ChartPresenter : ChartContract.IPresenter
    {
        public ChartContract.IView View;
        public IRecordRepository recordRepository;
        public ChartPresenter(ChartContract.IView view)
        {
            View = view;
            recordRepository = new IRepository();
        }

        public void GetChart(int chartIndex, string weekOrMonth, DateTime start, DateTime end, List<string> groups, Dictionary<string, List<string>> filters)
        {
            Type type = Type.GetType("Bookkeeping.BuilderPattern." + (ChartType)chartIndex);
            var builder = (Builder)Activator.CreateInstance(type);
            Chart chart = builder.BuildChart()
                .BuildChartArea()
                .BuildLegend()
                .GetData(recordRepository, start, end, groups, filters, weekOrMonth)
                .BuildSeries()
                .Build();

            View.OnGetChart(chart);
        }


    }
}
