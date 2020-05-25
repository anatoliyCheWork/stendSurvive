using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    // public
    public static Action IsEnemyDay;
    public float healh = 1;

    //private
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        if (GameCycle.obj)
            agent.SetDestination(GameCycle.obj.PlayerPosition);
    }

    public void ApplyDamage(float damage)
    {

        healh -= damage;
        if (healh <= 0)
        {
            DayThis();
        }
    }
    private void DayThis()
    {
        IsEnemyDay?.Invoke();
        gameObject.SetActive(false);
    }


}
