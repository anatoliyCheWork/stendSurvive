using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCamera : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform Reference;
    void Start()
    {
        gameObject.transform.position = Reference.position;
        gameObject.transform.rotation = Reference.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
