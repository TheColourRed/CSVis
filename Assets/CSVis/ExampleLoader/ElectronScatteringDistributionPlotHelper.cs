using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.ExampleLoader
{
    public class ElectronScatteringDistributionPlotHelper : PlotLoader
    {
        private const string Title = "Election Scattering Distribution VS Time";
       
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

        public DataPlotter GetElectronScatterPlotter()
        {
            var columnsByName = CsvUtils.GetColumnsByIndex<float>(CsvResourcePath, XIndex, YIndex, ZIndex);

            var data = new StaticPlotHelper.StaticPlotData(
                Title,
                columnsByName[XIndex],
                columnsByName[XIndex],
                columnsByName[XIndex],
                XName,
                YName,
                ZName
            );

            return gameObject.AddComponent<StaticPlotHelper>().GetStaticPlotter(data);
        }
    }
}
