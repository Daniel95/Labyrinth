using UnityEngine;
using System.Collections;

public class CheckPoints : MonoBehaviour {

	private GameObject _start;

	private SpawnObj _spawnObj;

	private GameObject _currentCheckPoint;

	private Rigidbody rb;

	void Start () {
		_start = GameObject.Find("Start");
		rb = GetComponent<Rigidbody> ();
		goToLastCheckpoint(_start);
	}

	void OnCollisionEnter(Collision obj) {
		if (obj.gameObject.tag == "CheckPoint") {
			_currentCheckPoint = obj.gameObject;
		}
	}

	public void Died(){
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		goToLastCheckpoint(_currentCheckPoint);
	}

    public void goToLastCheckpoint(GameObject checkpoint)
    {
		this.transform.position = new Vector3(checkpoint.transform.position.x, checkpoint.transform.position.y + 2, checkpoint.transform.position.z);
    }
}
