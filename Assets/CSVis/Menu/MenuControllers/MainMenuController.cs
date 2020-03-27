using CSVis.IO;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
using UnityEngine;

namespace CSVis.Menu.MenuControllers
{
    public class MainMenuController : AbstractMenuController
    {

        public GameObject exampleMenu;

        public GameObject exampleButton;
        
        public GameObject clearButton;

        public GameObject selectFileButton;

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

        public void OnClickFileSelect()
        {
            var fileSelector = new FileSelector();
            fileSelector.SelectFile();
        }

        private void InitButtonListeners()
        {
            var file = selectFileButton.GetComponent<Interactable>();
            var example = exampleButton.GetComponent<Interactable>();
            var clear = clearButton.GetComponent<Interactable>();

            file.OnClick.AddListener(OnClickFileSelect);
            example.OnClick.AddListener(OnClickViewExample);
            clear.OnClick.AddListener(OnClickClear);
        }
        
        private void Start()
        {
            InitButtonListeners();
        }
    }
}
