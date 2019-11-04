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

#if ENABLE_WINMD_SUPPORT
        UnityEngine.Debug.Log("ENABLE_WINMD_SUPPORT true");
        new FileSelector().SelectFile();
       
#else
        UnityEngine.Debug.Log("ENABLE_WINMD_SUPPORT false");
        label.SetText("File explorer can not be opend in this environemnt");
#endif

    }

#if ENABLE_WINMD_SUPPORT
    public async StorageFile OpenFileAsync()
    {  
        UnityEngine.Debug.LogFormat( "OpenFileAsync() on Thread: {0}", Thread.CurrentThread.ManagedThreadId );

        openPicker = new FileOpenPicker();
 
        //openPicker.ViewMode = PickerViewMode.Thumbnail;
        //openPicker.SuggestedStartLocation = PickerLocationId.Objects3D;
        //openPicker.FileTypeFilter.Add(".fbx");
        openPicker.FileTypeFilter.Add("*");
     
        StorageFile file = await openPicker.PickSingleFileAsync();
        string labelText = String.Empty;
        if ( file != null )
        {
            // Application now has read/write access to the picked file 
            labelText = "Picked file: " + file.DisplayName;
            return file;
        }
        else
        {
            // The picker was dismissed with no selected file 
            labelText = "File picker operation cancelled";
        }
        
        UnityEngine.Debug.Log( labelText );

        UnityEngine.WSA.Application.InvokeOnAppThread( ThreadCallback, false );

        UnityEngine.WSA.Application.InvokeOnAppThread( new AppCallbackItem( () => { label.SetText(labelText); } ), false );
    }
#endif

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
