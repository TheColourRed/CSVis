using System;
using TMPro;
using UnityEngine;

namespace CSVis.Menu.ButtonActions
{
    public class SelectFileAction : MonoBehaviour
    {
        public TextMeshPro label;

        public void onPress()
        {
            Debug.Log("SelectFileButton pressed");

            Tuple<string, string> fileData = null;
#if ENABLE_WINMD_SUPPORT
            Debug.Log("ENABLE_WINMD_SUPPORT true");
            fileData = new FileSelector().SelectFile();
#else
            Debug.Log("ENABLE_WINMD_SUPPORT false");
            label.SetText("File explorer can not be opened in this environment");
#endif
            if (fileData == null)
            {
                Debug.Log("No file was selected");
                label.SetText("No file was selected");
            }
            else
            {
                Debug.LogFormat("{0} selected", fileData.Item1);
                label.SetText(fileData.Item1);
                var testFileContentText = new GameObject();
                var textMesh = testFileContentText.AddComponent<TextMesh>();
                var meshRenderer = testFileContentText.AddComponent<MeshRenderer>();
                
                Vector3 forwardVector = Camera.main.gameObject.transform.forward;
                forwardVector.y = 0;
                forwardVector.Normalize();

                textMesh.transform.position = Camera.main.gameObject.transform.position + forwardVector * 0.8f;
                textMesh.transform.rotation = Quaternion.LookRotation(-forwardVector);

                textMesh.text = fileData.Item2;
            }
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
}
