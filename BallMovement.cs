﻿using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

	[SerializeField]
	private float speed;
	[SerializeField]
	private int bounceStrength = 30;
	
	private BounceBack _bounceBack;
	private Rigidbody _rb;

	// Use this for initialization
	void Start () {
		_bounceBack = GetComponent<BounceBack> ();
		_rb = GetComponent<Rigidbody> ();
		_rb.AddForce( this.transform.right * 100 );
	}

	void Update(){
		_rb.AddForce( this.transform.right * speed );
	}

	void OnCollisionEnter(Collision obj) {
		if (obj.collider.gameObject.transform.position.y >= this.transform.position.y) {
			_bounceBack.Bounce(obj, bounceStrength);
		}
	}
}