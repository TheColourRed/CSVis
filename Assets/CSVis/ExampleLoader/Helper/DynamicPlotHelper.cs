﻿using System.Collections.Generic;
using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.ExampleLoader.Helper
{
    public class DynamicPlotHelper : PlotHelper
    {
        private static DynamicPlotHelper instance;
        public static DynamicPlotHelper Instance
        {
            get
            {
                if( instance == null )
                {
                    var staticPlotHelper = new GameObject {name = "DynamicPlotHelper"};
                    instance = staticPlotHelper.AddComponent<DynamicPlotHelper>();
                }

                return instance;
            }
        }

        private DynamicPlotHelper() { }

        public static DynamicPlotter GetDynamicPlotter(DynamicPlotData data)
        {
            var plotter = new GameObject().AddComponent<DynamicPlotter>();
            var graph = new DynamicGraph();

            data.Points.ForEach(point =>
                graph.AddPlotPoint(new PlotPoint(point.XColumn, point.YColumn, point.ZColumn))
            );

            graph.AddTimePoints(data.TimeColumn);

            plotter.Graph = graph;
            
            plotter.PointHolder = GetPlotHolder();
            plotter.PointPrefab = data.PointObject.transform;
            plotter.Text = GetText3D();
            
            plotter.PlotTitle = data.Title;
            plotter.XAxisName = data.XName;
            plotter.YAxisName = data.YName;
            plotter.ZAxisName = data.ZName;

            plotter.PlotScale = data.PlotScale;
            
            plotter.Init();

            return plotter;
        }
        
        public class DynamicPlotData
        {

            public string Title { get; set; }

            public List<PointColumns> Points { get; set; }

            public List<string> TimeColumn { get; set; }

            public string XName { get; set; }

            public string YName { get; set; }

            public string ZName { get; set; }
            
            public GameObject PointObject { get; set; }
            
            public float PlotScale { get; set; }

            public DynamicPlotData(string title, List<PointColumns> points, List<string> timeColumn, string xName,
                string yName, string zName)
            {
                Title = title;
                Points = points;
                TimeColumn = timeColumn;
                XName = xName;
                YName = yName;
                ZName = zName;
                PointObject = GetDataPoint();
                PlotScale = DefaultPlotScale;
            }

            public class PointColumns
            {
                public List<float> XColumn { get; }

                public List<float> YColumn { get; }
            
                public List<float> ZColumn { get; }

                public PointColumns(List<float> xColumn, List<float> yColumn, List<float> zColumn)
                {
                    XColumn = xColumn;
                    YColumn = yColumn;
                    ZColumn = zColumn;
                }
            }
            
        }
    }
}