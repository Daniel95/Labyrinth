using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetPlayerName : MonoBehaviour {

    [SerializeField]
    private Button button;

    private SavePlayerName _save;

    void Start()
    {
        _save = GameObject.Find("plrName").GetComponent<SavePlayerName>();
        button.interactable = false;
        var input = gameObject.GetComponent<InputField>();
        input.onEndEdit.AddListener(SubmitName);
    }

    private void SubmitName(string input)
    {
        if (input.Length > 2 && input.Length < 20)
        {
            _save.PlayerName = input;
            button.interactable = true;
        }
        else {
            button.interactable = false;
        }
    }

    public void nextScene() {
        Application.LoadLevel(1);
    }
}