using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewExampleAction : MonoBehaviour
{

    public TextMeshPro label;

    public void onPress()
    {
        UnityEngine.Debug.LogFormat("LoadExampleButton pressed");
        label.SetText("Coming soon");
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
