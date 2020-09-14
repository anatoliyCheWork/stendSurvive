using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCategoryes : MonoBehaviour
{
    public Screens screens;

    public Screen screen;

    public void Click()
    {
        screens.ShowScreen(screen);
    }
}
