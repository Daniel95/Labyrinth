using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour {
	
	private string _name = "Daniel";

	private bool _loading;

	private UI _ui;

	void Start() {
		_ui = GetComponent<UI> ();
	}

	public void Score(int minutes, int seconds, int fration, int lvl){
		string url = "http://14411.hosts.ma-cloud.nl/labyrinth/score.php";

		WWWForm form = new WWWForm();
		form.AddField("lvl", lvl);
		form.AddField("minutes", minutes);
        form.AddField("seconds", seconds);
        form.AddField("fraction", fration);
        form.AddField("name", _name);
		
		WWW www = new WWW(url, form);

		//if done loading, send text from file to UI
		StartCoroutine (WaitForRequest (www, true));
	}

	public void Deaths(){
		string url = "http://14411.hosts.ma-cloud.nl/labyrinth/deaths.php";
		
		WWW www = new WWW(url);

		//if done loading, send text from file to UI
		StartCoroutine (WaitForRequest (www, false));
	}
	
	IEnumerator WaitForRequest(WWW www, bool scoreUI){
		yield return www;

		if(scoreUI) _ui.MakeScoreBoard(www.text);
		else _ui.TotalDeaths(www.text);
	}

	public string SetName
	{
		set { _name = value; }
	}
}