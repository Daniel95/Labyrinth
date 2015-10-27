using UnityEngine;
using System.Collections;

public class ButtonHandeler : MonoBehaviour {
    private UI UI;
    private GameObject StartButtons;

    void Awake()
    {
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        StartButtons = GameObject.Find("StartButtons");
        UI = GameObject.Find("Canvas").GetComponent<UI>();
        if (StartButtons.active == false) StartButtons.active = true;
    }

	public void loadLevel(int levelNumber)
	{
        UI.NextLvl(levelNumber);
        if (StartButtons.active == true) StartButtons.active = false;
	}

	public void Quit()
	{
		Application.Quit ();
	}
}
