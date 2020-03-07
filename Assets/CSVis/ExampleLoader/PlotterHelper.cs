using UnityEngine;

namespace CSVis.ExampleLoader
{
    public abstract class PlotterHelper : MonoBehaviour
    {
        protected const float DefaultPlotScale = 0.5f;
        
        private const string Text3DPath = "DataPlot/text3D";
        
        private const string PlotContainerPath = "CSVis/PlotContainer"; 
        
        private const string DataPointPath = "DataPlot/DataPoint";
        
        protected static GameObject GetPlotContainer()
        {
            return Instantiate((GameObject) Resources.Load(PlotContainerPath));
        }

        protected static GameObject GetDataPoint()
        {
            return (GameObject)Resources.Load(DataPointPath);
        }

        protected static GameObject GetText3D()
        {
            return (GameObject)Resources.Load(Text3DPath);
        }
    }
}