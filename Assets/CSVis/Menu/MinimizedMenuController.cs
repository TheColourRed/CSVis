using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

namespace CSVis.Menu
{
    public class MinimizedMenuController : MonoBehaviour
    {
        public GameObject maximizeButton;
        
        public GameObject returnMenu;
        
        /// <summary>
        /// Function to map the maximize button to
        /// Hides the minimize menu and display the previous menu
        /// </summary>
        private void OnMaximize()
        {
            Debug.Log("Maximize Button pressed");
            returnMenu.SetActive(true);
            Destroy(gameObject);
        }
        
        /// <summary>
        /// Initialize event handlers for button clicks at run time 
        /// </summary>
        private void Start()
        {
            var maximize = maximizeButton.GetComponent<Interactable>();
            
            maximize.OnClick.AddListener(OnMaximize);
        }
    }
}