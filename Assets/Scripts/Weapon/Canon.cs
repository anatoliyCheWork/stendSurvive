using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    public float TemperatureCanan;
    public float MaxTemperatureCanan;
    public float TemperatureInkrease = 0.25f;

    public Transform Origin;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void Shot(GameObject bulet)
    {
        if (TemperatureCanan >= MaxTemperatureCanan) return;
        else
        {

            GameObject _bulet = Instantiate(bulet, Origin.position, transform.rotation);

            float x = Origin.position.x - transform.position.x;
            float y = Origin.position.y - transform.position.y;
            float z = Origin.position.z - transform.position.z;

            _bulet.GetComponent<Bulet>().Fire(new Vector3(x, y, z));
        }
    }
}
