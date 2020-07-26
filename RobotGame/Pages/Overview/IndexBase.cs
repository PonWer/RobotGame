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
#pragma warning disable 618

namespace RobotGame.Pages.Overview
{
    public partial class IndexBase : PageBase
    {
        [Inject] public ISyncLocalStorageService LocalStorage { get; set; }

        public LineChart<LiveDataPoint> EnergyChart;
        public LineChart<LiveDataPoint> WoodChart;

        public string ChartOptions = "{\"title\":{\"display\":false},\"legend\":{\"display\":false},\"scales\":{\"xAxes\":[{\"display\":false,\"gridLines\":{\"display\":false}}],\"yAxes\":[{\"scaleLabel\":{\"display\":false},\"gridLines\":{\"display\":false},\"ticks\":{\"beginAtZero\":true}}]},\"Tooltips\":{\"enabled\":false},\"Hover\":{\"enabled\":false}}";

        public struct LiveDataPoint
        {
            public object X { get; set; }

            public object Y { get; set; }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await Task.WhenAll(HandleRedraw(EnergyChart, GetDataSetEnergy));
                await Task.WhenAll(HandleRedraw(WoodChart, GetDataSetWood));
            }
        }

        public async Task HandleRedraw<TDataSet, TItem, TOptions, TModel>(BaseChart<TDataSet, TItem, TOptions, TModel> chart, params Func<TDataSet>[] getDataSets)
            where TDataSet : ChartDataset<TItem>
            where TOptions : ChartOptions
            where TModel : ChartModel
        {
            await chart.Clear();
            chart.OptionsJsonString = ChartOptions;
            await chart.AddLabelsDatasetsAndUpdate(new[]{"","","","","","","","","","","","","","",""}, getDataSets.Select(x => x.Invoke()).ToArray());
        }

        public LineChartDataset<LiveDataPoint> GetDataSetEnergy()
        {
            var energyHistory = new List<LiveDataPoint>();
            for (var i = ResourceManager.Instance.EnergyHistory.Count - 1; i >= 0; i--)
            {
                energyHistory.Add(new LiveDataPoint(){X = ResourceManager.Instance.EnergyHistory[i],Y = DateTime.Now.AddSeconds(i * -1)});
            }
            return new LineChartDataset<LiveDataPoint>
            {
                Data = energyHistory,
                Label = "Energy History",
                BackgroundColor = ChartColor.FromRgba(255, 99, 132, 1f),
                BorderColor = ChartColor.FromRgba(255, 99, 132, 1f),
                Fill = false,
                LineTension = 0,
                BorderWidth = 10,
                BorderDash = new List<int> { },
            };
        }
        public LineChartDataset<LiveDataPoint> GetDataSetWood()
        {
            return new LineChartDataset<LiveDataPoint>
            {
                Data = new List<LiveDataPoint>(),
                Label = "Wood History",
                BackgroundColor = ChartColor.FromRgba(255, 99, 132, 0.2f),
                BorderColor = ChartColor.FromRgba(255, 99, 132, 1f),
                Fill = false,
                LineTension = 0,
                BorderWidth = 10,
                BorderDash = new List<int> { },
            };
        }

        public Task OnHorizontalLineRefreshedEnergy(ChartStreamingData<LiveDataPoint> data)
        {
            data.Value = new LiveDataPoint
            {
                X = DateTime.Now,
                Y = ResourceManager.Instance.Energy,
            };
            return Task.CompletedTask;
        }

        public Task OnHorizontalLineRefreshedWood(ChartStreamingData<LiveDataPoint> data)
        {
            data.Value = new LiveDataPoint
            {
                X = DateTime.Now,
                Y = ResourceManager.Instance.Wood,
            };
            return Task.CompletedTask;
        }
    }
}
