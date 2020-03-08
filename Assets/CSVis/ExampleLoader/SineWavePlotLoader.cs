using CSVis.ExampleLoader.Helper;
using CSVis.IO;
using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.ExampleLoader
{
    public class SineWavePlotLoader : PlotLoader
    {
        private const string Title = "Sine Wave";
        
        private const string XLabel = "X";
       
        private const string YLabel = "Y";
       
        private const int XIndex = 0;

        private const int YIndex = 1;

        private const string CsvResourcePath = "Data/sine_100";
        
        public override void LoadPlot()
        {
            var plot = Instantiate(GetSineWavePlotter());
            SetSpawn(plot.PointHolder);
        }

        public DataPlotter GetSineWavePlotter()
        {
            var columnsByName = CsvUtils.GetColumnsByIndex<float>(CsvResourcePath, XIndex, YIndex);

            var data = new StaticPlotHelper.StaticPlotData(
                Title,
                columnsByName[XIndex],
                columnsByName[YIndex],
                XLabel,
                YLabel
            );

            return StaticPlotHelper.GetStaticPlotter(data);
        }

    }
}
