using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.Menu
{
    public class GeographicMapsMenuController : MonoBehaviour
    {

        private const string TextResourcePath = "DataPlot/text3D";
        
        public void InitCarletonUniversityMap()
        {
            Debug.Log("Plotting Geo Map");
            var mapBox = new GameObject();
            var map = mapBox.AddComponent<mrMap>();

            map.location = "45.3831, -75.6976";
            map.titleName = "Carleton University";
            map.zoom = 16;
            map.plotScale = 0.5f;
            map.MapHolder = new GameObject();

            map.Text = Resources.Load(TextResourcePath) as GameObject;
            
            Debug.Log("Done Loading");
        }

    }
}