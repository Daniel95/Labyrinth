using UnityEngine;
using System.Collections;

public class KeyboardInput : MonoBehaviour {
	private MoveWorld mWorld;
	private PlayerMovement mPlayer;
    private StartCinematic sCinematic;
	
	public delegate void Action();
	public static event Action MoveObjects;
	
	void Awake()
	{
		mWorld = GetComponent<MoveWorld>();
		mPlayer = GameObject.Find("Player").GetComponent<PlayerMovement>();
        sCinematic = GameObject.Find("Main Camera").GetComponent<StartCinematic>();
	}
	
	void Update()
	{
		getInputs(); 
	}
	
	void getInputs()
	{
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) { mWorld.setForward = true; mPlayer.goMove(1); }
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) { mWorld.setBackward = true; mPlayer.goMove(2); }
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) { mWorld.setLeft = true; mPlayer.goMove(3); }
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) { mWorld.setRight = true; mPlayer.goMove(4); }
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (MoveObjects != null) MoveObjects();
            sCinematic.Skip = true;


		}
		
		if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) { mWorld.setForward = false; }
		if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)) { mWorld.setBackward = false; }
		if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) { mWorld.setLeft = false; }
		if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) { mWorld.setRight = false; }
	}
	
}