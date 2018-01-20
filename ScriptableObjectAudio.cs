using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class for scriptable object of audioData
public class ScriptableObjectAudio : ScriptableObject
{
    public string clip;
    public float volume;
    public bool mute;
    public bool playOnAwake;
    public Vector3 position;

}
