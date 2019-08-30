using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    Play, Pause
}
public class GameCycle : MonoBehaviour
{
    public static GameCycle obj;
    public int countKill;

    public GameState state;

    public List<GameObject> startPoints;


    public float TimeToInstNewEnemy;
    public float minTimeToInstNewEnemy;
    public float stepSpeedDecrement = 0.01f;


    private float curTime;

    public GameObject EnemyPrefab;
    void Start()
    {
        if (obj == null)
            obj = this;
        state = GameState.Pause;
    }

    void Update()
    {
        if (state == GameState.Play)
            Tick();
    }


    private void Tick()
    {
        if (curTime < 0)
        {
            curTime = TimeToInstNewEnemy;
            CreateNewEnemy();
        }
        else
        {
            curTime -= Time.deltaTime;
        }
    }

    internal void StartGame()
    {
        state = GameState.Play;
    }

    private UnityAction onEnemyDay()
    {
        return isDay;
    }


    private void isDay()
    {
        countKill++;
        if (TimeToInstNewEnemy > minTimeToInstNewEnemy)
            TimeToInstNewEnemy -= stepSpeedDecrement;
        GameUI.gameUIObj.UpdScore(countKill);
    }

    private void CreateNewEnemy()
    {
        GameObject enGO = Instantiate(EnemyPrefab, startPoints[UnityEngine.Random.Range(0, 100) % startPoints.Count].transform.position, Quaternion.identity);
        Enemy enemy = enGO.GetComponent<Enemy>();
        enemy.IsEnemyDay.AddListener(onEnemyDay());
    }
}
