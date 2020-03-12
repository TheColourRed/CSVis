using System.Collections.Generic;
using System.Linq;
using CSVis.ExampleLoader.Helper;
using CSVis.IO;
using DataVisualization.Plotter;

namespace CSVis.ExampleLoader
{
    public class DynamicSineWavePlotLoader : PlotLoader
    {
        private const string Title = "Sine Wave";
        
        private const string XLabel = "X";
       
        private const string YLabel = "Y";
       
        private const int XIndex = 0;

        private const int YIndex = 1;

        private const string CsvResourcePath = "Data/sine_1000";
        
        public override void LoadPlot()
        {
            var plot = Instantiate(GetSineWavePlotter());
            SetSpawn(plot.PointHolder);
        }

        public DynamicPlotter GetSineWavePlotter()
        {
            var columnsByName = CsvUtils.GetColumnsByIndex<float>(CsvResourcePath, XIndex, YIndex);
            var capacity = columnsByName[XIndex].Count;
            var pointColumns = new List<DynamicPlotHelper.DynamicPlotData.PointColumns>();
            
            pointColumns.Add(
                new DynamicPlotHelper.DynamicPlotData.PointColumns(
                    columnsByName[XIndex],
                    columnsByName[YIndex],
                    Enumerable.Range(0, capacity).Select(i => 0.5f).ToList()
                ));
            
            var times = CsvUtils.GetColumnsByIndex<string>(CsvResourcePath, XIndex)[XIndex];

            var data = new DynamicPlotHelper.DynamicPlotData(
                Title,
                pointColumns,
                times,
                XLabel,
                YLabel,
                ""
            );

            return DynamicPlotHelper.GetDynamicPlotter(data);
        }
    }
}