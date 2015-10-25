using UnityEngine;
using System.Collections;

public class ForcedRolling : MonoBehaviour {

	[SerializeField]
	private int bounceStrength;

	private BounceBack _bounceBack;
	private Rigidbody _rb;

	// Use this for initialization
	void Start () {
		_bounceBack = GetComponent<BounceBack> ();
		_rb = GetComponent<Rigidbody> ();

		_rb.AddForce( transform.right * 500 );
	}

	void OnCollisionEnter(Collision obj) {
		if (obj.gameObject.transform.position.y >= transform.position.y && obj.gameObject.tag != "Ground") {
			_bounceBack.Bounce(obj, bounceStrength);
		}
	}
}
