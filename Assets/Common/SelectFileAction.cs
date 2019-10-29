using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectFileAction : MonoBehaviour
{
    public TextMeshPro label;

    public void onPress()
    {
        UnityEngine.Debug.LogFormat("SelectFileButton pressed");

        new FileSelector().SelectFile();

        #if ENABLE_WINMD_SUPPORT
        UnityEngine.Debug.Log("ENABLE_WINMD_SUPPORT true");
        

        #else
        UnityEngine.Debug.Log("ENABLE_WINMD_SUPPORT false");
        label.SetText("File explorer can not be opend in this environemnt");
        #endif

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
