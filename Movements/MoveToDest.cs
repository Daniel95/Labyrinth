using UnityEngine;
using System.Collections;

public class MoveToDest : MonoBehaviour 
{
	[SerializeField]
	private float speed;
	[SerializeField]
	private bool delay;
	[SerializeField]
	private Transform endSpot;
	[SerializeField]
	private Transform originSpot;
	[SerializeField]
	private bool _automatic;
	[SerializeField]
	private bool _controllable;
	
	private Transform _destination;
	private bool _activated;

    //private AudioSource _activateSound;

	void Start(){
		_destination = originSpot;
		_activated = true;
    }

    void Awake() {
        //_activateSound = (AudioSource)gameObject.AddComponent<AudioSource>();
        //_activateSound.clip = (AudioClip)Resources.Load("Audio/switch");
        //_activateSound.volume = 0.3f;
    }

	void Update()
	{
		if (_activated) {
			var move = GoToDest (transform.position, new Vector3());
			transform.position = move;
		}
	}
	
	void OnEnable()
	{
		if(_controllable) KeyboardInput.MoveObjects += SetActive;
	}
	
	void OnDiable()
	{
		if(_controllable) KeyboardInput.MoveObjects -= SetActive;
	}

	public Vector3 GoToDest(Vector3 currentPos, Vector3 distance) {
		var pos = Vector3.MoveTowards(currentPos, _destination.position + distance, speed / 10);
		if (pos == _destination.position) {
			_activated = false;
			if(_automatic) SetActive();
		}
		return pos;
	}
	
	public void SetActive()
    {
       // if (!_automatic) _activateSound.Play();
        _activated = true;
		if(_destination == originSpot) _destination = endSpot;
		else _destination = originSpot;
	}

	public bool checkActive {
		get {return _activated; }
	}

    public void SetDest(bool backToOrigin) {
        if (backToOrigin) _destination = originSpot;
        else _destination = endSpot;
    }
}