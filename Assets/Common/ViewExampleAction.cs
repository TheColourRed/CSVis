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

    const float ExampleLoadDistance = 0.8f;

    /**
     * 
     * 
     */
    public void OnPress()
    {
        UnityEngine.Debug.Log("LoadExampleButton pressed");
        DataPlotter plot = GetExamplePlot();
        GameObject plotContainer =new GameObject();

        // Set the plot to appear in front of the user and facing the user
        Vector3 forwardVector = Camera.main.gameObject.transform.forward;
        forwardVector.y = 0;
        forwardVector.Normalize();

        plot.transform.SetParent(plotContainer.transform);
        plotContainer.transform.position = Camera.main.gameObject.transform.position + forwardVector * ExampleLoadDistance;
        plotContainer.transform.rotation = Quaternion.LookRotation(-forwardVector);
    }

    private DataPlotter GetExamplePlot()
    {
        List<float> xPoints = new List<float>();
        List<float> yPoints = new List<float>();
        List<float> zPoints = new List<float>();

        TextAsset flightData = Resources.Load("DroneData/FlightData2") as TextAsset;

        using (TextReader reader = new StringReader(flightData.text))
        using (var csv = new CsvReader(reader))
        {
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

            return plotter;
        }
    }

}
