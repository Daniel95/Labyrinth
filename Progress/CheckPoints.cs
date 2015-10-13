using UnityEngine;
using System.Collections;

public class CheckPoints : MonoBehaviour {

	private GameObject _start;

    [SerializeField]
    private GameObject CinematicPoint;

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
            GameObject.Find("Main Camera").GetComponent<StartCinematic>().newVals(CinematicPoint.transform);

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
