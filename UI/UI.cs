using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    private Text _timerText;
	private Text _myDeathText;
    private Text _CauseDeathText;
	private Text _totalDeathText;

	private Highscore _highScore;

    private float _theTime;
	private bool _counting = true;

    private int _myDeaths;
	private string _totalDeaths;
	private string _cause;

    private float fraction;
    private float seconds;
    private float minutes;

    void Awake()
    {
        _highScore = GetComponent<Highscore>();
        _timerText = GameObject.Find("Timer").GetComponent<Text>();
        _myDeathText = GameObject.Find("MyDeathCounter").GetComponent<Text>();
        _totalDeathText = GameObject.Find("TotalDeathCounter").GetComponent<Text>();
        _CauseDeathText = GameObject.Find("CauseDeathText").GetComponent<Text>();
    }

    void Start()
    {
        _myDeathText.text = "My Deaths: " + 0;
        _totalDeathText.text = "All Deaths: " + _totalDeaths;
    }

    void Update()
    {
		if (_counting) {
            _theTime += Time.deltaTime;

            minutes = _theTime / 60;
            seconds = _theTime % 60;
            fraction = (_theTime * 100) % 100;

            _timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);

        }
    }

	public void Finished() {
		int lvl = Application.loadedLevel;
		_highScore.Score((int)minutes,(int)seconds,(int)fraction, lvl);
		//NextLvl(lvl);
	}

	public void NextLvl(int lvl){
		if(lvl != Application.levelCount - 1) Application.LoadLevel(lvl + 1);
	}

	public void MakeScoreBoard(string score) {
        string[] myStr = score.Trim().Split('\n');
        Debug.Log(score);
		foreach(string text in myStr) {
			string[] myStr2 = text.Split('_');
            Debug.Log(myStr2[1]);
            Debug.Log(myStr2[1]);
            string[] myStr3 = myStr2[0].Split(' ');
            var min = myStr3[0];
            var sec = myStr3[1];
            var frac = myStr3[2];
            var time = string.Format("{0:00}:{1:00}:{2:00}", min, sec, frac);
            Debug.Log(time);
        }
	}

	public void MakeDeathScreen(string cause){
		Debug.Log (cause);
		_myDeaths += 1;
		_myDeathText.text = "My Deaths: " + _myDeaths;
        _highScore.Deaths();

        StartCoroutine(DeathScreenCause());
        _CauseDeathText.text = cause + ". But don't worry, in total " + _totalDeaths + " times people have died in this game.";
	}

    IEnumerator DeathScreenCause()
    {
        yield return new WaitForSeconds(6);
        _CauseDeathText.text = "";
    }

	public void TotalDeaths(string deaths){
		_totalDeaths = deaths;
		_totalDeathText.text = "All Deaths: " + _totalDeaths;
	}

	public bool SetCounting {
		set { _counting = value; }
	}

    public void OnEnable() {
        _theTime = 0;
        _myDeaths = 0;
        _myDeathText.text = "My Deaths: " + 0;
    }

}
