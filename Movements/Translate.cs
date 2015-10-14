using UnityEngine;
using System.Collections;

public class Translate : MonoBehaviour {

	[SerializeField]
	private float _xSpeed;
	[SerializeField]
	private float _ySpeed;
	[SerializeField]
	private float _zSpeed;
	
	void Update () {
		transform.Translate(_xSpeed, _ySpeed, _zSpeed);
	}
}