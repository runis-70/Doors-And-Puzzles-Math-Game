using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class DataStream
{
    public void Serialize(string path, object data)
    {
        using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
        }
    }
    public  T Deserialize<T>(string path)
    {
        using (FileStream stream = new FileStream(path, FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            T data = (T)formatter.Deserialize(stream);
            return data;
        }
    }
}
