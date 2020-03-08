using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

namespace CSVis.Menu.MenuControllers
{
    public class NavigationMenuController : AbstractMenuController
    {
        public GameObject previousMenu;
        
        public GameObject mainMenu;
        
        public GameObject minimizeMenu;

        /// <summary>
        /// Function to map the close button to
        /// Hides the current menu and return to the main menu
        /// </summary>
        private void OnClose()
        {
            Debug.Log("Close Button pressed");
            ChangeMenu(mainMenu);
        }

        /// <summary>
        /// Function to map the back button to
        /// Hides the current menu and display previous menu
        /// </summary>
        private void OnBack()
        {
            Debug.Log("Back Button pressed");
            ChangeMenu(previousMenu);
        }
        
        /// <summary>
        /// Function to map the minimize button to
        /// Hides the current menu and display minimized menu
        /// </summary>
        private void OnMinimize()
        {
            Debug.Log("Minimize Button pressed");
            ChangeMenu(minimizeMenu);
        }

        private void InitButtonListeners()
        {
            minimizeMenu.GetComponent<MinimizedMenuController>()
                .returnMenu = currentMenu;

            foreach (var intractable in gameObject.GetComponentsInChildren<Interactable>())
            {
                if (intractable.name == "CloseButton")
                {
                    intractable.OnClick.AddListener(OnClose);
                }
                else if (intractable.name == "BackButton")
                {
                    intractable.OnClick.AddListener(OnBack);
                }
                else if (intractable.name == "MinimizeButton")
                {
                    intractable.OnClick.AddListener(OnMinimize);
                }
            }
        }
        
        private void Start()
        {
            InitButtonListeners();
        }
    }
}