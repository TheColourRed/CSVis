using CSVis.ExampleLoader.Helper;
using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.ExampleLoader
{
    public class Parliament3DTerrainMapLoader : PlotLoader
    {
        private const float Longitude = 45.424542f;
        
        private const float Latitude = -75.699416f;
        
        private const int Zoom = 17;
        
        private const string Title = "Parliament of Canada";
        
        public override void LoadPlot()
        {
            var map = Instantiate(GetParliamentMapper());
            SetSpawn(map.MapHolder);
        }

        public mrMap GetParliamentMapper()
        {
            var data = new GeoMapPlotHelper.GeoMapData(Title, Longitude, Latitude, Zoom);
            var parliamentMapper = gameObject.AddComponent<GeoMapPlotHelper>().GetMrMap(data);
            parliamentMapper.enable3DTerrain = true;
            return parliamentMapper;
        }
    }
}