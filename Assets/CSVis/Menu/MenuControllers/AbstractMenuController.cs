using UnityEngine;

namespace CSVis.Menu.MenuControllers
{
    public abstract class AbstractMenuController : MonoBehaviour
    {
        
        public GameObject currentMenu;
        
        /// <summary>
        /// Simple change from one menu to the next
        /// </summary>
        /// <param name="currentMenu">the current visible menu</param>
        /// <param name="nextMenu">the next menu to show</param>
        protected void ChangeMenu(GameObject nextMenu)
        {
            var trans = currentMenu.transform;

            nextMenu.transform.position = trans.position;
            nextMenu.transform.rotation = trans.rotation;
            nextMenu.SetActive(true);
            currentMenu.SetActive(false);
        }

    }
}