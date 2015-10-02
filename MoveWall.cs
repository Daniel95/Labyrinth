using UnityEngine;
using UnityEngine;
using System.Collections;

public class MoveWall : MonoBehaviour 
{
	[SerializeField]
	private Transform _destinationSpot;
	[SerializeField]
	private Transform _originSpot;
	[SerializeField]
	private float _speed;
	private bool Switch;
	
	void Update()
	{
		if (Switch) ToDestination();
		else if (!Switch) ToOrigin();
	}
	
	void OnEnable()
	{
		KeyboardInput.MoveObjects += SetSwitch;
	}
	
	void OnDiable()
	{
		KeyboardInput.MoveObjects -= SetSwitch;
	}
	
	void ToDestination()
	{
		transform.position = Vector3.MoveTowards(transform.position, _destinationSpot.position, _speed);
	}
	
	void ToOrigin()
	{
		transform.position = Vector3.MoveTowards(transform.position, _originSpot.position, _speed);
	}
	
	void SetSwitch()
	{
		Switch = !Switch;
	}
}