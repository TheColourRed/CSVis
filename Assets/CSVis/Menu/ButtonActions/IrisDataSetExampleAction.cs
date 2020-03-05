using CSVis.IO;
using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.Menu.ButtonActions
{
    public class IrisDataSetExampleAction : AbstractExampleAction
    {
        
        private const float PlotScale = 0.5f;
     
        private const string Title = "Iris Dataset";
       
        private const string XHeader = "petal.length";

        private const string YHeader = "sepal.length";
        
        private const string ZHeader = "petal.width";

        private const string CsvResourcePath = "Data/iris";
        
        private const string TextResourcePath = "DataPlot/text3D";

        public void OnPress()
        {
            Debug.Log("LoadIrisDatasetExampleButton pressed");
            SetSpawnLocation(Instantiate(GetIrisPlot()));
        }

        private static DataPlotter GetIrisPlot()
        {
            var csv = Resources.Load(CsvResourcePath) as TextAsset;
            var columnsByName = new CsvAssetReader(csv).GetColumnsByHeader<float>(XHeader, YHeader, ZHeader);

            var plotter = new GameObject().AddComponent<DataPlotter>();

            plotter.PointHolder = new GameObject();

            var dataPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            plotter.PointPrefab = dataPoint;
            Destroy(dataPoint);

            plotter.Text = Resources.Load(TextResourcePath) as GameObject;

            plotter.Xpoints = columnsByName[XHeader];
            plotter.Ypoints = columnsByName[YHeader];
            plotter.Zpoints = columnsByName[ZHeader];

            plotter.titleName = Title;
            plotter.xName = XHeader;
            plotter.yName = YHeader;
            plotter.zName = ZHeader;

            plotter.plotScale = PlotScale;

            return plotter;
        }
    
    }
}
