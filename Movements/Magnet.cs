using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {

	[SerializeField]
	private string[] objsToCheck;

	private GameObject[] objsToPull;

	[SerializeField]
	private float gravity;

	// Update is called once per frame
	void FixedUpdate () {
		foreach (GameObject obj in objsToPull) {
			obj.transform.LookAt (transform.position);
			//obj.attachedRigidbody.AddForce( transform.right * speed );
		}
	}

	void OnTriggerEnter(Collider obj) {
		foreach (string tag in objsToCheck) {
			if (obj.gameObject.tag == tag) {
				//objsToPull += obj.gameObject;
			}
		}
	}

	void OnTriggerExit(Collider obj) {
		foreach (string tag in objsToCheck) {
			if (obj.gameObject.tag == tag) {
				//objsToPull -= obj.gameObject;
			}
		}
	}
}
