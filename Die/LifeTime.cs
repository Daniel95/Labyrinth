using UnityEngine;
using System.Collections;

public class LifeTime : MonoBehaviour {

	[SerializeField]
	private float killTimer = 100f;//time between spawns
	//[SerializeField]
	//private float spawnDelay = 3f; //time for spawntime to start

	// Use this for initialization
	void Start () {
		InvokeRepeating("KillSelf", killTimer, 0);
	}

	void KillSelf() {
		Destroy (this.gameObject);
	}
}
