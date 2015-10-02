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
					player.Died();
				} else Destroy (other.gameObject);
			}
		}
	}
}
