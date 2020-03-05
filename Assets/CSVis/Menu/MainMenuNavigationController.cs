using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

namespace CSVis.Menu
{
    public class MainMenuNavigationController : AbstractMenuNavigationController
    {

        public GameObject exampleMenu;

        public GameObject exampleButton;

        private void OnViewExample()
        {
            Debug.Log("Load Example Button pressed");
            ChangeMenu(exampleMenu);
        }

        private void InitButtonListeners()
        {
            //minimizeMenu.GetComponent<MinimizedMenuController>().returnMenu = currentMenu;
            var close = exampleButton.GetComponent<Interactable>();

            close.OnClick.AddListener(OnViewExample);
        }
        
        private void Start()
        {
            InitButtonListeners();
        }
    }
}
