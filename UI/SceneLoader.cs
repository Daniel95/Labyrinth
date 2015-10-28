using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {
    
    public void loadNewScene(string scene)
    {
        Application.LoadLevel(scene);
    }

    public void loadNextScene()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
