using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Singleton<GameData>
{
    [SerializeField] private short level = 0;
    [SerializeField] private short fearLevel = 0;

    public short Level
    {
        get { return level; }
        set { level = value; }
    }

    public short LevelUp()
    {
        level++;
        return level;
    }

    public short FearLevel
    {
        get { return fearLevel; }
        set { fearLevel = value; }
    }

    public short FearLevelUp()
    {
        fearLevel++;
        return fearLevel;
    }
}
