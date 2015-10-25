using UnityEngine;
using System.Collections;

public class WorldGravity : MonoBehaviour {

	[SerializeField]
	private float gravityIncrement = 100;

	private float _gravity;

	private Rigidbody _rb;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//gravity increases every frame.
		_rb.AddForce( transform.up * _gravity * Time.fixedDeltaTime);
		_gravity -= gravityIncrement * Time.fixedDeltaTime;
	}

	void OnCollisionStay(Collision obj) {
		//if in touch with other objects, gravity is 0;
		_gravity = 0;
	}
}
