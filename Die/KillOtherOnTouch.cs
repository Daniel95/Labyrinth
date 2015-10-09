using UnityEngine;
using System.Collections;

public class KillOtherOnTouch: MonoBehaviour 
{
	[SerializeField]
	private string[] _Cobjects;

	void OnCollisionEnter(Collision other) {
		if (_Cobjects [_Cobjects.Length - 1] == "all")
			Destroy (other.gameObject);
		else for(int i = 0; i < _Cobjects.Length; i++)
		{
			if (other.gameObject.tag == _Cobjects[i]){
				if(_Cobjects[i] == "Player"){
					var player = other.gameObject.GetComponent<CheckPoints> ();
					var cause = "A " + this.gameObject.name + " Hit You";
					player.Died(cause);
				} else Destroy (other.gameObject);
			}
		}
	}
}
