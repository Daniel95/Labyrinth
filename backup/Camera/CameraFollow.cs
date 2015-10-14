using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	[SerializeField]
	private Vector3 distance;
    [SerializeField]
    private int rotation;
	[SerializeField]
	private Transform player;
    [SerializeField]
    private Transform playerCamPos;
    

    //private bool followPlayer = true;

    void Awake()
    {
		this.transform.eulerAngles = Vector3.right * rotation;
    }

    void Update()
    {
        // Set the position to the player's position with the offset.
        if (player != null) this.transform.position = player.position + distance;
    }

    public Transform PlayerCam
    {
        get { 
			playerCamPos.position = player.position + distance;
			playerCamPos.eulerAngles = Vector3.right * (rotation + 10);
			return playerCamPos;
        }
		set { playerCamPos = value; }
    }
}