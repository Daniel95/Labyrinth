using UnityEngine;
using System.Collections;

public class SavePlayerName : MonoBehaviour {

    private string _playerName;

    public string PlayerName
    {
        get { return _playerName; }
        set { _playerName = value; } 
    }
}
