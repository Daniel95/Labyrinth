using UnityEngine;
using System.Collections;

public class FallToDead : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < -50)
		if(this.gameObject.tag == "Player"){
			var player = GetComponent<CheckPoints> ();
			player.Died();
		} else Destroy (this.gameObject);
	}
}
