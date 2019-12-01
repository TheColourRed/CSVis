using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System;
using UnityEngine.WSA;
using UnityEngine.UI;
using TMPro;

#if ENABLE_WINMD_SUPPORT
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Storage.Pickers;
#endif

namespace CSVis.IO
{
    public class FileSelector
    {
        private string fileName;

        private string fileContent;
            
#if ENABLE_WINMD_SUPPORT
    private FileOpenPicker openPicker;
#endif

        /// <summary>
        /// Selects a file via file picker and returns the
        /// file name and its contents back as a tuple
        /// </summary>
        /// <returns>returns a Tuple of &lt;file name, file content&gt;, null if no file was read</returns>
        public Tuple<string, string> SelectFile()
        {
            UnityEngine.Debug.LogFormat("UnityThread: {0}", Thread.CurrentThread.ManagedThreadId);
            fileName = string.Empty;
            fileContent = string.Empty;

            //FIXME The async inside the async invoke on ui thread does not wait and returns before file selection...
            // Instead of returning the strings with the fields maybe return the file instead?
            // Or just get the text here (wait for it) and then return that.
#if ENABLE_WINMD_SUPPORT
        UnityEngine.WSA.Application.InvokeOnUIThread(OpenFileAsync, true);  
#else
            UnityEngine.Debug.Log("ENABLE_WINMD_SUPPORT false");
#endif
            return string.IsNullOrEmpty(fileName) ? null : new Tuple<string, string>(fileName, fileContent);
        }

        void ThreadCallback()
        {
            UnityEngine.Debug.LogFormat("ThreadCallback() on thread: \t{0}", Thread.CurrentThread.ManagedThreadId);
        }

#if ENABLE_WINMD_SUPPORT
        public async void OpenFileAsync()
        {  
            UnityEngine.Debug.LogFormat( "OpenFileAsync() on Thread: {0}", Thread.CurrentThread.ManagedThreadId );

            openPicker = new FileOpenPicker();
     
            //openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.FileTypeFilter.Add(".csv");
         
            var file = await openPicker.PickSingleFileAsync().AsTask();
            
            if ( file != null )
            {
                // Application now has read/write access to the picked file 
                fileName = file.DisplayName;
                fileContent = await Windows.Storage.FileIO.ReadTextAsync(file);
            }
            
            UnityEngine.WSA.Application.InvokeOnAppThread( ThreadCallback, false );
        }
#endif

    }
}