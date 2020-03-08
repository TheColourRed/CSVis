using CSVis.ExampleLoader;
using UnityEngine;

namespace CSVis.Menu.MenuControllers
{
    public class StaticPlotsMenuController : MonoBehaviour
    {
        public void OnClickSineWaveExample()
        {
            gameObject.AddComponent<SineWavePlotLoader>().LoadPlot();
        }
        
        public void OnClickIrisExample()
        {
            gameObject.AddComponent<IrisDataSetPlotLoader>().LoadPlot();
        }
        
        public void OnClickElectronDistributionExample()
        {
            gameObject.AddComponent<ElectronScatteringDistributionPlotHelper>().LoadPlot();
        }
    }
}