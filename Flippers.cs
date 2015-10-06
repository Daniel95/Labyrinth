using UnityEngine;
using System.Collections;

public class Flippers : MonoBehaviour {
	private float rotations = 0;
    public float speed = 1f;
    [SerializeField]
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
			if (rotations < 90) {
				transform.Rotate (Vector3.up * speed);
				rotations += speed;

			} else {
				open = false;
			}
		} 
		else 
		{
			if (rotations >0) {
				transform.Rotate (Vector3.up * -speed);
				rotations -= speed;
			}
		}
	}

}
