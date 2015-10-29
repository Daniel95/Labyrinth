using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    private Text _timerText;
	private Text _myDeathText;
    private Text _CauseDeathText;
	private Text _totalDeathText;
    private Text _nameField;
    private Text _scoreField;
    private GameObject _highscorePanels;
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
        _nameField = GameObject.Find("nameField").GetComponent<Text>();
        _scoreField = GameObject.Find("scoreField").GetComponent<Text>();
        _highscorePanels = GameObject.Find("_highscore");
        _highscorePanels.SetActive(false);
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

    /*public void MakeScoreBoard(string score) {
        string[] myStr = score.Trim().Split('\n');
        Debug.Log(score);
        GameObject temp = GameObject.Find("UI");
        Destroy(temp);
        _highscorePanels.SetActive(true);
        
		foreach(string text in myStr) {
			string[] myStr2 = text.Split('_');
            _nameField.text += myStr2[1] + "\n";
            Debug.Log(myStr2[1]);
            string[] myStr3 = myStr2[0].Split(' ');
            var min = myStr3[0];
            var sec = myStr3[1];
            var frac = myStr3[2];
            var time = string.Format("{0:00}:{1:00}:{2:00}", min, sec, frac);
            _scoreField.text +=time + "\n";
            Debug.Log(time);
        }
	}*/
    public void MakeScoreBoard(string score)
    {
        _counting = false;

        string[] myStr = score.Trim().Split('\n');
        GameObject temp = GameObject.Find("UI");
        Destroy(temp);
        _highscorePanels.SetActive(true);

        foreach (string text in myStr)
        {
            string[] myStr2 = text.Split('_');
            Debug.Log(myStr2[1]);
            _nameField.text += myStr2[1] + "\n";
            int stringCounter = 1;

            List<char> min = new List<char>();
            List<char> sec = new List<char>();
            List<char> frac = new List<char>();

            foreach (char character in myStr2[0])
            {
                if (stringCounter < 3) min.Add(character);
                else if (stringCounter < 5) sec.Add(character);//sec
                else frac.Add(character);//frac
                stringCounter++;

            }

            //min = min.ToString();
            string minStr = new string(min.ToArray());
            string secStr = new string(sec.ToArray());
            string fracStr = new string(frac.ToArray());
            var time = string.Format("{0:00}:{1:00}:{2:00}", minStr, secStr, fracStr);
            _scoreField.text += time + "\n";
            Debug.Log(time);
        }
    }
    public void MakeDeathScreen(string cause){
		Debug.Log (cause);
		_myDeaths += 1;
		_myDeathText.text = "My Deaths: " + _myDeaths;
        _highScore.Deaths();

        StartCoroutine(DeathScreenCause());
        _CauseDeathText.text = cause + ". But don't worry, in total "; 
	}

    IEnumerator DeathScreenCause()
    {
        yield return new WaitForSeconds(6);
        _CauseDeathText.text = "";
    }

	public void TotalDeaths(string deaths){
		_totalDeaths = deaths;
		_totalDeathText.text = "All Deaths: " + _totalDeaths;
        _CauseDeathText.text += _totalDeaths + " times people have died in this game.";
    }

	public bool SetCounting {
		set { _counting = value; }
	}

    public void OnEnable() {
        _theTime = 0;
        _myDeaths = 0;
        _myDeathText.text = "My Deaths: " + 0;
    }

    public bool Counting
    {
        get { return _counting; }
        set { _counting = value; }
    }
}
