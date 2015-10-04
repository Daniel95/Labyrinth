using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	[SerializeField]
	private int bounceStrength;

	private BounceBack _bounceBack;

	// Use this for initialization
	void Start () {
		_bounceBack = GetComponent<BounceBack>();
	}
	
	void OnCollisionEnter(Collision obj) {
		if (obj.collider.gameObject.tag == "BounceBlock") {
			_bounceBack.Bounce(obj, bounceStrength);
		}
	}
}
