using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Charts;
using Microsoft.AspNetCore.Components;
using RobotGame.Shared;

namespace RobotGame.Pages.Overview
{
    public partial class IndexBase : PageBase
    {
        [Inject] public ISyncLocalStorageService LocalStorage { get; set; }

        public LineChart<double> EnergyChart;
        public LineChart<double> WoodChart;
        public LineChart<double> IronChart;

        //Non escaped option string
        //{"animation":{"duration":0},"title":{"display":false},"legend":{"display":false},"scales":{"xAxes":[{"display":false,"gridLines":{"display":false}}],"yAxes":[{"scaleLabel":{"display":false},"ticks":{"beginAtZero":true}}]},"tooltips":{"enabled":false},"hover":{"enabled":false}}
        public string ChartOptions = "{\"animation\":{\"duration\":0},\"title\":{\"display\":false},\"legend\":{\"display\":false},\"scales\":{\"xAxes\":[{\"display\":false,\"gridLines\":{\"display\":false}}],\"yAxes\":[{\"scaleLabel\":{\"display\":false},\"ticks\":{\"beginAtZero\":true}}]},\"tooltips\":{\"enabled\":false},\"hover\":{\"enabled\":false}}";

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await HandleRedraw();
            }
        }

        async Task HandleRedraw()
        {
            await EnergyChart.Clear();
            await EnergyChart.AddLabel(ResourceManager.Instance.EnergyHistory.Select(x => string.Empty).ToArray());
            await EnergyChart.AddDataSet(new LineChartDataset<double>
            {
                Data = ResourceManager.Instance.EnergyHistory,
                Label = "Energy History",
                Fill = true,
                BorderWidth = 10,
                BorderDash = new List<int> { },
                PointRadius = 2,
            });
            await EnergyChart.Update();

            await WoodChart.Clear();
            await WoodChart.AddLabel(ResourceManager.Instance.WoodHistory.Select(x => string.Empty).ToArray());
            await WoodChart.AddDataSet(new LineChartDataset<double>
            {
                Data = ResourceManager.Instance.WoodHistory,
                Label = "Wood History",
                Fill = true,
                BorderWidth = 10,
                BorderDash = new List<int> { },
                PointRadius = 2
            });
            await WoodChart.Update();

            await IronChart.Clear();
            await IronChart.AddLabel(ResourceManager.Instance.IronHistory.Select(x => string.Empty).ToArray());
            await IronChart.AddDataSet(new LineChartDataset<double>
            {
                Data = ResourceManager.Instance.IronHistory,
                Label = "Iron History",
                Fill = true,
                BorderWidth = 10,
                BorderDash = new List<int> { },
                PointRadius = 2,
            });
            await IronChart.Update();
        }

        protected override async void GameOnUpdated(object sender, EventArgs e)
        {
            await HandleRedraw();
            base.GameOnUpdated(sender, e);
        }
    }
}
