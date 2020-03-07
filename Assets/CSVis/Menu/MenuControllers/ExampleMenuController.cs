using UnityEngine;

namespace CSVis.Menu.MenuControllers
{
    public class ExampleMenuController : AbstractMenuController
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