using UnityEngine;
using System.Collections;

public class KillThisOnTouch: MonoBehaviour {

	[SerializeField]
	private string[] _Cobjects;

	void OnCollisionEnter(Collision other) {
		if (_Cobjects [_Cobjects.Length - 1] == "all")
			Destroy (this.gameObject);
		else for(int i = 0; i < _Cobjects.Length; i++)
		{
			if (other.gameObject.tag == _Cobjects[i]) Destroy (this.gameObject);
		}
	}
}
