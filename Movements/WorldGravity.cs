using UnityEngine;
using System.Collections;

public class WorldGravity : MonoBehaviour {

	[SerializeField]
	private float gravityIncrement = 1;

	private float _gravity;

	private Rigidbody _rb;

	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		_rb.AddForce( transform.up * _gravity );
		_gravity -= gravityIncrement;
	}

	void OnCollisionStay(Collision obj) {
		_gravity = 0;
	}
}
