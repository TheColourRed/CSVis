using System.Collections.Generic;
using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.ExampleLoader.Helper
{
    public class StaticPlotHelper : PlotHelper
    {
        private static StaticPlotHelper instance;
        public static StaticPlotHelper Instance
        {
            get
            {
                if( instance == null )
                {
                    var staticPlotHelper = new GameObject {name = "StaticPlotHelper"};
                    instance = staticPlotHelper.AddComponent<StaticPlotHelper>();
                }

                return instance;
            }
        }

        private StaticPlotHelper() { }

        public static DataPlotter GetStaticPlotter(StaticPlotData data)
        {
            var plotter = new GameObject().AddComponent<DataPlotter>();
            var plotContainer = GetPlotHolder();

            plotter.transform.parent = plotContainer.transform;
            plotter.PointHolder = plotContainer;

            plotter.PointPrefab = data.PointObject;
            plotter.Text = GetText3D();

            plotter.Xpoints = data.XColumn;
            plotter.Ypoints = data.YColumn;

            plotter.titleName = data.Title;
            plotter.xName = data.XName;
            plotter.yName = data.YName;

            if (data.ZName != null)
            {
                plotter.Zpoints = data.ZColumn;
                plotter.zName = data.ZName;
            }

            plotter.plotScale = data.PlotScale;

            return plotter;
        }
        
        public class StaticPlotData
        {
            public string Title { get; set; }

            public string XName { get; set; }

            public string YName { get; set; }

            public string ZName { get; set; }
            
            public List<float> ZColumn { get; set; }

            public List<float> YColumn { get; set; }

            public List<float> XColumn { get; set; }

            public GameObject PointObject { get; set; }

            public float PlotScale { get; set; }
            
            public StaticPlotData(string title,
                List<float> xColumn,
                List<float> yColumn,
                List<float> zColumn,
                string xName,
                string yName,
                string zName
            )
            {
                Title = title;
                XColumn = xColumn;
                YColumn = yColumn;
                ZColumn = zColumn;
                XName = xName;
                YName = yName;
                ZName = zName;
                PointObject = GetDataPoint();
                PlotScale = DefaultPlotScale;
            }

            public StaticPlotData(
                string title,
                List<float> xColumn,
                List<float> yColumn,
                string xName,
                string yName
            )
            {
                Title = title;
                XColumn = xColumn;
                YColumn = yColumn;
                XName = xName;
                YName = yName;
                PointObject = GetDataPoint();
                PlotScale = DefaultPlotScale;
            }
        }
    }
}