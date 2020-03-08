using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine;

namespace CSVis.Menu.MenuControllers
{
    public class MinimizedMenuController : AbstractMenuController
    {
        
        public GameObject returnMenu;

        /// <summary>
        /// Function to map the maximize button to
        /// Hides the minimize menu and display the previous menu
        /// </summary>
        private void OnMaximize()
        {
            Debug.Log("Maximize Button pressed");
            ChangeMenu(returnMenu);
        }

        private void Start()
        {
            InitButtonListeners();
        }
        
        private void InitButtonListeners()
        {
            foreach (var intractable in gameObject.GetComponentsInChildren<Interactable>())
            {
                if (intractable.name == "MaximizeButton")
                {
                    intractable.OnClick.AddListener(OnMaximize);
                }
            }
        }
    }
}