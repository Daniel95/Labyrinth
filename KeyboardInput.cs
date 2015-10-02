using UnityEngine;
using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour {
	private MoveWorld mWorld;
	private PlayerMovement mPlayer;
	
	public delegate void Action();
	public static event Action MoveObjects;
	
	void Awake()
	{
		mWorld = GetComponent<MoveWorld>();
		mPlayer = GameObject.Find("Player").GetComponent<PlayerMovement>();
	}
	
	void Update()
	{
		getInputs(); 
	}
	
	void getInputs()
	{
		if (Input.GetKeyDown(KeyCode.W)) { mWorld.setForward = true; mPlayer.goMove(1); }
		else if (Input.GetKeyDown(KeyCode.S)) { mWorld.setBackward = true; mPlayer.goMove(2); }
		if (Input.GetKeyDown(KeyCode.A)) { mWorld.setLeft = true; mPlayer.goMove(3); }
		else if (Input.GetKeyDown(KeyCode.D)) { mWorld.setRight = true; mPlayer.goMove(4); }
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (MoveObjects != null) MoveObjects();
		}
		
		if (Input.GetKeyUp(KeyCode.W)) { mWorld.setForward = false; }
		else if (Input.GetKeyUp(KeyCode.S)) { mWorld.setBackward = false; }
		if (Input.GetKeyUp(KeyCode.A)) { mWorld.setLeft = false; }
		if (Input.GetKeyUp(KeyCode.D)) { mWorld.setRight = false; }
	}
	
}