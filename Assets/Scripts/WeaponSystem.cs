using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [Header("Орудия")]
    public List<GameObject> BulletPrefabs;
    private int indCurrentBulletTypeL = 0;
    private int indCurrentBulletTypeR = 0;
    public Canon CanonL;
    public Canon CanonR;
    [Header("Вращение:")]
    public Transform bodyTransform;
    public float smooth = 3;
    public bool useSmooth;

    private void Update()
    {
        Shot();
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
