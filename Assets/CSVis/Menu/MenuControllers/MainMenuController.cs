using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

namespace CSVis.Menu.MenuControllers
{
    public class MainMenuController : AbstractMenuController
    {

        public GameObject exampleMenu;

        public GameObject exampleButton;
        
        public GameObject clearButton;

        private void OnClickViewExample()
        {
            Debug.Log("View Example Button pressed");
            ChangeMenu(exampleMenu);
        }

        private void OnClickClear()
        {
            Debug.Log("Clear All Button pressed");
            foreach (var plot in GameObject.FindGameObjectsWithTag("plotContainer"))
            {
                Destroy(plot);
            }
        }

        private void InitButtonListeners()
        {
            var example = exampleButton.GetComponent<Interactable>();
            var clear = clearButton.GetComponent<Interactable>();
            
            example.OnClick.AddListener(OnClickViewExample);
            clear.OnClick.AddListener(OnClickClear);
        }
        
        private void Start()
        {
            InitButtonListeners();
        }
    }
}
