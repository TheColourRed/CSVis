using CsvHelper;
using DataVisualization.Plotter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ViewExampleAction : MonoBehaviour
{

    public TextMeshPro label;

    public void onPress()
    {
        List<float> xPoints = new List<float>();
        List<float> yPoints = new List<float>();
        List<float> zPoints = new List<float>();

        UnityEngine.Debug.LogFormat("LoadExampleButton pressed");
        TextAsset flightData = Resources.Load("DroneData/FlightData2") as TextAsset;

        using (TextReader reader = new StringReader(flightData.text))
        using (var csv = new CsvReader(reader)) {
            csv.Read();
            csv.ReadHeader();
            
            string[] headerRow = csv.Context.HeaderRecord;
            int xIndex = Array.IndexOf(headerRow, "latitude");
            int yIndex = Array.IndexOf(headerRow, "altitude (m)");
            int zIndex = Array.IndexOf(headerRow, "longitude");

            while (csv.Read())
            {
                xPoints.Add(csv.GetField<float>(xIndex));
                yPoints.Add(csv.GetField<float>(yIndex));
                zPoints.Add(csv.GetField<float>(zIndex));
            }

            GameObject plot = new GameObject();
            Transform transform = plot.AddComponent<Transform>();
            DataPlotter plotter = plot.AddComponent<DataPlotter>();

            plotter.PointHolder = plot;

            GameObject dataPoint = GameObject.CreatePrimitive(PrimitiveType.Cube);
            plotter.PointPrefab = dataPoint;
            Destroy(dataPoint);

            plotter.Text = Resources.Load("DataPlot/text3D") as GameObject;

            plotter.Xpoints = xPoints;
            plotter.Ypoints = yPoints;
            plotter.Zpoints = zPoints;

            plotter.xName = headerRow[xIndex];
            plotter.yName = headerRow[yIndex];
            plotter.zName = headerRow[zIndex];

            plotter.plotScale = 0.5f;

            plotter.titleName = "test flight data";
        }

    }

}
