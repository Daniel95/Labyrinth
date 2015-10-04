using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private int bounceStrength;

	private BounceBack _bounceBack;
    private Rigidbody _rb;
    [SerializeField]
    private float boostSpeed;

 void Start () {
 	_bounceBack = GetComponent<BounceBack>();
 	_rb = GetComponent<Rigidbody>();
 }
 
 void OnCollisionEnter(Collision obj) {
	if (obj.collider.gameObject.tag == "BounceBlock") {
	  	_bounceBack.Bounce(obj, bounceStrength);
	}
 }

public void goMove (int moveDir) {
		if (moveDir == 1) _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, boostSpeed);
		else if (moveDir == 2) _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, -boostSpeed);
		else if (moveDir == 3) _rb.velocity = new Vector3(-boostSpeed, _rb.velocity.y, _rb.velocity.z);
		else if (moveDir == 4) _rb.velocity = new Vector3(boostSpeed, _rb.velocity.y, _rb.velocity.z);
    }  
    
}