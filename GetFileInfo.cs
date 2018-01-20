using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using UnityEditor;

//returns all files with the XML_Extension and filters the result to see if usable
public static class GetFileInfo  {



    public static FileInfo[] FilesRead()
    {
      
        DirectoryInfo dir = new DirectoryInfo("Assets/Resources");
        FileInfo[] info = dir.GetFiles("*.xml");
        return info;
    }

	public static bool FilteredInfo(FileInfo file ){

        string loadFile = file.Name;
        bool iterate;
        loadFile = loadFile.Substring(0, loadFile.Length - 4);

        TextAsset _dataXML = (TextAsset)Resources.Load(loadFile);
		XmlDocument documentXML = new XmlDocument();
        Debug.Log(file.Name);
        documentXML.LoadXml(_dataXML.text);
        string toCheck = _dataXML.text;

        
       

        //check if file is audioclass, choose this way because reading the xml nodes directly didn't work
        if (toCheck.Contains("AudioPlanClass")) {
            Debug.Log("made");
            iterate = true; ;

		} else {
            iterate = false; ;
		}

        return iterate;

	
	}
}
