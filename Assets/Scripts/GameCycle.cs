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
    [SerializeField] public PlayerControlTPS _player;
    public Vector3 PlayerPosition { get { return _player.transform.position; } }

    public GameState state;

    public List<GameObject> startPoints;

    [Header("EnemySetUp")]
    public float TimeToInstNewEnemy;
    public float minTimeToInstNewEnemy;
    [SerializeField] float stepSpeedDecrement = 0.01f;
    public GameObject EnemyPrefab;
    private float curTime;
    [Header("Shot Circle")]
    [SerializeField] GameObject ShotCircle;
    [SerializeField] float minSize = 1;
    [SerializeField] float maxSize = 2;
    [SerializeField] float StepSpeedIncrementCircle = 0.01f;
    
    void Start()
    {
        if (obj == null)
            obj = this;
        state = GameState.Pause;
        InitShotCircle();
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

    public void StartGame()
    {
        state = GameState.Play;
        Enemy.IsEnemyDay += isDayEnemy;
    }




    private void isDayEnemy()
    {
        countKill++;
        if (TimeToInstNewEnemy > minTimeToInstNewEnemy)
            TimeToInstNewEnemy -= stepSpeedDecrement;

        if (ShotCircle.transform.localScale.x < maxSize)
            ShotCircle.transform.localScale += new Vector3(StepSpeedIncrementCircle, StepSpeedIncrementCircle, StepSpeedIncrementCircle);
        GameUI.gameUIObj.UpdScore(countKill);
    }



    private void CreateNewEnemy()
    {
        GameObject enGO = Instantiate(EnemyPrefab, startPoints[UnityEngine.Random.Range(0, 1000) % startPoints.Count].transform.position, Quaternion.identity);
        Enemy enemy = enGO.GetComponent<Enemy>();
        
    }

    private void InitShotCircle()
    {
        ShotCircle.transform.localScale = new Vector3(minSize, minSize, minSize);
    }

}
