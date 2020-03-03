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

public class DynamicPlotDroneAction : MonoBehaviour
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
        List<float> x_values = new List<float>();
        List<float> y_values = new List<float>();
        List<float> z_values = new List<float>();
        List<string> time_values = new List<string>();

        TextAsset flightData = Resources.Load("Data/FlightData2") as TextAsset;

        using (TextReader reader = new StringReader(flightData.text))
        using (var csv = new CsvReader(reader))
        {

            csv.Read();
            csv.ReadHeader();

            string[] headerRow = csv.Context.HeaderRecord;
            int xIndex = Array.IndexOf(headerRow, "latitude");
            int yIndex = Array.IndexOf(headerRow, "altitude (m)");
            int zIndex = Array.IndexOf(headerRow, "longitude");
            int tIndex = Array.IndexOf(headerRow, "time(local time)");

            // 1. Get data 
            while (csv.Read())
            {
                x_values.Add(csv.GetField<float>(xIndex)); 
                y_values.Add(csv.GetField<float>(yIndex)); 
                z_values.Add(csv.GetField<float>(zIndex)); 
                time_values.Add(csv.GetField<string>(tIndex));
            }

            //Debug.Log(string.Join(" ", z_values.ToArray()));

            // 2. create graph
            TimeSeriesGraph graph = new TimeSeriesGraph();

            PlotPoint new_point = new PlotPoint(x_values, y_values, z_values);
            graph.AddPlotPoint(new_point);
            graph.AddTimePoints(time_values);

            // 3. init graph 
            DynamicPlotter plotter = GetPlotter(graph, "Drone Graph");

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
