using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI : MonoBehaviour {

    private GameObject timerImage;
    private Text timerText;

    private GameObject deadImage;
    private Text deadText;

    private float _theTime;
    private int _deaths;

    void Awake()
    {
        timerImage = GameObject.Find("Timer");
        timerText = timerImage.GetComponent<Text>();

        deadImage = GameObject.Find("DeathCounter");
        deadText = deadImage.GetComponent<Text>();
    }

    void Update()
    {
        _theTime += Time.deltaTime;
        timerText.text = "Time: " + _theTime;
    }

    public int Deaths
    {
        get { return _deaths; }
        set { _deaths = value;
            deadText.text = "Deaths: " + _deaths;
        }
    }
}
