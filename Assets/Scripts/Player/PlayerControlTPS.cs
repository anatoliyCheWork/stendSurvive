using UnityEngine;
using System.Collections.Generic;

public class PlayerControlTPS : MonoBehaviour
{
 

    [Header("Родительский объект камеры")]
    public Transform cameraParent;

    [Header("Игнорировать маски")]
    public LayerMask ignoreMask;

    private Vector3 direction;



    [SerializeField] private Vector3 _moveVector;
    [SerializeField] private CharacterController _character;
    [SerializeField] private float _moveSpeed = 10f;


    [SerializeField] private Joystick joystick;
    void Awake()
    {
        _character.GetComponent<CharacterController>();
    }

    public void Update()
    {
        Move();      
    }



    private void Move()
    {
        _moveVector.x = joystick.Horizontal;
        _moveVector.z = joystick.Vertical;
        if (_moveVector.magnitude >= 0.1f)
        {
            _character.Move(_moveVector * _moveSpeed * Time.deltaTime);
        }
    }



  

  
}
