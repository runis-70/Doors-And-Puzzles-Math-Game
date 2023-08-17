using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : DataStream
{
    public string pathSaveFile;

    public SaveManager(string pathSaveFile)
    {
        this.pathSaveFile = pathSaveFile;

        if (!File.Exists(pathSaveFile))
        {
            throw new IOException("Null file to path");
        }
    }

    public void Save(object data)
    {
        base.Serialize(pathSaveFile, data);
    }
    public T Load<T>()
    { 
        return base.Deserialize<T>(pathSaveFile);
    }
}
