using UnityEngine;
using UnityEditor;

//creates instance of scriptable audioObject;
public class audioAsset
{
    [MenuItem("Assets/Create/audio object")]
    public static ScriptableObjectAudio CreateAsset(int i)
    {
        ScriptableObjectAudio asset = ScriptableObject.CreateInstance<ScriptableObjectAudio>();
        AssetDatabase.CreateAsset(asset, "Assets/Resources/Audioplan"+i+ ".asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}