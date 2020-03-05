using CSVis.IO;
using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.Menu.ButtonActions
{
    public class SineWaveExampleAction : AbstractExampleAction
    {
        private const float PlotScale = 0.5f;
     
        private const string Title = "Sine Wave";
       
        private const int XIndex = 0;

        private const int YIndex = 1;

        private const string CsvResourcePath = "Data/sine_100";
        
        private const string TextResourcePath = "DataPlot/text3D";

        public void OnPress()
        {
            Debug.Log("LoadSineExampleButton pressed");
            SetSpawnLocation(Instantiate(GetSinePlot()));
        }

        private DataPlotter GetSinePlot()
        {
            var csv = Resources.Load(CsvResourcePath) as TextAsset;
            var columnsByName = new CsvAssetReader(csv).GetColumnsByIndex<float>(XIndex, YIndex);

            var plotter = new GameObject().AddComponent<DataPlotter>();

            plotter.PointHolder = new GameObject();

            var dataPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            plotter.PointPrefab = dataPoint;
            Destroy(dataPoint);

            plotter.Text = Resources.Load(TextResourcePath) as GameObject;

            plotter.Xpoints = columnsByName[XIndex];
            plotter.Ypoints = columnsByName[YIndex];

            plotter.titleName = Title;
            plotter.xName = "X";
            plotter.yName = "Y";

            plotter.plotScale = PlotScale;

            return plotter;
        }

    }
}
