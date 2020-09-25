using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum UIScreens
{
    Idle,
    Settings,
    Shop,
    Playing,
    AdScreen,
    WinScreen,
    FailScreen,
    ChestScreen
}
public class UIManager : MonoBehaviour
{
    public static UIManager main;
    public UIScreens currentScreen;

    public GameObject[] screens;
    public GameObject[] scoreTexts;


    public void Awake()
    {
        main = this;
    }
    public void ChangeScreen(UIScreens screen)
    {
        screens[(int)currentScreen].SetActive(false);
        screens[(int)screen].SetActive(false);
        
        switch (screen)
        {
            case UIScreens.Idle:
                break;
            case UIScreens.Settings:
                break;
            case UIScreens.Shop:
                break;
            case UIScreens.Playing:
                break;
            case UIScreens.AdScreen:
                break;
            case UIScreens.WinScreen:
                break;
            case UIScreens.FailScreen:
                break;
            case UIScreens.ChestScreen:
                break;
            default:
                break;
        }

    }
}
