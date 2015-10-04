using UnityEngine;
using System.Collections;

public class CheckPoints : MonoBehaviour {

	private GameObject _start;

	private SpawnObj _spawnObj;

	private GameObject _currentCheckPoint;

	private Rigidbody _rb;

	void Start () {
		_start = GameObject.Find("Start");
		_rb = GetComponent<Rigidbody> ();
		goToLastCheckpoint(_start);
	}

	void OnCollisionEnter(Collision obj) {
		if (obj.gameObject.tag == "CheckPoint") {
			_currentCheckPoint = obj.gameObject;
		}
	}

	public void Died(string cause){
		Debug.Log (cause);

		_rb.velocity = _rb.angularVelocity = Vector3.zero;
		goToLastCheckpoint(_currentCheckPoint);
	}

    private void goToLastCheckpoint(GameObject checkpoint)
    {
		Debug.Log (checkpoint);
		this.transform.position = new Vector3(checkpoint.transform.position.x, checkpoint.transform.position.y + 2, checkpoint.transform.position.z);
    }
}
