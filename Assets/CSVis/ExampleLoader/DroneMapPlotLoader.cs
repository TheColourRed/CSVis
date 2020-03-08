﻿using System;
using System.Collections.Generic;
using System.Linq;
using CSVis.ExampleLoader.Helper;
using CSVis.IO;
using DataVisualization.Plotter;
using KDTree;
using Unity.Collections;
using UnityEngine;

namespace CSVis.ExampleLoader
{
    public class DroneMapPlotLoader : PlotLoader
    {

        private const string Title = "Drone Flight Path";

        private const float Longitude = 45.385f;
        
        private const float Latitude = -75.695f;
        
        private const int LongitudeIndex = 4;

        private const int LatitudeIndex = 3;

        private const int AltitudeIndex = 5;
        
        private const string CsvResourcePath = "Data/FlightData2reducedByHalf";
        
        private const float Zoom = 15.5f;
        
        private const float SpawnScale = 0.001f;
        
        private const float HeightScaleMax = 0.2f;
        
        private const float HeightScaleMin = 0f;
        
        public override void LoadPlot()
        {
            var map = Instantiate(GetDroneMapper());
            SetSpawn(map.MapHolder);
        }

        public mrMap GetDroneMapper()
        {
            var geoMapPlotterHelper = gameObject.AddComponent<GeoMapPlotHelper>();
            var columnsByName = CsvUtils.GetColumnsByIndex<float>(CsvResourcePath, LatitudeIndex, LongitudeIndex, AltitudeIndex);
            var count = columnsByName[AltitudeIndex].Count;
            var colors = GetColors(count);

            var locationStrings = Enumerable.Range(0, count).Select(i =>
                columnsByName[LongitudeIndex][i].ToString("n4") + ", " + columnsByName[LatitudeIndex][i].ToString("n4")
            ).ToList();

            var data = new GeoMapPlotHelper.GeoMapData(
                Title,
                Longitude,
                Latitude,
                Zoom,
                GeoMapPlotHelper.GeoDefaultPlotScale,
                locationStrings,
                columnsByName[AltitudeIndex],
                colors,
                SpawnScale,
                HeightScaleMax,
                HeightScaleMin,
                PlotHelper.GetPlotContainer()
            );

            return geoMapPlotterHelper.GetMrMap(data);
        }
        
        private List<Color> GetColors(int length)
        {
            var interval = 255f * 3f / length;
            var r = 255f;
            var g = 0f;
            var b = 0f;
            
            return Enumerable.Range(0, length).Select(i =>
            {
                if(r > 0 && Math.Abs(b) < 0.1){
                    r -= interval;
                    g += interval;
                }
                if(g > 0 && Math.Abs(r) < 0.1){
                    g -= interval;
                    b += interval;
                }
                if(b > 0 && Math.Abs(g) < 0.1){
                    r += interval;
                    b -= interval;
                }
                Debug.LogFormat("{0}, {1}, {2}", r, g, b);
                return new Color(r, g, b);
            }).ToList();
        }
    }
}