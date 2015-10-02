using UnityEngine;
using System.Collections;

public class StartManager : MonoBehaviour {
    private GameObject start;

	void Start () {
        start = GameObject.Find("Start");

        goToStart();
	}

    public void goToStart()
    {
        this.transform.position = new Vector3(start.transform.position.x, start.transform.position.y + 2, start.transform.position.z);
    }
}
