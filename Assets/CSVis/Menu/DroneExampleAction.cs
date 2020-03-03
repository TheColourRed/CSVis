using CsvHelper;
using DataVisualization.Plotter;
using System;
using System.Collections.Generic;
using System.IO;
using static CsvAssetReader;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine;

public class DroneExampleAction : MonoBehaviour
{

    const float ExampleLoadDistance = 0.8f;

    public GameObject plotContainer;

    public void OnPress()
    {
        Debug.Log("LoadDroneExampleButton pressed");
        DataPlotter plot = GetDronePlot();
        GameObject plotContainer = new GameObject();
        plotContainer.tag = "plotContainer";

        // Set the plot to appear in front of the user and facing the user
        Vector3 cameraForwardVector = Camera.main.transform.forward;
        Vector3 cameraPosition = Camera.main.transform.position;

        // set y to 0 as to not move it horizontally when spawing
        cameraForwardVector.y = 0;
        var forwardPositionVector = cameraPosition + cameraForwardVector.normalized * ExampleLoadDistance;

        plot.transform.SetParent(plotContainer.transform);

        plotContainer.transform.localRotation = Quaternion.LookRotation(cameraForwardVector);
        plotContainer.transform.position = forwardPositionVector;
    }

    private DataPlotter GetDronePlot()
    {
        TextAsset flightData = Resources.Load("Data/FlightData2") as TextAsset;
        Dictionary<string, List<float>> columnsByName = new CsvAssetReader(flightData).GetColumnsByHeader("latitude", "altitude (m)", "longitude");

        GameObject plot = new GameObject();
        DataPlotter plotter = plot.AddComponent<DataPlotter>();

        plotter.PointHolder = plot;

        GameObject dataPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        plotter.PointPrefab = dataPoint;
        Destroy(dataPoint);

        plotter.Text = Resources.Load("DataPlot/text3D") as GameObject;

        plotter.Xpoints = columnsByName["latitude"];
        plotter.Ypoints = columnsByName["altitude (m)"];
        plotter.Zpoints = columnsByName["longitude"];

        plotter.xName = "latitude";
        plotter.yName = "altitude (m)";
        plotter.zName = "longitude";

        plotter.plotScale = 0.5f;

        plotter.titleName = "Drone Flight Path";
        
        return plotter;
    }
    
}
