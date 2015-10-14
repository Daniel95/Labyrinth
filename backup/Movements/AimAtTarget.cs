using UnityEngine;
using System.Collections;

public class AimAtTarget : MonoBehaviour {

	[SerializeField]
	private Transform target;

	[SerializeField]
	private Transform turret;

	// Update is called once per frame
	void Update () {
		turret.LookAt (target.position);
	}
}
