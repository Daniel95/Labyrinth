using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {
	[SerializeField]
	private int _levelNumber;

	// Use this for initialization
	void OnCollisionEnter(Collision obj) {
		if (obj.gameObject.tag == "Player") {
			Application.LoadLevel(_levelNumber);
		}
	}
}
