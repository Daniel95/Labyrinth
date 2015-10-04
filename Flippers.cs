using UnityEngine;
using System.Collections;

public class Flippers : MonoBehaviour {
	private float rotitions = 0;
	private bool open = false;
	// Use this for initialization
	void Start () {
	
	}

	/*void OnEnable()
	{
		KeyboardInput.DoThings += Pressed ();
	}
	
	void OnDiable()
	{
		KeyboardInput.DoThings -= Pressed ();
	}*/
	void Pressed()
	{
		open = true;
	}
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			Pressed ();
		}
	

		if (open) {
			if (rotitions < 90) {
				transform.Rotate (Vector3.up * 10);
				rotitions += 10;

			} else {
				open = false;
			}
		} 
		else 
		{
			if (rotitions >0) {
				transform.Rotate (Vector3.up * -10);
				rotitions -= 10;
			}
		}
	}

}
