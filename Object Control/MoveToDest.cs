using UnityEngine;
using System.Collections;

public class MoveToDest : MonoBehaviour 
{
	[SerializeField]
	private float speed;
	[SerializeField]
	private Transform endSpot;
	[SerializeField]
	private Transform originSpot;

	private Transform _destination;
	private bool _activated;

	void Start(){
		_destination = originSpot;
	}

	void Update()
	{
		if (_activated) {
			var move = GoTo (transform.position);
			transform.position = move;
		}
	}
	
	void OnEnable()
	{
		KeyboardInput.MoveObjects += SetActive;
	}
	
	void OnDiable()
	{
		KeyboardInput.MoveObjects -= SetActive;
	}

	public Vector3 GoTo(Vector3 currentPos) {
		var pos = Vector3.MoveTowards(currentPos, _destination.position, speed);
		if(pos == _destination.position) _activated = false;
		return pos;
	}
	
	void SetActive()
	{
		_activated = true;
		if(_destination == originSpot) _destination = endSpot;
		else _destination = originSpot;
	}

	public bool checkActive {
		get {return _activated; }
	}
}