using System.Collections;
using System.Collections.Generic;
using DataVisualization.Plotter;
using TMPro;
using UnityEngine;

namespace CSVis
{
    public class ClearAllAction : MonoBehaviour
    {

        public void onPress()
        {
            Debug.LogFormat("ClearAllButton pressed");
            foreach (var plot in GameObject.FindGameObjectsWithTag("plotContainer"))
            {
                Destroy(plot);
            }
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
