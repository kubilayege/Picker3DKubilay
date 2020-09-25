using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Level currentLevel;
    public GameObject[] levels;
    int levelIndex;

    public static LevelManager main;
    void Awake()
    {
        main = this;
    }

    public void PassLevel()
    {
        levelIndex++;
        Vector3 newlevelPos = currentLevel.levelEnd.transform.position;
        Destroy(currentLevel.gameObject,2f);
        Instantiate(levels[levelIndex % levels.Length], newlevelPos, Quaternion.identity);
    }

    public void ReloadLevel()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
