using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {
	//[SerializeField]
	//private int _levelNumber;

	private UI ui;

	//private int lvl;

	private bool finished;

	void Awake()
	{
		finished = false;
		ui = GameObject.Find("Canvas").GetComponent<UI>();
	}
	
	// Use this for initialization
	void OnCollisionEnter(Collision obj) {
		if (obj.gameObject.tag == "Player") {
			if(!finished) {
				ui.Finished();
				finished = true;
			}
		}
	}
}
