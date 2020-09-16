using System;
using UnityEngine;

public class ScreenBase : MonoBehaviour
{
    public static Action<Screen> OnScreenShow;
    public static Action<Screen> OnScreenHide;

    public Screen ThisScreen;



    public void Init()
    {

    }

    public void Show()
    {
        gameObject.SetActive(true); 
        OnScreenShow?.Invoke(ThisScreen);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        OnScreenHide?.Invoke(ThisScreen);
    }
}