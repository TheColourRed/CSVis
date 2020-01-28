using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElementDragger : MonoBehaviour
{
    
    public GameObject Cursor;

    private bool dragging;
    
    public void Update() {
        if (dragging) {
            Vector3 gazePos = Cursor.transform.position;
            transform.position = new Vector2(gazePos.x, gazePos.y);
        }
    }

    public void OnPointerDown() {
        Debug.Log("Tag dragging...");
        dragging = true;
    }

    public void OnPointerUp() {
        Debug.Log("Tag dropped");
        dragging = false;
    }
    
}
