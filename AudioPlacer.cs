using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Audio;

public class AudioPlacer : MonoBehaviour {
   public ScriptableObjectAudio[] myAudioFile;
    public AudioSource[] audioSources;
    public GameObject emptyPrefab;
    public FileInfo[] xmlInfo;

    private void Awake()
    {
        //check path for the amount of files to iterate through
        xmlInfo = GetFileInfo.FilesRead();
        for (int i = 0; i <xmlInfo.Length ; i++)
        {
            
            //load Audio data
            string filename = "Audioplan" + i.ToString();
            ScriptableObjectAudio AudioData = (Resources.Load(filename,typeof(ScriptableObjectAudio)) as ScriptableObjectAudio);
            Debug.Log(filename);

            //create game object to assign data to
            GameObject audioClass = Instantiate(emptyPrefab) as GameObject;
            audioClass.gameObject.name = "AudioDataClass" + i.ToString();
            audioClass.transform.SetParent(this.transform);

            //assign data to object
            audioClass.AddComponent<AudioSource>();
            audioClass.GetComponent<AudioSource>().clip = Resources.Load(AudioData.clip) as AudioClip;
           
            //audio in xml is multiplied by 10 for ease of use, then divided again for audioSource
            audioClass.GetComponent<AudioSource>().volume = AudioData.volume /10;
            Debug.Log(audioClass.GetComponent<AudioSource>().volume);
            audioClass.GetComponent<AudioSource>().mute = AudioData.mute;
            audioClass.GetComponent<AudioSource>().playOnAwake = AudioData.playOnAwake;
            audioClass.transform.position = AudioData.position;


        }
    }


}
