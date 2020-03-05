using CSVis.IO;
using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.Menu.ButtonActions
{
    public class DroneExampleAction : AbstractExampleAction
    {
        private const float PlotScale = 0.5f;
     
        private const string Title = "Drone Flight Path";
       
        private const string XHeader = "latitude";

        private const string YHeader = "altitude (m)";
        
        private const string ZHeader = "longitude";

        private const string CsvResourcePath = "Data/FlightData2";
        
        private const string TextResourcePath = "DataPlot/text3D";

        public void OnPress()
        {
            Debug.Log("LoadDroneExampleButton pressed");
            SetSpawnLocation(Instantiate(GetDronePlot()));
        }

        private static DataPlotter GetDronePlot()
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
