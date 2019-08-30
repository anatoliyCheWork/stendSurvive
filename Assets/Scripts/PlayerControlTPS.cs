using UnityEngine;

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

	
	void Awake()
	{
		
    }
	
	void FixedUpdate()
	{	
		Rotation();
	}

	void Rotation() // вращение тела, отслеживание курсора
	{
		Vector3 lookPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y)) - transform.position;
		lookPos.y = 0; // поворот в плоскости ХZ

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
