using CsvHelper;
using DataVisualization.Plotter;
using TimeSeriesExtension;
using static PlotPoint;
using TimeSeriesExtension;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine;

public class DynamicPlotAction: MonoBehaviour
{ 
    const float ExampleLoadDistance = 0.8f;

    public void OnPress()
    {
        Debug.Log("LoadSineExampleButton pressed");
        DynamicPlotter plot = GetExamplePlot();
        GameObject plotContainer = new GameObject();
        plotContainer.tag = "plotContainer";

        // Set the plot to appear in front of the user and facing the user
        Vector3 cameraForwardVector = Camera.main.transform.forward;
        Vector3 cameraPosition = Camera.main.transform.position;

        var forwardPositionVector = cameraPosition + cameraForwardVector.normalized * ExampleLoadDistance;
        var forwardRotationVector = Quaternion.LookRotation(
            Vector3.Scale(cameraForwardVector.normalized, new Vector3(0, 1, 0))
        );

        plot.transform.SetParent(plotContainer.transform);

        plot.transform.position = forwardPositionVector;
        plot.transform.rotation = forwardRotationVector;
        plotContainer.transform.position = forwardPositionVector;
        plotContainer.transform.rotation = forwardRotationVector;
    }

    private DynamicPlotter GetExamplePlot()
    {
        List<float> x1 = new List<float>();
        List<float> x2 = new List<float>();
        List<float> x3 = new List<float>();
        List<float> y1 = new List<float>();
        List<float> y2 = new List<float>();
        List<float> y3 = new List<float>();
        List<float> z1 = new List<float>();
        List<float> z2 = new List<float>();
        List<float> z3 = new List<float>();

        TextAsset flightData = Resources.Load("Data/100_sine_xyz") as TextAsset;

        using (TextReader reader = new StringReader(flightData.text))
        using (var csv = new CsvReader(reader))
        {
            csv.Read();
//            csv.ReadHeader();

            string[] headerRow = csv.Context.HeaderRecord;
//            int xIndex = Array.IndexOf(headerRow, "latitude");
//            int yIndex = Array.IndexOf(headerRow, "altitude (m)");
//            int zIndex = Array.IndexOf(headerRow, "longitude");

            // 1. Get data 
            int cut = 0;
            while (csv.Read())
            {
                x1.Add(csv.GetField<float>(0));
                y1.Add(csv.GetField<float>(1));
                z1.Add(csv.GetField<float>(2));

                x2.Add(csv.GetField<float>(3));
                y2.Add(csv.GetField<float>(4));
                z2.Add(csv.GetField<float>(5));
                /**
                x3.Add(csv.GetField<float>(6));
                y3.Add(csv.GetField<float>(7));
                z3.Add(csv.GetField<float>(8));
                */
            }

            // 2. create graph
            TimeSeriesGraph graph = new TimeSeriesGraph();

            PlotPoint new_point = new PlotPoint(x1, y1, z1);
            graph.AddPlotPoint(new_point);

            new_point = new PlotPoint(x2, y2, z2);
            graph.AddPlotPoint(new_point);
            /**
            new_point = new PlotPoint(x3, y3, z3);
            graph.AddPlotPoint(new_point);
            */

            Debug.Log(graph.LogMin());
  
            // 3. init graph 
            DynamicPlotter plotter = GetPlotter(graph, "Sine Graph");

            return plotter;
        }
    }

    private DynamicPlotter GetPlotter(TimeSeriesGraph graph, string name)
    {
        GameObject plot = new GameObject();

        DynamicPlotter plotter = plot.AddComponent<DynamicPlotter>();

        plotter.Graph = graph;
        Debug.Log("Graph is assigned");
        plotter.PointHolder = plot;

        Transform dataPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;

        plotter.PointPrefab = dataPoint;
        Destroy(dataPoint.gameObject);

        GameObject text = new GameObject();

        text.AddComponent<TextMesh>();

        plotter.Text = text;

        plotter.PlotTitle = name;

        plotter.Init();

        return plotter;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
