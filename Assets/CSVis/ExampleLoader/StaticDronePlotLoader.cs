using CSVis.ExampleLoader.Helper;
using CSVis.IO;
using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.ExampleLoader
{
    public class StaticDronePlotLoader : PlotLoader
    {
        private const string Title = "Drone Flight Path";
       
        private const string XHeader = "latitude";

        private const string YHeader = "altitude (m)";
        
        private const string ZHeader = "longitude";

        private const string CsvResourcePath = "Data/FlightData2";
        
        public override void LoadPlot()
        {
            var plot = Instantiate(GetDronePlotter());
            SetSpawn(plot.PointHolder);
        }

        public DataPlotter GetDronePlotter()
        {
            var columnsByName = CsvUtils.GetColumnsByHeader<float>(CsvResourcePath, XHeader, YHeader, ZHeader);

            var data = new StaticPlotHelper.StaticPlotData(
                Title,
                columnsByName[XHeader],
                columnsByName[YHeader],
                columnsByName[ZHeader],
                XHeader,
                YHeader,
                ZHeader
            );

            return StaticPlotHelper.GetStaticPlotter(data);
        }

    }
}
