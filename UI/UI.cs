using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

	//private GameObject _timerImage;
    private Text _timerText;

	//private GameObject _deadImage;
	private Text _deadText;

	private Highscore _highScore;

    private float _theTime;
	private bool _counting = true;

    private int _myDeaths;
	private int _totalDeaths;
	private string _cause;

    void Awake()
    {
		_highScore = GetComponent<Highscore> ();

		//_timerImage = GameObject.Find("Timer");
		_timerText = GameObject.Find("Timer").GetComponent<Text>();

		//_deadImage = GameObject.Find("DeathCounter");
		_deadText = GameObject.Find("DeathCounter").GetComponent<Text>();
    }

    void Update()
    {
		if(_counting)_theTime += Time.deltaTime;
		_timerText.text = "Time: " + (int)_theTime;
    }

	public void Finished() {
		int lvl = Application.loadedLevel;
		_highScore.Score(_theTime, lvl);
		//_highScore.ReadScore(lvl);
		//NextLvl(lvl);
	}

	private void NextLvl(int lvl){
		if(lvl != Application.levelCount - 1) Application.LoadLevel(lvl + 1);
	}

	public void MakeScoreBoard(string score) {
		Debug.Log (score);
		string[] myStr = score.Split('\n');
		foreach(string text in myStr) {
			string[] myStr2 = text.Split('_');
			foreach(string text2 in myStr2) {
				//if(text2 != "" && text2 != "\n" && text2 != "\n " && text2 != " ") Debug.Log(text2);
				if(text2 != "")Debug.Log(text2);
				
			}
		}
	}

	public void MakeDeathScreen(string cause){
		//Debug.Log (cause);
		_myDeaths += 1;

		_highScore.Deaths();
	}

	public void TotalDeaths(string deaths){
		Debug.Log (deaths);
		//_totalDeaths = (int)deaths;
	}
}
