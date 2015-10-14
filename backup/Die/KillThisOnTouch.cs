using UnityEngine;
using System.Collections;

public class KillThisOnTouch: MonoBehaviour {

	[SerializeField]
	private string[] collTags;//coll objs

	[SerializeField]
	private string[] TrigTags;//trigger objs

	void OnCollisionEnter(Collision other) {
		foreach(string cTag in collTags){
			if (other.gameObject.tag == cTag || cTag == "All") Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		foreach(string tTag in TrigTags){
			if (other.gameObject.tag == tTag || tTag == "All") Destroy (this.gameObject);
		}
	}
}
