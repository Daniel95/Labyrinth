using UnityEngine;
using System.Collections;

public class KillOtherOnTouch: MonoBehaviour 
{
	[SerializeField]
	private string[] collTags;

	void OnCollisionEnter(Collision other) {
		foreach (string cTag in collTags) {
			if(other.gameObject.tag == cTag){
				if(cTag == "Player"){
					var player = other.gameObject.GetComponent<CheckPoints> ();
					var cause = "A " + this.gameObject.name + " Hit You";
					player.Died(cause);
				} else Destroy (other.gameObject);
			}else if(cTag == "All")Destroy (other.gameObject);
		}
	}
}
