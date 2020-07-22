using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazorise;
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

        string[] Labels = { "Red", "Blue", "Yellow", "Green", "Purple", "Orange" };

        public struct LiveDataPoint
        {
            public object X { get; set; }

            public object Y { get; set; }
        }

        public object horizontalLineChartOptions = new
        {
            Title = new
            {
                Display = false,
                Text = "Line chart (horizontal scroll) sample"
            },
            Legend = new 
            {
                Display = false
            },
            gridLines = new
            {
                display = false
            },
            Scales = new
            {
                YAxes = new object[]
                {
                    new{
                        Ticks = new
                        {
                            beginAtZero = true
                        }
                    }
                },
                XAxes = new object[]
                {
                    new{
                        display = false
                    }
                }
            },
            Tooltips = new
            {
                Enabled = false
            },
            Hover = new
            {
                Enabled = false
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
                BackgroundColor = ChartColor.FromRgba(255, 99, 132, 0.2f),
                BorderColor = ChartColor.FromRgba(255, 99, 132, 1f),
                Fill = false,
                LineTension = 0,
                BorderWidth = 10,
                BorderDash = new List<int> {},
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
