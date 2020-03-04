using DataVisualization.Plotter;
using UnityEngine;

namespace CSVis.Menu
{
    public class AbstractExampleAction : MonoBehaviour
    {
        private const float ExampleLoadDistance = 0.8f;

        protected void SetSpawnLocation(DataPlotter plot)
        {
            var cameraTransform = Camera.main.transform;

            // Set the plot to appear in front of the user and facing the user
            var cameraForwardVector = cameraTransform.forward;
            var cameraPosition = cameraTransform.position;

            // set y to 0 as to not move it horizontally when spawing
            cameraForwardVector.y = 0;
            var forwardPositionVector = cameraPosition + cameraForwardVector.normalized * ExampleLoadDistance;

            plot.PointHolder.transform.localRotation = Quaternion.LookRotation(cameraForwardVector);
            plot.PointHolder.transform.position = forwardPositionVector;
        }
    }
}