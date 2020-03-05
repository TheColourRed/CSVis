using UnityEngine;

namespace CSVis.Menu
{
    public class ExampleMenuNavigationController : AbstractMenuNavigationController
    {

        public GameObject staticPlotsMenu;
        
        public GameObject dynamicPlotsMenu;
        
        public GameObject geographicMapMenu;

        public void OnClickStaticPlots()
        {
            ChangeMenu(staticPlotsMenu);
        }
        
        public void OnClickDynamicPlots()
        {
            ChangeMenu(dynamicPlotsMenu);
        }
        
        public void OnClickGeographicMaps()
        {
            ChangeMenu(geographicMapMenu);
        }
        
    }
    
}