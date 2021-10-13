using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseSetup : MonoBehaviour
{
    [SerializeField] private GameObject xrRig;
    [SerializeField] private GameObject[] levelObjects;
    [SerializeField] private Vector3[] levelPositions;

    private short levelVal = 0;

    // Start is called before the first frame update
    void Start()
    {
        xrRig = GameObject.Find("XR Rig");
        levelVal = GameData.Instance.Level;

        switch (levelVal)
        {
            default:
                Debug.LogError("FATAL: HouseSetup.cs Line 19 - levelVal (called from GameData singleton) value exceeds expected range");
                break;
            case 0:
                foreach (var lvlobj in levelObjects)
                {
                    lvlobj.SetActive(false);
                }
                levelObjects[0].SetActive(true);
                xrRig.transform.position = levelPositions[0];
                break;
            case 1:
                foreach (var lvlobj in levelObjects)
                {
                    lvlobj.SetActive(false);
                }
                levelObjects[1].SetActive(true);
                xrRig.transform.position = levelPositions[1];
                break;
            case 2:
                foreach (var lvlobj in levelObjects)
                {
                    lvlobj.SetActive(false);
                }
                levelObjects[2].SetActive(true);
                xrRig.transform.position = levelPositions[2];
                break;
        }
    }

    public void IncrementGameLevel()
    {
        GameData.Instance.LevelUp();
    }

    public void IncrementFearLevel()
    {
        GameData.Instance.FearLevelUp();
    }

    public int ReturnGameLevel()
    {
        return GameData.Instance.Level;
    }

    public int ReturnFearLevel()
    {
        return GameData.Instance.FearLevel;
    }
}
