using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    private Text _timerText;

	private Text _myDeathText;

	private Text _totalDeathText;

	private Highscore _highScore;

    private float _theTime;
	private bool _counting = true;

    private int _myDeaths;
	private string _totalDeaths;
	private string _cause;

    void Awake()
    {
		_highScore = GetComponent<Highscore> ();

		_timerText = GameObject.Find("Timer").GetComponent<Text>();

		_myDeathText = GameObject.Find("MyDeathCounter").GetComponent<Text>();

		_totalDeathText = GameObject.Find("TotalDeathCounter").GetComponent<Text>();

		_myDeathText.text = "My Deaths: " + 0;
		_totalDeathText.text = "All Deaths: " + _totalDeaths;
    }

    void Update()
    {
		if (_counting) {
			_theTime += Time.deltaTime;
			_timerText.text = "Time: " + (int)_theTime;
		}
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
		_myDeathText.text = "My Deaths: " + _myDeaths;
		_highScore.Deaths();
	}

	public void TotalDeaths(string deaths){
		_totalDeaths = deaths;
		_totalDeathText.text = "All Deaths: " + _totalDeaths;
		Debug.Log (_totalDeaths);
	}

	public bool SetCounting {
		set { _counting = value; }
	}
}
