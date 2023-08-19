using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;


public class DataStream
{
    public void Serialize(string path, object data)
    {
        if (data == null)
            return;
        if (IsCreateFileSave(path) == false)
            File.Create(path);

        using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
        }
    }
    public  T Deserialize<T>(string path)
    {
        if(CountSymbolInFile(path) == 0)
            return default(T);

        using (FileStream stream = new FileStream(path, FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            T data = (T)formatter.Deserialize(stream);
            return data;
        }
    }

    public int CountSymbolInFile(string path)
    {
        if (IsCreateFileSave(path) == false)
            return 0;

        return File.ReadAllText(path).Length;
    }

    public bool IsCreateFileSave(string path)
    {
        return File.Exists(path);
    }
}
