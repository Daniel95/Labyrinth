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
	[SerializeField]
	private bool _automatic;
	
	private Transform _destination;
	private bool _activated;
	private bool _onCommand;

	void Start(){
		_destination = originSpot;
	}

	void Update()
	{
        //checked als het object activeerd, dan verplaatst naar de endspot.
		if (_activated) {
			var move = GoToDest (transform.position);
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

	public Vector3 GoToDest(Vector3 currentPos) {
		var pos = Vector3.MoveTowards(currentPos, _destination.position, speed / 10);
		if (pos == _destination.position) {
			_activated = false;
			if(_automatic) SetActive();
		}
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