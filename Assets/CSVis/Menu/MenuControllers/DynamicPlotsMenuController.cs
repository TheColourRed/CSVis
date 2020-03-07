using CSVis.ExampleLoader;
using UnityEngine;

namespace CSVis.Menu.MenuControllers
{
    public class DynamicPlotsMenuController : MonoBehaviour
    {
        
        public void OnClickDroneExample()
        {
            Debug.Log("Plotting Dynamic Drone Data");
            gameObject.AddComponent<DynamicDronePlotter>().LoadPlot();
        }
        
//        public void OnClickDroneExample()
//        {
//            Debug.Log("Plotting Dynamic Drone Data");
//            gameObject.AddComponent<DynamicDronePlotLoader>().LoadPlot();
//        }
        
    }
}