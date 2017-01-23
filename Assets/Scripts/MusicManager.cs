using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusic;
	
	private AudioSource audSource;
	
	void Awake() {
		DontDestroyOnLoad(gameObject);
	}
	
	void Start() {
		audSource = GetComponent<AudioSource>();
	}
	
	void OnLevelWasLoaded(int level) {
		AudioClip thisLevel = levelMusic[level];
		
		if(thisLevel) {
			audSource.volume = PrefsManager.GetMasterVolume();
			audSource.clip = thisLevel;
			audSource.loop = true;
			audSource.Play();
		} else {
			Debug.Log ("Not thisLevel");
		}
	}
	
	public void ChangeVolume (float volume) {
		audSource.volume = volume;
	}
}
