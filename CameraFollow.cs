using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	[SerializeField]
	private Vector3 distance;		

	private Transform _player;
	
	
	void Start ()
	{
		// Setting up the reference.
		_player = GameObject.FindGameObjectWithTag("Player").transform;
		
	}
	
	void Update ()
	{
		// Set the position to the player's position with the offset.
		if(_player != null)this.transform.position = _player.position + distance;
	}
}