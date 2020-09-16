using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class Screens : MonoBehaviour
{
    [SerializeField] private Screen _startScreen;

    [SerializeField] private Screen _currentScreen;
    public Screen CurrentScreen { get => _currentScreen; }

    [SerializeField] private List<ScreenBase> ScreensList;


    #region MonoBehaviour
    private void Awake()
    {
        ShowScreen(_startScreen);

        ScreenCategoryes.OnScreenCategoryClick += ShowScreen;
    }
    #endregion

    public void ShowScreen(Screen screen)
    {
        foreach (var item in ScreensList)
        {
            if (item.ThisScreen == screen)
            {
                item.Show();
            }
            else
            {
                item.Hide();
            }
        }
    }
}

public enum Screen
{
    Store,
    PlayerDetail,
    LevelSelect,
    Talants,
    Events,
    GamePlay
}
