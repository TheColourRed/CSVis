using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.ExampleLoader
{
    public class IrisDataSetPlotLoader : PlotLoader
    {
        
        private const string Title = "Iris Dataset";
       
        private const string XHeader = "petal.length";

        private const string YHeader = "sepal.length";
        
        private const string ZHeader = "petal.width";
               
        private const string XName = "Petal Length";

        private const string YName = "Sepal Length";
        
        private const string ZName = "Petal Width";

        private const string CsvResourcePath = "Data/iris";

        public override void LoadPlot()
        {
            var plot = Instantiate(GetIrisDataPlotter());
            SetSpawn(plot.PointHolder);
        }

        public DataPlotter GetIrisDataPlotter()
        {
            var columnsByName = CsvUtils.GetColumnsByHeader<float>(CsvResourcePath, XHeader, YHeader, ZHeader);

            var data = new StaticPlotHelper.StaticPlotData(
                Title,
                columnsByName[XHeader],
                columnsByName[YHeader],
                columnsByName[ZHeader],
                XName,
                YName,
                ZName
            );

            return gameObject.AddComponent<StaticPlotHelper>().GetStaticPlotter(data);
        }
    }
}
