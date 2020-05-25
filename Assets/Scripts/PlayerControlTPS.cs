using UnityEngine;
using System.Collections.Generic;

public class PlayerControlTPS : MonoBehaviour
{
    [Header("Вращение:")]
    public Transform bodyTransform; // объект вращения (локальный)
    public float smooth = 3;
    public bool useSmooth;

    [Header("Родительский объект камеры")]
    public Transform cameraParent;

    [Header("Игнорировать маски")]
    public LayerMask ignoreMask;

    private Vector3 direction;

    [Header("Орудия")]
    public List<GameObject> BulletPrefabs;
    private int indCurrentBulletTypeL = 0;
    private int indCurrentBulletTypeR = 0;
    public Canon CanonL;
    public Canon CanonR;

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
        Rotation();
        Shot();
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

    void Shot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bulet = BulletPrefabs[indCurrentBulletTypeL];
            CanonL.Shot(bulet);
        }
        if (Input.GetMouseButtonDown(1))
        {
            GameObject bulet = BulletPrefabs[indCurrentBulletTypeL];
            CanonR.Shot(bulet);
        }
    }

    void Rotation()
    {
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y)) - transform.position;
        lookPos.y = 0;
        Quaternion playerRotation = Quaternion.LookRotation(lookPos);
        bodyTransform.rotation = Quaternion.Lerp(bodyTransform.rotation, playerRotation, smooth * Time.fixedDeltaTime);

    }
}
