using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    //SerializeField
    [SerializeField] private Rigidbody _body;
    [SerializeField] private float _power = 25.0f;
    [SerializeField] private float _destroyTime = 5.0f;


    #region MonoBehaviour
    private void Awake()
    {
        _body = GetComponent<Rigidbody>();
    }

    #endregion MonoBehaviour

    internal void Fire(Vector3 Force)
    {
        _body.AddForce((Force.normalized * _power), ForceMode.Impulse);
        StartCoroutine(BulletDestroy());
    }

    private IEnumerator BulletDestroy()
    {
        yield return new WaitForSeconds(_destroyTime);

        Destroy(gameObject);
    }

    public float GetPower()
    {
        return _power;
    }

    private void OnTriggerEnter(Collider other)
    {

        Enemy enemy;

        other.TryGetComponent(out enemy);

        if (enemy != null)
        {
            Debug.LogError(other.name);
            enemy.ApplyDamage(_power);
        }
    }


}
