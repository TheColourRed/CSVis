using System.Linq;
using CSVis.ExampleLoader.Helper;
using CSVis.IO;
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

        private const string ClassHeader = "variety";
        
        private const string XName = "Petal Length";

        private const string YName = "Sepal Length";

        private const string ZName = "Petal Width";

        private const string ClassOne = "Setosa";
        
        private const string ClassTwo = "Versicolor";
        
        private const string ClassThree = "Virginica";

        private const string CsvResourcePath = "Data/iris";

        public override void LoadPlot()
        {
            var plot = Instantiate(GetIrisDataPlotter());
            SetSpawn(plot.PointHolder);
        }

        public DataPlotter GetIrisDataPlotter()
        {
            var columnsByName = CsvUtils.GetColumnsByHeader<float>(CsvResourcePath, XHeader, YHeader, ZHeader);
            var classByName = CsvUtils.GetColumnsByHeader<string>(CsvResourcePath, ClassHeader)[ClassHeader];

            var data = new StaticPlotHelper.StaticPlotData(
                Title,
                columnsByName[XHeader],
                columnsByName[YHeader],
                columnsByName[ZHeader],
                XName,
                YName,
                ZName
            );

            data.Colors = classByName.Select(GetColorByClass).ToList();
            
            return StaticPlotHelper.GetStaticPlotter(data);
        }

        private Color GetColorByClass(string className) 
        {
            switch (className)
            {
                case ClassOne:
                    return new Color(255, 0, 0);
                case ClassTwo:
                    return new Color(0, 255, 0);
                case ClassThree:
                    return new Color(0, 0, 255);
                default:
                    return new Color(0, 0, 0);
            }
        }
    }
}
