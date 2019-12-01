using CsvHelper;
using DataVisualization.Plotter;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine;

public class SineWaveExampleAction : MonoBehaviour
{
        const float ExampleLoadDistance = 0.8f;

        public void OnPress()
        {
            Debug.Log("LoadSineExampleButton pressed");
            DataPlotter plot = GetExamplePlot();
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

        private DataPlotter GetExamplePlot()
        {
            List<float> xPoints = new List<float>();
            List<float> yPoints = new List<float>();

            TextAsset signWaveData = Resources.Load("Data/sine_100") as TextAsset;

            using (TextReader reader = new StringReader(signWaveData.text))
            using (var csv = new CsvReader(reader))
            {
                csv.Read();
                csv.ReadHeader();

                string[] headerRow = csv.Context.HeaderRecord;
                int xIndex = 0;
                int yIndex = 1;

                while (csv.Read())
                {
                    xPoints.Add(csv.GetField<float>(xIndex));
                    yPoints.Add(csv.GetField<float>(yIndex));
                }

                GameObject plot = new GameObject();
                DataPlotter plotter = plot.AddComponent<DataPlotter>();

                plotter.PointHolder = plot;

                GameObject dataPoint = GameObject.CreatePrimitive(PrimitiveType.Quad);
                plotter.PointPrefab = dataPoint;
                Destroy(dataPoint);

                plotter.Text = Resources.Load("DataPlot/text3D") as GameObject;

                plotter.Xpoints = xPoints;
                plotter.Ypoints = yPoints;

                plotter.xName = "x"; //headerRow[xIndex];
                plotter.yName = "y"; //headerRow[zIndex];

                plotter.plotScale = 0.5f;

                plotter.titleName = "sine wave - 100 points";

                return plotter;
            }
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
