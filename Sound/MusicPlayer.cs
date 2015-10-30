using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    [SerializeField]
    private string music;

    private AudioSource _music;

	// Use this for initialization
	void Start () {
        _music = (AudioSource)gameObject.AddComponent<AudioSource>();

        //choosing random or selected background music
        if (music != "") _music.clip = LoadSound("music" + music);
        else _music.clip = LoadSound("music"+ Random.Range(1, 4));
        //playing the music
        PlayMusic(_music);
    }

    private AudioClip LoadSound(string fileName) {
        AudioClip clip = (AudioClip)Resources.Load("Audio/" + fileName);
        return clip;
    }


    private void PlayMusic(AudioSource sound)
    {
        sound.loop = true;
        sound.Play();
    }

    private void StopMusic(AudioSource sound)
    {
        sound.Stop();
    }
}
