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

    void Awake()
	{
		
    }
	
	void FixedUpdate()
	{	
		Rotation();
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
            GameObject bulet = BulletPrefabs[indCurrentBulletTypeR];
            CanonR.Shot(bulet);
        }
    }

	void Rotation() 
	{
		Vector3 lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y)) - transform.position;
		lookPos.y = 0; 

		if(useSmooth)
		{
			Quaternion playerRotation = Quaternion.LookRotation(lookPos);
			bodyTransform.rotation = Quaternion.Lerp(bodyTransform.rotation, playerRotation, smooth * Time.fixedDeltaTime);	
		}
		else
		{
			bodyTransform.rotation = Quaternion.LookRotation(lookPos);
		}
	}
}
