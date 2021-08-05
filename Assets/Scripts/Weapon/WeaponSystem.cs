using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{

    [Header("Система ввода")]
    [SerializeField] private InputSystem _input;
    [Header("Орудия")]
    [SerializeField] private List<GameObject> BulletPrefabs;

    private int indCurrentBulletTypeL = 0;
    private int indCurrentBulletTypeR = 0;
    public Canon CanonL;
    public Canon CanonR;


    private void Update()
    {
        Shot();
    }

    void Shot()
    {
        if (_input._shotL)
        {
            GameObject bulet = BulletPrefabs[indCurrentBulletTypeL];
            CanonL.Shot(bulet);
            _input._shotL = false;
        }
        if (_input._shotR)
        {
            GameObject bulet = BulletPrefabs[indCurrentBulletTypeR];
            CanonR.Shot(bulet);
            _input._shotR = false;
        }
    }
}
