using System.Collections.Generic;
using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.ExampleLoader.Helper
{
    public class GeoMapPlotHelper : PlotHelper
    {
        public const float GeoDefaultPlotScale = 0.2f;
        
        private static GeoMapPlotHelper instance;
        
        public static GeoMapPlotHelper Instance
        {
            get
            {
                if( instance == null )
                {
                    var staticPlotHelper = new GameObject {name = "GeoMapPlotHelper"};
                    instance = staticPlotHelper.AddComponent<GeoMapPlotHelper>();
                }

                return instance;
            }
        }

        private GeoMapPlotHelper() { }
        
        public mrMap GetMrMap(GeoMapData data)
        {
            var mapBox = new GameObject();
            var map = mapBox.AddComponent<mrMap>();

            map.titleName = data.Title;
            map.location = data.Longitude.ToString("n4") + ", " + data.Latitude.ToString("n4") ;
            map.zoom = data.Zoom;
            map.plotScale = GeoDefaultPlotScale;
            map.MapHolder = data.PlotContainer;

             map.Text = GetText3D();

            if (data.LocationStrings == null)
            {
                return map;
            }
            
            map.locationStrings = data.LocationStrings.ToArray();
            map.heightValues = data.HeightValues;
            map.colors = data.Colors;
            map.spawnScale = data.SpawnScale;    
            map.HeightScaleMax = data.HeightScaleMax;
            map.HeightScaleMin = data.HeightScaleMin;

            return map;
        }

        public class GeoMapData
        {
            public string Title { get; set; }
            public float Longitude { get; set; }

            public float Latitude { get; set; }

            public float Zoom { get; set; }

            public float PlotScale { get; set; }
            
            public List<string> LocationStrings { get; set; }
            
            public List<float> HeightValues { get; set; }
            
            public List<Color> Colors { get; set; }
            
            public float SpawnScale { get; set; }
            
            public float HeightScaleMax { get; set; }
            
            public float HeightScaleMin { get; set; }

            public GameObject PlotContainer { get; set; }

            public GeoMapData(string title, float longitude, float latitude, float zoom)
            {
                Longitude = longitude;
                Latitude = latitude;
                Zoom = zoom;
                Title = title;
                PlotScale = GeoDefaultPlotScale;
                PlotContainer = GetPlotContainer();
            }
            
            public GeoMapData(string title, float longitude, float latitude, float zoom, float plotScale, List<string> locationStrings, List<float> heightValues, List<Color> colors, float spawnScale, float heightScaleMax, float heightScaleMin, GameObject plotContainer)
            {
                Title = title;
                Longitude = longitude;
                Latitude = latitude;
                Zoom = zoom;
                PlotScale = plotScale;
                LocationStrings = locationStrings;
                HeightValues = heightValues;
                Colors = colors;
                SpawnScale = spawnScale;
                HeightScaleMax = heightScaleMax;
                HeightScaleMin = heightScaleMin;
                PlotContainer = plotContainer;
            }
        }
    }
}