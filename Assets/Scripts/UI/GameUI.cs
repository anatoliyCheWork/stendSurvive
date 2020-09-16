using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Screens _screens;




    public static GameUI gameUIObj;

    public Text Count;
    

   
    void Start()
    {
        if (gameUIObj == null)
            gameUIObj = this;
    }

    public void UpdScore(int count)
    {
        string s =  count.ToString();
        Count.text = s;
        if (count < PlayerPrefs.GetInt("score", 0))
        {
            PlayerPrefs.SetInt("score", count);
        }
    }
    public void UpdBestScore()
    {
        string s = PlayerPrefs.GetInt("score", 0).ToString();
        Count.text = s;
    }

    public void PlayClick()
    {        
        GameCycle.obj.StartGame();
    }
}
