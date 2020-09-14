using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Screens _screens;




    public static GameUI gameUIObj;

    public Text Count;
    public GameObject PlayPanel;

    public string DefaultText = "You kill {0} enemy";
    public string DefaultBestText = "You best kill {0} enemy";
    // Start is called before the first frame update
    void Start()
    {
        if (gameUIObj == null)
            gameUIObj = this;
    }

    public void UpdScore(int count)
    {
        string s = string.Format(DefaultText, count);
        Count.text = s;
        if (count < PlayerPrefs.GetInt("score", 0))
        {
            PlayerPrefs.SetInt("score", count);
        }
    }
    public void UpdBestScore()
    {
        string s = string.Format(DefaultBestText, PlayerPrefs.GetInt("score", 0));
        Count.text = s;
    }

    public void PlayClick()
    {
        PlayPanel.SetActive(false);
        GameCycle.obj.StartGame();
    }
}
