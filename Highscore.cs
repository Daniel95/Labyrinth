using UnityEngine;
using System.Collections;

public class Highscore : MonoBehaviour {
	
	private string _name = "Geert gordijn";
	
	private int _highScore = 10;
	
	void Start () {
		WriteScore ();
		ReadScore ();
	}
	
	public void WriteScore(){
		string url = "http://14411.hosts.ma-cloud.nl/labyrinth/write.php";
		
		WWWForm form = new WWWForm();
		
		form.AddField("name", _name);
		form.AddField("score", " " + _highScore);
		
		WWW www = new WWW(url, form);
		
		StartCoroutine (WaitForRequest1 (www));
	}
	
	public void ReadScore(){
		string url = "http://14411.hosts.ma-cloud.nl/labyrinth/read.php";
		
		WWW www = new WWW(url);
		
		StartCoroutine (WaitForRequest2 (www));
	}
	
	IEnumerator WaitForRequest1(WWW www){
		yield return www;
		
		if(www.error == null){
			Debug.Log("WWW OK: " + www.text);
		}else {
			Debug.Log ("WWW False");
		}
	}
	
	IEnumerator WaitForRequest2(WWW www){
		yield return www;
		
		ParseString (www.text);
		
		if(www.error == null){
			Debug.Log("WWW OK: " + www.text);
		}else {
			Debug.Log ("WWW False");
		}
	}
	
	void ParseString(string incText){
		
		string[] myStr = incText.Split('\n');
		
		foreach(string text in myStr) {
			Debug.Log(text);
		}
	}
}