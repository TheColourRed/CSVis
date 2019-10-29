using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClearAllAction : MonoBehaviour
{

    public TextMeshPro label;
    public void onPress()
    {
        UnityEngine.Debug.LogFormat("ClearAllButton pressed");
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
