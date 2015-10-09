using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	[SerializeField]
	private Vector3 distance;		

	[SerializeField]
	private Transform player;
	
	void Update ()
	{
		// Set the position to the player's position with the offset.
		if(player != null)this.transform.position = player.position + distance;
	}
}