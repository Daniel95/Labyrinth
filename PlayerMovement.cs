using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private int bounceStrength;

	private BounceBack _bounceBack;
    private Rigidbody rb;
    [SerializeField]
    public int boostSpeed;

 void Start () {
 	_bounceBack = GetComponent<BounceBack>();
 	rb = GetComponent<Rigidbody>();
 }
 
 void OnCollisionEnter(Collision obj) {
	if (obj.collider.gameObject.tag == "BounceBlock") {
	  	_bounceBack.Bounce(obj, bounceStrength);
	}
 }

public void goMove (int moveDir) {
        if (moveDir == 1) rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, boostSpeed);
        else if (moveDir == 2) rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -boostSpeed);
        else if (moveDir == 3) rb.velocity = new Vector3(-boostSpeed, rb.velocity.y, rb.velocity.z);
        else if (moveDir == 4) rb.velocity = new Vector3(boostSpeed, rb.velocity.y, rb.velocity.z);
    }  
    
}