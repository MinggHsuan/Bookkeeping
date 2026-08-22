using AutoMapper.Configuration.Conventions;
using Bookkeeping.Models;
using Bookkeeping.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Bookkeeping.Presenter
{
    internal class Service
    {
        public static List<GroupRecord> AnalyzeService(IRecordRepository recordRepository, DateTime start, DateTime end, List<string> groups, Dictionary<string, List<string>> filters)
        {
            var records = recordRepository.GetRecords(start, end);
            var modelType = (string[])typeof(DataModel).GetField("Type").GetValue(new DataModel());
            var dict = typeof(RecordModel).GetProperties()
                .Select(x =>
                {
                    string name = x.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                    string target = x.Name;
                    return new { name, target };
                }).ToDictionary(x => x.name, y => y.target);


            List<GroupRecord> groupRecords = new List<GroupRecord>();
            groupRecords.AddRange(records
                .Where(x =>
                {
                    if (filters.Count == 0)
                    {
                        return true;
                    }
                    var isbool = filters.Select(y =>
                    {
                        if (modelType.Contains(y.Key))
                        {
                            return filters[y.Key].Contains(x.Detail);
                        }
                        return filters[y.Key].Contains(x.GetType().GetProperty(y.Key).GetValue(x));

                    }).ToList();

                    return isbool.Contains(true);
                })
                .GroupBy(x =>
                {
                    return string.Join(",", groups.Select((y, index) => x.GetType().GetProperty(dict[groups[index]]).GetValue(x).ToString()));
                })
                .Select(x =>
                {
                    int price = x.Sum(y => int.Parse(y.Price));
                    return new GroupRecord(x.Key, price.ToString());
                }));

            return groupRecords;
        }

        public static List<ChartModel> ChartAnalyzeService(IRecordRepository recordRepository, DateTime start, DateTime end, List<string> groups, Dictionary<string, List<string>> filters)
        {
            var records = recordRepository.GetRecords(start, end);
            var modelType = (string[])typeof(DataModel).GetField("Type").GetValue(new DataModel());
            var dict = typeof(RecordModel).GetProperties()
                .Select(x =>
                {
                    string name = x.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                    string target = x.Name;
                    return new { name, target };
                }).ToDictionary(x => x.name, y => y.target);


            List<ChartModel> chartModels = new List<ChartModel>();
            chartModels.AddRange(records
                .Where(x =>
                {
                    if (filters.Count == 0)
                    {
                        return true;
                    }
                    var isbool = filters.Select(y =>
                    {
                        if (modelType.Contains(y.Key))
                        {
                            return filters[y.Key].Contains(x.Detail);
                        }
                        return filters[y.Key].Contains(x.GetType().GetProperty(y.Key).GetValue(x));

                    }).ToList();

                    return isbool.Contains(true);
                })
                .GroupBy(x =>
                {
                    return $"{x.Date.Substring(5)}|{string.Join(",", groups.Select((y, index) => x.GetType().GetProperty(dict[groups[index]]).GetValue(x).ToString()))}";
                })
                .Select(x =>
                {
                    int price = x.Sum(y => int.Parse(y.Price));
                    return new ChartModel(x.Key.Split('|')[0], x.Key.Split('|')[1], price.ToString());
                }));

            return chartModels;
        }

        public static (int, List<ChartModel>) ChartAnalyzeService(string weekOrMonth, IRecordRepository recordRepository, DateTime start, DateTime end, List<string> groups, Dictionary<string, List<string>> filters)
        {
            List<ChartModel> lastChartModels = null;
            int diff = 0;
            switch (weekOrMonth)
            {
                case "本週":
                    DateTime weekEnd = end.AddDays(-7);
                    DateTime weekStart = start.AddDays(-7);
                    diff = 7;
                    lastChartModels = Service.ChartAnalyzeService(recordRepository, weekStart, weekEnd, groups, filters);
                    break;
                case "本月":
                    DateTime monthEnd = end.AddDays(-30);
                    DateTime monthStart = start.AddDays(-30);
                    diff = 30;
                    lastChartModels = Service.ChartAnalyzeService(recordRepository, monthStart, monthEnd, groups, filters);
                    break;
            }
            return (diff, lastChartModels);
        }
    }
}
