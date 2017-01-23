using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

	private MusicManager musicMan;

	void Start () {
		musicMan = GameObject.FindObjectOfType<MusicManager>();
		if(musicMan) {
			float volume = PrefsManager.GetMasterVolume();
			musicMan.ChangeVolume(volume);
		} else {
			Debug.LogWarning("Music Manager not found. Can't set volume.");
		}
	}
	
	void Update () {
	
	}
}
