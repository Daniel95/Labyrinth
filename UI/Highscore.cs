using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour {

	private bool _loading;

	private UI _ui;

    private string _plrName = "Anonymous";

	void Start() {
		_ui = GetComponent<UI> ();
	}

	public void Score(int minutes, int seconds, int fraction, int lvl){
		string url = "http://14411.hosts.ma-cloud.nl/labyrinth/score.php";

        if (GameObject.Find("plrName") != null) _plrName = GameObject.Find("plrName").GetComponent<SavePlayerName>().PlayerName;

        var minutesSTR = string.Format("{0:00}", minutes);
        var secondsSTR = string.Format("{0:00}", seconds);
        var fractionSTR = string.Format("{0:00}", fraction);

        WWWForm form = new WWWForm();
		form.AddField("lvl", lvl);
		form.AddField("minutes", minutesSTR);
        form.AddField("seconds", secondsSTR);
        form.AddField("fraction", fractionSTR);
        form.AddField("name", _plrName);
		
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
}