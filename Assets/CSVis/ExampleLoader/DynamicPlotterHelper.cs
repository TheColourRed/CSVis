using System.Collections.Generic;
using DataVisualization.Plotter;
using TimeSeriesExtension;
using UnityEngine;

namespace CSVis.ExampleLoader
{
    public class DynamicPlotterHelper : PlotterHelper
    {

        public DynamicPlotter GetDynamicPlotter(DynamicPlotData data)
        {
            var plotter = new GameObject().AddComponent<DynamicPlotter>();
            var graph = new TimeSeriesGraph();

            data.Points.ForEach(point =>
                graph.AddPlotPoint(new PlotPoint(point.XColumn, point.YColumn, point.ZColumn))
            );

            graph.AddTimePoints(data.TimeColumn);

            plotter.Graph = graph;
            
            plotter.PointHolder = GetPlotContainer();
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

            public string Title { get; }

            public List<PointColumns> Points { get; }

            public List<string> TimeColumn { get; }

            public string XName { get; }

            public string YName { get; }

            public string ZName { get; }
            
            public GameObject PointObject { get; }
            
            public float PlotScale { get; }

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