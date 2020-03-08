using System.Collections.Generic;
using CSVis.ExampleLoader.Helper;
using CSVis.IO;
using TimeSeriesExtension;

namespace CSVis.ExampleLoader
{
    public class DynamicElectronScatteringPlotLoader : PlotLoader
    {
        private const string Title = "Election Scattering Distribution";
       
        private const int XIndex = 1;

        private const int YIndex = 2;
        
        private const int ZIndex = 0;
                       
        private const string XName = "Time";

        private const string YName = "Y";
        
        private const string ZName = "Z";

        private const string CsvResourcePath = "Data/C2_2";
        
        public override void LoadPlot()
        {
            var plot = Instantiate(GetElectronScatterPlotter());
            SetSpawn(plot.PointHolder);
        }

        public DynamicPlotter GetElectronScatterPlotter()
        {
            var columnsByName = CsvUtils.GetColumnsByIndex<float>(CsvResourcePath, XIndex, YIndex, ZIndex);
            var times = CsvUtils.GetColumnsByIndex<string>(CsvResourcePath, XIndex)[XIndex];

            var pointColumns =
                new List<DynamicPlotHelper.DynamicPlotData.PointColumns>()
                {
                    new DynamicPlotHelper.DynamicPlotData.PointColumns(
                        columnsByName[XIndex],
                        columnsByName[YIndex],
                        columnsByName[ZIndex]
                    )
                };

            var data = new DynamicPlotHelper.DynamicPlotData(
                Title,
                pointColumns,
                times,
                XName,
                YName,
                ZName
            );

            return DynamicPlotHelper.GetDynamicPlotter(data);
        }
    }
}