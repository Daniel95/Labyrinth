using UnityEngine;
using System.Collections;

public class KillThisOnTouch: MonoBehaviour {

	[SerializeField]
	private string[] _Cobjects;//coll objs

	[SerializeField]
	private string[] _Tobjects;//trigger objs

	void OnCollisionEnter(Collision other) {
		if (_Cobjects [_Cobjects.Length - 1] == "all") {
			Destroy (this.gameObject);
		} else for(int i = 0; i < _Cobjects.Length; i++)
		{
			if (other.gameObject.tag == _Cobjects[i]) Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other) {
		//if (_Tobjects [_Tobjects.Length - 1] == "all") {
			//Destroy (this.gameObject);
		//} else for(int i = 0; i < _Tobjects.Length; i++)
		for(int i = 0; i < _Tobjects.Length; i++)
		{
			if (other.gameObject.tag == _Tobjects[i]) Destroy (this.gameObject);
		}
	}
}
