using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public UnityEvent IsEnemyDay;
    public float healh = 1;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        if (healh <= 0)
        {
            DayThis();
        }
    }
    private void DayThis()
    {
        IsEnemyDay.Invoke();
        healh = 1;
        gameObject.SetActive(false);
        IsEnemyDay.RemoveAllListeners();
    }

}
