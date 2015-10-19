using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour {
	
	private string _name = "Jvik";
	
	private int _highScore =  0000;

	//private int _totalDeads = 2;

	void Start () {
		WriteScore (_highScore);
		ReadScore ();
	}
	
	public void WriteScore(int score){
		string url = "http://14411.hosts.ma-cloud.nl/labyrinth/write.php";
		
		WWWForm form = new WWWForm();

		form.AddField("score", score);
		form.AddField("name", " " + _name);
		
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
		Debug.Log (incText);
		string[] myStr = incText.Split('\n');
		foreach(string text in myStr) {
			string[] myStr2 = text.Split(' ');
			foreach(string text2 in myStr2) {
				//Debug.Log(text2.Trim());
			}
		}
	}

	void FindAndReplaceText(){

	}
}