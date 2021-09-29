using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{
    [SerializeField] private int level = 0;
    [SerializeField] private int fearLevel = 0;

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public int LevelUp()
    {
        level++;
        return level;
    }

    public int FearLevel
    {
        get { return fearLevel; }
        set { fearLevel = value; }
    }

    public int FearLevelUp()
    {
        fearLevel++;
        return fearLevel;
    }
}
