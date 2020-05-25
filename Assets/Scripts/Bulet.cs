using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{

    public Rigidbody body;
    public float Power;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }

    internal void Fire(Vector3 Force)
    {
        body.AddForce((Force.normalized * Power), ForceMode.Impulse);
    }
}
