using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	[SerializeField]
	private float rotateSpeed;

	// Update is called once per frame
	void Update () {
		transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
	}
}
