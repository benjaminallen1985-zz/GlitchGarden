using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public float levelSeconds = 100;
	
	private Slider slide;
	private AudioSource audSource;
	private bool endOfLevel;
	private LevelManager levelManager;
	private GameObject winLabel;
	
	void Start () {
		slide = GetComponent<Slider>();
		audSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		FindYouWin ();
		winLabel.SetActive(false);
	}

	void FindYouWin ()
	{
		winLabel = GameObject.Find ("You Win");
		if (!winLabel) {
			Debug.LogWarning ("You win object missing");
		}
	}
	
	void Update () {
		slide.value = Time.timeSinceLevelLoad / levelSeconds;
		
		bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
		if(timeIsUp && !endOfLevel) {
			audSource.Play();
			winLabel.SetActive(true);
			Invoke ("LoadNextLevel", audSource.clip.length);
			endOfLevel = true;
		}
	}
	
	void LoadNextLevel () {
		levelManager.LoadNextLevel();
	}
}