using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine;

namespace CSVis.Menu
{
    public class MinimizedMenuController : AbstractMenuNavigationController
    {
        
        public GameObject returnMenu;

        private const float MaxDistance = 0.6f;
        
        private const float MinDistance = 0.5f;
        
        private const float MaxViewDegrees = 35f;
        
        private const float MinViewDegrees = -35f;

        private float prevMaxDistance;

        private float prevMinDistance;
        
        private float prevMaxViewDegrees;

        private float prevMinViewDegrees;

        /// <summary>
        /// Function to map the maximize button to
        /// Hides the minimize menu and display the previous menu
        /// </summary>
        private void OnMaximize()
        {
            Debug.Log("Maximize Button pressed");
            ChangeMenu(returnMenu);
        }

        private void OnEnable()
        {
            // Set radial view to come closer to the user
            var radialView = gameObject.GetComponentInParent<RadialView>();

            prevMaxDistance = radialView.MaxDistance;
            prevMinDistance = radialView.MinDistance;
            prevMaxViewDegrees = radialView.MaxViewDegrees;
            prevMinViewDegrees = radialView.MinViewDegrees;
            
            
            radialView.MinDistance = MinDistance;
            radialView.MaxDistance = MaxDistance;
            radialView.MaxViewDegrees = MaxViewDegrees;
            radialView.MinViewDegrees = MinViewDegrees;
        }

        private void OnDisable()
        {
            // Set radial view back to initial state
            var radialView = gameObject.GetComponentInParent<RadialView>();

            radialView.MaxDistance = prevMaxDistance;
            radialView.MinDistance = prevMinDistance;
            radialView.MaxViewDegrees = prevMaxViewDegrees;
            radialView.MinViewDegrees = prevMinViewDegrees;
        }
        
        private void Start()
        {
            InitButtonListeners();
        }
        
        public void InitButtonListeners()
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