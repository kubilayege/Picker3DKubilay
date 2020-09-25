using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Color levelBaseColor;
    public Material levelMat;
    public GameObject[] checkpoints;
    public GameObject levelEnd;
    int currentCheckpoint = 0;
    void Start()
    {
        levelMat.color = levelBaseColor;
    }

    void Update()
    {
        
    }

    public void ProgressCurrentPoint()
    {
        
        currentCheckpoint++;
    }

}
