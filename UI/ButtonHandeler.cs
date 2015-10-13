using UnityEngine;
using System.Collections;

public class ButtonHandeler : MonoBehaviour {
	
	public void loadLevel(int levelNumber)
	{
		Application.LoadLevel(levelNumber);
	}
	public void Quit()
	{
		Application.Quit ();
	}
}
