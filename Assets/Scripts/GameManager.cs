using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum GameStates
{
    Idle,
    Playing,
    CheckPointReached,
    Win,
    Fail
}

public class GameManager : MonoBehaviour
{
    public static GameManager main;
    public GameStates currentState;
    
    void Awake()
    {
        main = this;
    }

    public void ChangeGameState(GameStates state)
    {
        currentState = state;
        switch (state)
        {
            case GameStates.Idle:
                break;
            case GameStates.Playing:
                break;
            case GameStates.CheckPointReached:
                LevelManager.main.currentLevel.ProgressCurrentPoint();
                break;
            case GameStates.Win:
                break;
            case GameStates.Fail:
                break;
            default:
                break;
        }
    }

    public static bool IsIdle()
    {
        return GameManager.main.currentState == GameStates.Idle;
    }

    public static bool IsPlaying()
    {
        return GameManager.main.currentState == GameStates.Playing;
    }

    public static bool IsCP()
    {
        return GameManager.main.currentState == GameStates.CheckPointReached;
    }

    public static bool IsWin()
    {
        return GameManager.main.currentState == GameStates.Win;
    }

    public static bool IsFail()
    {
        return GameManager.main.currentState == GameStates.Fail;
    }

    public static bool IsNotOnUI()
    {
        return EventSystem.current.currentSelectedGameObject == null;
    }
}
