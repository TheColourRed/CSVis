﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAction : MonoBehaviour
{
    public GameObject MainMenuPrefab;
    
    public GameObject ExampleMenuInstance;

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
