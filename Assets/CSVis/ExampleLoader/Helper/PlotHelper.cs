using UnityEngine;

namespace CSVis.ExampleLoader.Helper
{
    public abstract class PlotHelper : MonoBehaviour
    {
        protected const float DefaultPlotScale = 0.5f;
        
        private const string Text3DPath = "DataPlot/text3D";
        
        private const string PlotContainerPath = "CSVis/PlotContainer"; 
        
        private const string DataPointPath = "DataPlot/DataPoint";
        
        public static GameObject GetPlotHolder()
        {
            return Instantiate((GameObject) Resources.Load(PlotContainerPath))
                .transform.Find("PlotHolder")
                .gameObject;
        }

        public static GameObject GetDataPoint()
        {
            return (GameObject)Resources.Load(DataPointPath);
        }

        public static GameObject GetText3D()
        {
            return (GameObject)Resources.Load(Text3DPath);
        }
    }
}