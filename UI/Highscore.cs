using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour {
	
	private string _name = "daniel";
	
	private int _highScore = 999999;

	private int _totalPlays;

	private int _totalDeads = 2;

	void Start () {
		WriteScore ();
		//ReadScore ();
	}
	
	public void WriteScore(){
		string url = "http://14411.hosts.ma-cloud.nl/labyrinth/write.php";
		
		WWWForm form = new WWWForm();

		form.AddField("name", _name);
		form.AddField("score", " " + _highScore);
		
		WWW www = new WWW(url, form);
		
		StartCoroutine (WaitForRequest (www, false));
	}
	
	public void ReadScore(){
		string url = "http://14411.hosts.ma-cloud.nl/labyrinth/read.php";
		
		WWW www = new WWW(url);
		
		StartCoroutine (WaitForRequest (www, true));
	}
	
	IEnumerator WaitForRequest(WWW www, bool parse){
		yield return www;

		if(parse) ParseString (www.text);
		//Debug.Log (www.text [0]);

		if(www.error == null){
			//Debug.Log("WWW OK: " + www.text);
		}else {
			//Debug.Log ("WWW False");
		}
	}
	
	void ParseString(string incText){
		
		string[] myStr = incText.Split('\n');
		
		foreach(string text in myStr) {
			Debug.Log(text);
			//here we can put each line that we read into a UI element
			_totalPlays++;

		}
		Debug.Log (_totalPlays - 1 + " Times Played");

	}

	void FindAndReplaceText(){
	}
}