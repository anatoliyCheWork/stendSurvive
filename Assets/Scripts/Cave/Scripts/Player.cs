using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody _rigidbody;
	private Vector3 velocity;
	
	void Start () {
		_rigidbody = GetComponent<Rigidbody> ();
	}

	void Update () {
		velocity = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")).normalized * 10;
	}

	void FixedUpdate() {
		_rigidbody.MovePosition (_rigidbody.position + velocity * Time.fixedDeltaTime);
	}
}
