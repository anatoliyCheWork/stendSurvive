using System;
using UnityEngine;

public class ScreenBase : MonoBehaviour
{
    public Screen ThisScreen;

    public void Init()
    {

    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}