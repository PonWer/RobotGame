using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazorise.Charts;
using Blazorise.Charts.Streaming;
using Microsoft.AspNetCore.Components;
using RobotGame.Shared;

namespace RobotGame.Pages.Overview
{
    public partial class IndexBase : PageBase
    {
        [Inject] public ISyncLocalStorageService LocalStorage { get; set; }

        public LineChart<LiveDataPoint> horizontalLineChart;

        Random random = new Random(DateTime.Now.Millisecond);


        string[] Labels = { "Red", "Blue", "Yellow", "Green", "Purple", "Orange" };
        List<string> backgroundColors = new List<string> { ChartColor.FromRgba(255, 99, 132, 0.2f), ChartColor.FromRgba(54, 162, 235, 0.2f), ChartColor.FromRgba(255, 206, 86, 0.2f), ChartColor.FromRgba(75, 192, 192, 0.2f), ChartColor.FromRgba(153, 102, 255, 0.2f), ChartColor.FromRgba(255, 159, 64, 0.2f) };
        List<string> borderColors = new List<string> { ChartColor.FromRgba(255, 99, 132, 1f), ChartColor.FromRgba(54, 162, 235, 1f), ChartColor.FromRgba(255, 206, 86, 1f), ChartColor.FromRgba(75, 192, 192, 1f), ChartColor.FromRgba(153, 102, 255, 1f), ChartColor.FromRgba(255, 159, 64, 1f) };

        public struct LiveDataPoint
        {
            public object X { get; set; }

            public object Y { get; set; }
        }

        public object horizontalLineChartOptions = new
        {
            Title = new
            {
                Display = true,
                Text = "Line chart (horizontal scroll) sample"
            },
            Scales = new
            {
                YAxes = new object[]
                {
                new {
                    ScaleLabel = new {
                    Display = true, LabelString = "value" }
                }
                }
            },
            Tooltips = new
            {
                Mode = "nearest",
                Intersect = false
            },
            Hover = new
            {
                Mode = "nearest",
                Intersect = false
            }
        };

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Task.WhenAll(
                    HandleRedraw(horizontalLineChart, GetLineChartDataset1));
            }
        }

        public async Task HandleRedraw<TDataSet, TItem, TOptions, TModel>(BaseChart<TDataSet, TItem, TOptions, TModel> chart, params Func<TDataSet>[] getDataSets)
            where TDataSet : ChartDataset<TItem>
            where TOptions : ChartOptions
            where TModel : ChartModel
        {
            await chart.Clear();

            await chart.AddLabelsDatasetsAndUpdate(Labels, getDataSets.Select(x => x.Invoke()).ToArray());
        }

        public LineChartDataset<LiveDataPoint> GetLineChartDataset1()
        {
            return new LineChartDataset<LiveDataPoint>
            {
                Data = new List<LiveDataPoint>(),
                Label = "Energy History",
                BackgroundColor = backgroundColors[0],
                BorderColor = borderColors[0],
                Fill = false,
                LineTension = 0,
                BorderDash = new List<int> { },
            };
        }

        public Task OnHorizontalLineRefreshed(ChartStreamingData<LiveDataPoint> data)
        {
            data.Value = new LiveDataPoint
            {
                X = DateTime.Now,
                Y = ResourceManager.Instance.Energy,
            };

            return Task.CompletedTask;
        }
    }
}
