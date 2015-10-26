using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[SerializeField]
	private int bounceStrength;
	[SerializeField]
	private float maxRollSpeed;

	private BounceBack _bounceBack;
    private Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _bounceBack = GetComponent<BounceBack>();
    }

 	void Start () 
    {
		_rb.maxAngularVelocity = maxRollSpeed;
 	}
 
 	void OnCollisionEnter(Collision obj) {
		if (obj.gameObject.tag == "Bounce") {
		  	_bounceBack.Bounce(obj, bounceStrength);
		}
	}

	public void goMove (int moveDir) {
		if (moveDir == 1) _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, _rb.velocity.z / 3);
		else if (moveDir == 2) _rb.velocity = new Vector3(_rb.velocity.x, _rb.velocity.y, _rb.velocity.z / 3);
		else if (moveDir == 3) _rb.velocity = new Vector3(_rb.velocity.x / 3, _rb.velocity.y, _rb.velocity.z);
		else if (moveDir == 4) _rb.velocity = new Vector3(_rb.velocity.x / 3, _rb.velocity.y, _rb.velocity.z);
    }  

    public void stopPlayer()
    {
        _rb.velocity = Vector3.zero;
        _rb.angularVelocity = Vector3.zero;
    }
    
}