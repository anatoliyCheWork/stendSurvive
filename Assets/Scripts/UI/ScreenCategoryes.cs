using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenCategoryes : MonoBehaviour
{
    public static Action<Screen> OnScreenCategoryClick;

    [SerializeField] private Screen screen;

    [SerializeField] private Image _image;

    [SerializeField] private Color _selectColor;
    [SerializeField] private Color _deSelectColor;

    #region MonoBehaviour

    private void Awake()
    {
        Init();

        ScreenBase.OnScreenHide += DeSelectCategory;
        ScreenBase.OnScreenShow += SelectCategory;        
    }

    #endregion

    private void Init()
    {
        _image = GetComponent<Image>();
    }
    private void SelectCategory(Screen obj)
    {
        if (obj == screen) 
        {
            _image.color = _selectColor;
        }
    }

    private void DeSelectCategory(Screen obj)
    {
        if (obj == screen)
        {
            _image.color = _deSelectColor;
        }
    }


    public void Click()
    {
        OnScreenCategoryClick?.Invoke(screen);
    }
}
