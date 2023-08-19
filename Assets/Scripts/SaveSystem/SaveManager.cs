using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : DataStream
{
    private string _pathSaveFile;

    public SaveManager(string pathSaveFile)
    {
        _pathSaveFile = pathSaveFile;
    }

    public void CreateSafe(PlayerData playerData)
    {
        if (playerData != null)
            base.Serialize(_pathSaveFile, playerData);
        else
            throw new Exception("Сохранения пусты");
    }
    public PlayerData LoadSafe()
    {
        return base.Deserialize<PlayerData>(_pathSaveFile);
    }
}
