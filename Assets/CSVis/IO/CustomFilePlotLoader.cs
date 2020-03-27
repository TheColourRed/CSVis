
using System.Collections.Generic;
using System.Linq;
using CSVis.ExampleLoader;
using CSVis.ExampleLoader.Helper;
using UnityEngine;

namespace CSVis.IO
{
    public class CustomFilePlotLoader : PlotLoader
    {
        private const int StaticPlot2DHeaders = 2;
        private const int StaticPlot3DHeaders = 3;
        private const int GeoMapHeaders = 6;
        
        private const int StaticPlotX = 0;
        private const int StaticPlotY = 1;
        private const int StaticPlotZ = 2;
        
        private const int DynamicPlotTime = 0;
        private const int DynamicPlotX = 1;
        private const int DynamicPlotY = 2;
        private const int DynamicPlotZ = 3;
        
        private const int GeoMapLongitude = 0;
        private const int GeoMapLatitude = 1;
        private const int GeoMapValue = 2;
        private const int GeoMapR = 3;
        private const int GeoMapG = 4;
        private const int GeoMapB = 5;
        
        
        private const float GeoSpawnScale = 0.01f;
        private const float GeoHeightScaleMax = 0.2f;
        private const float GeoHeightScaleMin = 0f;
        
        public void PlotCustomFile(string fileName, string csv)
        {
            if ("".Equals(fileName))
            {
                Debug.LogWarning("No file selected");
            }
            
            if ("".Equals(csv))
            {
                Debug.LogWarning("Nothing in file");
            }
            
            var headers = CsvUtils.GetColumnHeaders(csv);
            var headersCount = headers.Count;
            if (headersCount == StaticPlot2DHeaders)
            {
                Plot2DStaticPlotFile(fileName, csv, headers);
            } 
            else if (headersCount == StaticPlot3DHeaders)
            {
                Plot3DStaticPlotFile(fileName, csv, headers);
            } 
            else if ((headersCount - 1 % 3) == 0)
            {
                PlotDynamicPlotFile(fileName, csv, headers);
            }
            else if ((headersCount - 1) % 3 == 0)
            {
                PlotDynamicPlotFile(fileName, csv, headers);
            }
            else if (headersCount == GeoMapHeaders)
            {
                PlotGeographicMapFile(fileName, csv, headers);
            }
            else
            {
                Debug.LogWarning("Invalid format file");
            }
        }

        private void Plot2DStaticPlotFile(string fileName, string csv, List<string> headers)
        {
            var columnsByIndex = CsvUtils.GetContentColumnsByIndex<float>(csv, StaticPlotX, StaticPlotY);
            var data = new StaticPlotHelper.StaticPlotData(
                fileName,
                columnsByIndex[StaticPlotX],
                columnsByIndex[StaticPlotY],
                headers[StaticPlotX],
                headers[StaticPlotY]
            );

            var plotter = StaticPlotHelper.GetStaticPlotter(data);
            var plotContainer = Instantiate(plotter);
            SetSpawn(plotContainer.PointHolder);
        }

        
        private void Plot3DStaticPlotFile(string fileName, string csv, List<string> headers)
        {
            var columnsByIndex = CsvUtils.GetContentColumnsByIndex<float>(csv, StaticPlotX, StaticPlotY, StaticPlotZ);
            var data = new StaticPlotHelper.StaticPlotData(
                fileName,
                columnsByIndex[StaticPlotX],
                columnsByIndex[StaticPlotY],
                columnsByIndex[StaticPlotZ],
                headers[StaticPlotX],
                headers[StaticPlotY],
                headers[StaticPlotZ]
            );

            var plotter = StaticPlotHelper.GetStaticPlotter(data);
            var plotContainer = Instantiate(plotter);
            SetSpawn(plotContainer.PointHolder);
        }
        
                
        private void PlotDynamicPlotFile(string fileName, string csv, List<string> headers)
        {
            var pointIndexes = Enumerable.Range(1, headers.Count).ToList();
            var times = CsvUtils.GetContentColumnsByIndex<string>(csv, DynamicPlotTime)[DynamicPlotTime];
            var columnsByIndex = CsvUtils.GetContentColumnsByIndex<float>(csv, pointIndexes.ToArray());
            var pointColumns = new List<DynamicPlotHelper.DynamicPlotData.PointColumns>();
            var nPoints = (headers.Count - 1) / 3; 
            
            for (int i = 0; i < nPoints; i++)
            {
                int offset = i * 3;
                pointColumns.Add(
                    new DynamicPlotHelper.DynamicPlotData.PointColumns(
                        columnsByIndex[offset + DynamicPlotX],
                        columnsByIndex[offset + DynamicPlotY],
                        columnsByIndex[offset + DynamicPlotZ]
                    )
                );
            }
        
            var data = new DynamicPlotHelper.DynamicPlotData(
                fileName,
                pointColumns,
                times,
                headers[DynamicPlotX],
                headers[DynamicPlotY],
                headers[DynamicPlotZ]
            );
            
            var plotter = DynamicPlotHelper.GetDynamicPlotter(data);
            var plotContainer = Instantiate(plotter);
            SetSpawn(plotContainer.PointHolder);
        }
        
        private void PlotGeographicMapFile(string fileName, string csv, List<string> headers)
        {
            var columnsByIndex = CsvUtils.GetContentColumnsByIndex<float>(csv, GeoMapLongitude, GeoMapLatitude, GeoMapValue, GeoMapR, GeoMapG, GeoMapB);
            var geoMapPlotterHelper = gameObject.AddComponent<GeoMapPlotHelper>();
            var numLocations = columnsByIndex[GeoMapLongitude].Count;
            int halfIndex = numLocations/2;
            float longitude;
            float latitude;
            
            var colors = Enumerable.Range(0, numLocations).Select(i =>
                new Color(columnsByIndex[GeoMapR][i], columnsByIndex[GeoMapG][i], columnsByIndex[GeoMapB][i])
            ).ToList();


            var sortedLongitudes = new List<float>(columnsByIndex[GeoMapLongitude]);
            var sortedLatitudes = new List<float>(columnsByIndex[GeoMapLatitude]);
            if ((numLocations % 2) == 0)
            {
                longitude = (sortedLongitudes.ElementAt(halfIndex) +
                              sortedLongitudes.ElementAt(halfIndex - 1)) / 2;
                latitude = (sortedLatitudes.ElementAt(halfIndex) +
                             sortedLatitudes.ElementAt(halfIndex - 1)) / 2;
            } else {
                longitude = sortedLongitudes.ElementAt(halfIndex);
                latitude = sortedLatitudes.ElementAt(halfIndex);
            } 

            var locationStrings = Enumerable.Range(0, numLocations).Select(i =>
                columnsByIndex[GeoMapLongitude][i].ToString("n4") + ", " + columnsByIndex[GeoMapLatitude][i].ToString("n4")
            ).ToList();
            
            var data = new GeoMapPlotHelper.GeoMapData(
                fileName,
                longitude,
                latitude,
                16,
                GeoMapPlotHelper.GeoDefaultPlotScale,
                locationStrings,
                columnsByIndex[GeoMapValue],
                colors,
                GeoSpawnScale,
                GeoHeightScaleMax,
                GeoHeightScaleMin,
                PlotHelper.GetPlotHolder()
            );
        
            var plotter = geoMapPlotterHelper.GetMrMap(data);
            var plotContainer = Instantiate(plotter);
            SetSpawn(plotContainer.MapHolder);
        }
        
        public override void LoadPlot()
        {
            throw new System.NotImplementedException();
        }
    }
}