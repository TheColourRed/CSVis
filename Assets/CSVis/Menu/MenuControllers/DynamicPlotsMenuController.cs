using CSVis.ExampleLoader;
using UnityEngine;

namespace CSVis.Menu.MenuControllers
{
    public class DynamicPlotsMenuController : MonoBehaviour
    {
        
        public void OnClickDroneExample()
        {
            Debug.Log("Plotting Dynamic Drone Data");
            gameObject.AddComponent<DynamicDronePlotLoader>().LoadPlot();
        }
        
        public void OnClickSineWaveExample()
        {
            Debug.Log("Plotting Dynamic Sine Wave Data");
            gameObject.AddComponent<DynamicSineWavePlotLoader>().LoadPlot();
        }
        
        public void OnClickElectronDistributionExample()
        {
            Debug.Log("Plotting Dynamic Sine Wave Data");
            gameObject.AddComponent<DynamicElectronScatteringPlotLoader>().LoadPlot();
        }
        
    }
}