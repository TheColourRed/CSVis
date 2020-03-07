using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.ExampleLoader
{
    public class GeoMapPlotterHelper : PlotterHelper
    {
        public mrMap GetMrMap(GeoMapData data)
        {
            var mapBox = new GameObject();
            var map = mapBox.AddComponent<mrMap>();

            map.location = "45.3831, -75.6976";
            map.titleName = data.Title;
            map.zoom = data.Zoom;
            map.plotScale = data.PlotScale;
            map.MapHolder = new GameObject();

            map.Text = GetText3D();

            return map;
        }

        public class GeoMapData
        {
            public string Title { get; set; }
            public float Longitude { get; set; }

            public float Latitude { get; set; }

            public int Zoom { get; set; }

            public float PlotScale { get; set; }

            public GeoMapData(string title, float longitude, float latitude, int zoom)
            {
                Longitude = longitude;
                Latitude = latitude;
                Zoom = zoom;
                Title = title;
                PlotScale = DefaultPlotScale;
            }
        }
    }
}