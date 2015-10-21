using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour {
	
	private string _name = "Jvik";
	
	//private int _totalDeads = 2;

	private bool _loading;

	private UI _ui;

	void Start() {
		_ui = GetComponent<UI> ();
	}

	public void Score(float time, int lvl){
		string url = "http://14411.hosts.ma-cloud.nl/labyrinth/score.php";
		
		WWWForm form = new WWWForm();
		//var score = time * 1000;
		form.AddField("lvl", lvl);
		form.AddField("score", (int)time);
		form.AddField("name", _name);
		
		WWW www = new WWW(url, form);

		//if done loading, send text from file to UI
		StartCoroutine (WaitForRequest (www, true));
	}

	public void Deaths(){
		string url = "http://14411.hosts.ma-cloud.nl/labyrinth/deaths.php";
		
		//WWWForm form = new WWWForm();
		//form.AddField("deaths", deaths);
		
		//WWW www = new WWW(url, form);
		WWW www = new WWW(url);

		//if done loading, send text from file to UI
		StartCoroutine (WaitForRequest (www, false));
	}

	/*
	public void ReadScore(int lvl){
		string url = "http://14411.hosts.ma-cloud.nl/labyrinth/score.php";

		WWWForm form = new WWWForm();
		form.AddField("lvl", lvl);

		WWW www = new WWW(url);

		StartCoroutine (WaitForRequest (www, true));
	}*/
	
	IEnumerator WaitForRequest(WWW www, bool scoreUI){
		yield return www;

		//Debug.Log("loading");
		if(scoreUI) _ui.MakeScoreBoard(www.text);
		else _ui.TotalDeaths(www.text);
	}

	public string SetName
	{
		set { _name = value; }
	}
}