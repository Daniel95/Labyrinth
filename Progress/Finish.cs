using UnityEngine;
using System.Collections;

public class Finish : MonoBehaviour {

	private UI ui;

	private bool finished;

    private AudioSource _finishSound;

	void Awake()
	{
        _finishSound = (AudioSource)gameObject.AddComponent<AudioSource>();
        _finishSound.clip = (AudioClip)Resources.Load("Audio/finish");
        finished = false;
        if (GameObject.Find("Canvas") != null)
        {
            ui = GameObject.Find("Canvas").GetComponent<UI>();
        }
	}
	
	// Use this for initialization
	void OnCollisionEnter(Collision obj) {
		if (obj.gameObject.tag == "Player") {
			if(!finished) {
				ui.Finished();
				finished = true;
                _finishSound.Play();
			}
		}
	}
}
