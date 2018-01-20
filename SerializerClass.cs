using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;


//serializes or desirializes data
public class SerializerClass {
   
 

    public static void Serialize(object item, string path)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(item.GetType());
        StreamWriter writer = new StreamWriter(path);
        xmlSerializer.Serialize(writer.BaseStream, item);
        writer.Close();
        Debug.Log("done");
    }


    public static T Deserialize<T>(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        StreamReader reader = new StreamReader(path);
        T deserialized = (T)serializer.Deserialize(reader.BaseStream);
        reader.Close();
        return deserialized;
    }
}

