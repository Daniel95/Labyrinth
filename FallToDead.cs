using UnityEngine;
using System.Collections;

public class FallToDead : MonoBehaviour {

	void OnCollisionEnter(Collision obj){
		if (obj.gameObject.tag == "Void") {
			if (this.gameObject.tag == "Player") {
				var player = GetComponent<CheckPoints> ();
				var cause = "You Fell To Your Dead";
				player.Died (cause);
			} else
				Destroy (this.gameObject);
		}
	}
}
