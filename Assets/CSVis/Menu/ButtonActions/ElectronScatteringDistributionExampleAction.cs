using CSVis.IO;
using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.Menu.ButtonActions
{
    public class ElectronScatteringDistributionExampleAction : AbstractExampleAction
    {
        private const float PlotScale = 0.5f;
     
        private const string Title = "Election Scattering Distribution VS Time";
       
        private const int XIndex = 1;

        private const int YIndex = 2;
        
        private const int ZIndex = 0;

        private const string CsvResourcePath = "Data/C2_2";
        
        private const string TextResourcePath = "DataPlot/text3D";
        
        public void OnPress()
        {
            Debug.Log("LoadElectronScatteringExampleButton pressed");
            SetSpawnLocation(Instantiate(GetElectronPlot()));
        }

        private DataPlotter GetElectronPlot()
        {
            var csv = Resources.Load(CsvResourcePath) as TextAsset;
            var columnsByName = new CsvAssetReader(csv).GetColumnsByIndex(XIndex, YIndex, ZIndex);

            var plotter = new GameObject().AddComponent<DataPlotter>();

            plotter.PointHolder = new GameObject();

            var dataPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            plotter.PointPrefab = dataPoint;
            Destroy(dataPoint);

            plotter.Text = Resources.Load(TextResourcePath) as GameObject;

            plotter.Xpoints = columnsByName[XIndex];
            plotter.Ypoints = columnsByName[YIndex];
            plotter.Zpoints = columnsByName[ZIndex];

            plotter.titleName = Title;
            plotter.xName = "Time";
            plotter.yName = "Y";
            plotter.zName = "Z";

            plotter.plotScale = PlotScale;

            return plotter;
        }
    }
}
