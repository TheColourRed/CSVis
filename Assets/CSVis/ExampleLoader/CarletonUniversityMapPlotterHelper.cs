using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.ExampleLoader
{
    public class CarletonUniversityMapPlotterHelper : PlotLoader
    {
        private const float Longitude = 45.3831f;
        
        private const float Latitude = -75.6976f;
        
        private const int Zoom = 16;
        
        private const string Title = "Carleton University";
        
        public override void LoadPlot()
        {
            var map = Instantiate(GetCarletonMapper());
            SetSpawn(map.MapHolder);
        }

        public mrMap GetCarletonMapper()
        {
            var data = new GeoMapPlotterHelper.GeoMapData(Title, Longitude, Latitude, Zoom);
            return gameObject.AddComponent<GeoMapPlotterHelper>().GetMrMap(data);
        }
    }
}