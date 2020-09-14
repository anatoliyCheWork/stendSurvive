using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class Screens : MonoBehaviour
{
    public Screen CurrentScreen;

    public List<ScreenBase> ScreensList;



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
    Events
}
