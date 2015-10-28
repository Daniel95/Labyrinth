using UnityEngine;
using System.Collections;

public class CheckPoints : MonoBehaviour {

	private GameObject _start;

	private Transform _cinematicPoint;

	private SpawnObj _spawnObj;

	private GameObject _currentCheckPoint;

	private Rigidbody _rb;

	private UI ui;

	void Start () {
		_rb = GetComponent<Rigidbody> ();
		_start = GameObject.Find("Start");
		//var canvas = GameObject.Find("Canvas");
		//ui = canvas.get
        if (GameObject.Find("Canvas") != null)
        {
            ui = GameObject.Find("Canvas").GetComponent<UI>();
        }
		
        _currentCheckPoint = _start;
		goToLastCheckpoint(_start);

        _cinematicPoint = _start.GetComponent<NextPoint>().newPos;
        GameObject.Find("Main Camera").GetComponent<StartCinematic>().newVals(_cinematicPoint);
	}

	void OnCollisionEnter(Collision obj) {

		if (obj.gameObject.tag == "CheckPoint" && obj.gameObject.name != "Start") {
			_currentCheckPoint = obj.gameObject;

			_cinematicPoint = obj.gameObject.GetComponent<NextPoint>().newPos;
            if (obj.gameObject.GetComponent<NextPoint>().Done == false)
            {
                GameObject.Find("Main Camera").GetComponent<StartCinematic>().newVals(_cinematicPoint);
                obj.gameObject.GetComponent<NextPoint>().Done = true;
            }
		}
	}

	public void Dead(string cause){
		ui.MakeDeathScreen (cause);

		_rb.velocity = _rb.angularVelocity = Vector3.zero;
		goToLastCheckpoint(_currentCheckPoint);
	}

    private void goToLastCheckpoint(GameObject checkpoint)
    {
		this.transform.position = new Vector3(checkpoint.transform.position.x, checkpoint.transform.position.y + 2, checkpoint.transform.position.z);
    }
}
