using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAction : MonoBehaviour
{
    public GameObject MainMenuPrefab;
    
    public GameObject ExampleMenuInstance;

    public GameObject DataFormatMenuInstance;

    public void OnFileSelect()
    {
        Debug.Log("FileSelectButton pressed");
        MainMenuPrefab.SetActive(false);
        DataFormatMenuInstance.SetActive(true);
    }
    
    public void OnCloseDataFormatMenu()
    {
        Debug.Log("DataFormatMenuButton pressed");
        MainMenuPrefab.SetActive(true);
        ExampleMenuInstance.SetActive(false);
    }
    
    public void OnViewExample()
    {
        Debug.Log("LoadExampleButton pressed");
        MainMenuPrefab.SetActive(false);
        ExampleMenuInstance.SetActive(true);
    }

    public void OnCloseExample()
    {
        Debug.Log("CloseExampleButton pressed");
        ExampleMenuInstance.SetActive(false);
        MainMenuPrefab.SetActive(true);
    }
    
}
