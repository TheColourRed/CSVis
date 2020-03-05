using System;
using CSVis.IO;
using TimeSeriesExtension;
using UnityEngine;

namespace CSVis.Menu
{
    public class DynamicPlotsMenuController : MonoBehaviour
    {
        private const string Title = "Drone Flight Path";
           
        private const string XHeader = "latitude";

        private const string YHeader = "altitude (m)";
            
        private const string ZHeader = "longitude";
        
        private const string TimeHeader = "time(local time)";

        private const string CsvResourcePath = "Data/FlightData2";
            
        private const string TextResourcePath = "DataPlot/text3D";
        
        public void InitDynamicDronePlot()
        {
            Debug.Log("Plotting Dynamic Drone Data");
            
            var csv = Resources.Load(CsvResourcePath) as TextAsset;
            var positionsByName = new CsvAssetReader(csv).GetColumnsByHeader<float>(XHeader, YHeader, ZHeader);
            var timeByName = new CsvAssetReader(csv).GetColumnsByHeader<string>(TimeHeader);


            var point = new PlotPoint(
                positionsByName[XHeader], 
                positionsByName[YHeader], 
                positionsByName[ZHeader]
            );

            var graph = new TimeSeriesGraph();
            graph.AddPlotPoint(point);
            graph.AddTimePoints(timeByName[TimeHeader]);

            var plotter = new GameObject().AddComponent<DynamicPlotter>();

            plotter.Graph = graph;
            plotter.PointHolder = new GameObject();

            var dataPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
            plotter.PointPrefab = dataPoint;
            Destroy(dataPoint.gameObject);

            var text = new GameObject();

            text.AddComponent<TextMesh>();

            plotter.Text = text;
            
            plotter.PlotTitle = name;
            
            plotter.XAxisName = XHeader;
            plotter.YAxisName = YHeader;
            plotter.ZAxisName = ZHeader;

            plotter.Init();
        }
        
        public void OnClickDynamicPlots()
        {
            
        }
        
        public void OnClickGeographicMaps()
        {
            
        }
    }
}