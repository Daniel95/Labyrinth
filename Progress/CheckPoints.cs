using UnityEngine;
using System.Collections;

public class CheckPoints : MonoBehaviour {

	private GameObject _start;

	[SerializeField]
	private Transform _cinematicPoint;

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

			_cinematicPoint = obj.gameObject.GetComponent<NextPoint>().newPos;
			GameObject.Find("Main Camera").GetComponent<StartCinematic>().newVals(_cinematicPoint);
		}
	}

	public void Died(string cause){
		Debug.Log (cause);

		_rb.velocity = _rb.angularVelocity = Vector3.zero;
		goToLastCheckpoint(_currentCheckPoint);
	}

    private void goToLastCheckpoint(GameObject checkpoint)
    {
		this.transform.position = new Vector3(checkpoint.transform.position.x, checkpoint.transform.position.y + 2, checkpoint.transform.position.z);
    }
}
