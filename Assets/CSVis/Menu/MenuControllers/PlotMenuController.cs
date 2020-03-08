using System;
using UnityEngine;

namespace CSVis.Menu.MenuControllers
{
    public class PlotMenuController : MonoBehaviour
    {
        private Transform plotHolder;
        private BoxCollider boxCollider;
        private float angleFromBox = 135f;
        private bool hasCollider = false;

        private void Start()
        {
            plotHolder = gameObject.transform.parent.Find("PlotHolder");
            gameObject.transform.parent = plotHolder.transform;
        }

        public void Update()
        {
            if (hasCollider == false)
            {
                boxCollider = plotHolder.GetComponent<BoxCollider>();
                hasCollider = true;

                var tans = plotHolder.transform;
                var size = boxCollider.size;
                var origin = tans.position;

                size *= 0.5f;
                size.Scale(tans.localScale);
                
                gameObject.transform.position = new Vector3(
                    origin.x + size.x,
                    origin.y - size.y,
                    origin.z - size.z
                );

                gameObject.transform.rotation = tans.transform.rotation;
            }
        }
        
    }

}