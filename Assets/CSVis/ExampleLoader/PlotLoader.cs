using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

namespace CSVis.ExampleLoader
{
    public abstract class PlotLoader : MonoBehaviour
    {
        
        private const float ExampleSpawnDistance = 0.8f;

        public abstract void LoadPlot();

        public void SetSpawn(GameObject plotContainer, float spawnDistance = ExampleSpawnDistance)
        {
            Debug.Assert(Camera.main != null, "Camera.main != null");
            var cameraTransform = Camera.main.transform;

            // Set the plot to appear in front of the user and facing the user
            var cameraForwardVector = cameraTransform.forward;
            var cameraPosition = cameraTransform.position;

            // set y to 0 as to not move it horizontally when spawing
            cameraForwardVector.y = 0;
            var forwardPositionVector = cameraPosition + cameraForwardVector.normalized * spawnDistance;

            plotContainer.transform.localRotation = Quaternion.LookRotation(cameraForwardVector);
            plotContainer.transform.position = forwardPositionVector;
            
            var manipulationHandler = plotContainer.GetComponent<ManipulationHandler>();
            manipulationHandler.ConstraintOnRotation = RotationConstraintType.YAxisOnly;
        }

    }
}