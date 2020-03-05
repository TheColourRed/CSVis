using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace CSVis.Menu
{
    public class MenuNavigationController : MonoBehaviour
    {
        public GameObject currentMenu;
        
        public GameObject previousMenu;
        
        public GameObject mainMenu;
        
        public GameObject minimizeMenu;

        public GameObject closeButton;

        public GameObject backButton;

        public GameObject minimizeButton;
        
        /// <summary>
        /// Function to map the close button to
        /// Hides the current menu and return to the main menu
        /// </summary>
        private void OnClose()
        {
            Debug.Log("Close Button pressed");
            mainMenu.SetActive(true);
            currentMenu.SetActive(false);
        }

        /// <summary>
        /// Function to map the back button to
        /// Hides the current menu and display previous menu
        /// </summary>
        private void OnBack()
        {
            Debug.Log("Back Button pressed");
            previousMenu.SetActive(true);
            currentMenu.SetActive(false);
        }
        
        /// <summary>
        /// Function to map the minimize button to
        /// Hides the current menu and display minimized menu
        /// </summary>
        private void OnMinimize()
        {
            Debug.Log("Minimize Button pressed");
            Instantiate(minimizeMenu);
            currentMenu.SetActive(false);
        }
        
        /// <summary>
        /// Initialize event handlers for button clicks at run time
        /// as well as set the return menu for the minimized menu  
        /// </summary>
        private void Start()
        {
            minimizeMenu.GetComponent<MinimizedMenuController>().returnMenu = currentMenu;
            
            var close = closeButton.GetComponent<Interactable>();
            var back = backButton.GetComponent<Interactable>();
            var minimize = minimizeButton.GetComponent<Interactable>();

            close.OnClick.AddListener(OnClose);
            back.OnClick.AddListener(OnBack);
            minimize.OnClick.AddListener(OnMinimize);
        }

    }
}