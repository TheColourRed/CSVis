using System.Collections.Generic;
using DataVisualization.Plotter;
using TimeSeriesExtension;
using UnityEngine;

namespace CSVis.ExampleLoader
{
    
    public class DynamicDronePlotter : PlotLoader
    {
        private const string Title = "Drone Flight Path";
           
        private const string XHeader = "latitude";

        private const string YHeader = "altitude (m)";
            
        private const string ZHeader = "longitude";
        
        private const string TimeHeader = "time(local time)";

        private const string CsvResourcePath = "Data/FlightData2";

        public override void LoadPlot()
        {
            var dynamicPlotter = GetDynamicDronePlotter();
            var staticPlotter = GetStaticDronePlotter();

            dynamicPlotter.PlotScale = 1;
            staticPlotter.plotScale = 1;

            var pointHolder = dynamicPlotter.PointHolder;
            staticPlotter.PointHolder = pointHolder;
            
            var staticExample = Instantiate(staticPlotter);
            var dynamicExample = Instantiate(dynamicPlotter);

            SetSpawn(dynamicExample.PointHolder);
            SetSpawn(staticExample.PointHolder);
        }

        public DynamicPlotter GetDynamicDronePlotter()
        {
            var columnsByName = CsvUtils.GetColumnsByHeader<float>(CsvResourcePath, XHeader, YHeader, ZHeader);
            var times = CsvUtils.GetColumnsByHeader<string>(CsvResourcePath, TimeHeader)[TimeHeader];

            var pointColumns =
                new List<DynamicPlotterHelper.DynamicPlotData.PointColumns>()
                {
                    new DynamicPlotterHelper.DynamicPlotData.PointColumns(
                        columnsByName[XHeader],
                        columnsByName[YHeader],
                        columnsByName[ZHeader]
                    )
                };

            var data = new DynamicPlotterHelper.DynamicPlotData(
                Title,
                pointColumns,
                times,
                XHeader,
                YHeader,
                ZHeader
            );

            return gameObject.AddComponent<DynamicPlotterHelper>().GetDynamicPlotter(data);
        }
        
        public DataPlotter GetStaticDronePlotter()
        {
            var columnsByName = CsvUtils.GetColumnsByHeader<float>(CsvResourcePath, XHeader, YHeader, ZHeader);

            var data = new StaticPlotHelper.StaticPlotData(
                "",
                columnsByName[XHeader],
                columnsByName[YHeader],
                columnsByName[ZHeader],
                "",
                "",
                ""
            );

            return gameObject.AddComponent<StaticPlotHelper>().GetStaticPlotter(data);
        }
    }
}