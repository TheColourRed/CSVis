using CSVis.ExampleLoader;
using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.Menu.MenuControllers
{
    public class GeographicMapsMenuController : MonoBehaviour
    {

        private const string TextResourcePath = "DataPlot/text3D";
        
        public void OnClickCarletonUniversityExample()
        {
            gameObject.AddComponent<CarletonUniversityMapPlotLoader>().LoadPlot();
        }

        public void OnClickDroneExample()
        {
            gameObject.AddComponent<DroneMapPlotLoader>().LoadPlot();
        }
        
    }
}