using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public int level;
    public float[] position;

    public PlayerData(Player player)    
    {
        position = new float[3]
        {
        player.transform.position.x,
        player.transform.position.y,
        player.transform.position.z,
        };
    }
}
