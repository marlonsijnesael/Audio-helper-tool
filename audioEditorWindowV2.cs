using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEditor;
using System.IO;

//audio editor window
[RequireComponent(typeof(AudioPlanClass))]
[System.Serializable]
public class audioEditorWIndowV2 : EditorWindow
{

    public ScriptableObjectAudio AudioDataObject;
    public FileInfo[] xmlInfo;

    [MenuItem("Window/audioEditorV2")]
    public static void ShowWindow()
    {
        GetWindow<audioEditorWIndowV2>("audioEditorv2");
    }


    private void OnGUI()
    {



        //start window horizontally
        GUILayout.Label("Click here to create scriptable object from XML files", EditorStyles.boldLabel);
        if (GUILayout.Button("Create data file"))
        {

            CreateItemList();
        }




    }



    void CreateItemList()
    {

        if (AudioDataObject != null)
        {

            string relPath = AssetDatabase.GetAssetPath(AudioDataObject);
            EditorPrefs.SetString("ObjectPath", relPath);
        }

        xmlInfo = GetFileInfo.FilesRead();
        for (int i = 0; i <= xmlInfo.Length-1; i++)
        {
            bool iterate = GetFileInfo.FilteredInfo(xmlInfo[i]);
            Debug.Log(iterate);
            if (iterate)
            {

                //creates scriptable object and save it at the designated folder
                AudioDataObject = new ScriptableObjectAudio();
                AudioDataObject = audioAsset.CreateAsset(i);

                //
                AudioPlanClass audioData = new AudioPlanClass();

                //reads xml and assignes values to instance of class
                audioData = SerializerClass.Deserialize<AudioPlanClass>("Assets/Resources/audio" + i + ".xml");

                //assigns data from instance of class to scriptable object
                AudioDataObject.volume = audioData.volume;
                AudioDataObject.clip = audioData.clip;
                AudioDataObject.mute = audioData.mute;
                AudioDataObject.playOnAwake = audioData.playOnAwake;
                AudioDataObject.position = new Vector3(audioData.position_X, audioData.position_y, audioData.position_z);
            }
            if (!iterate)
            {
                Debug.Log("error");

            }



        }
    }
}

	
