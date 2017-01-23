using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour {

	public Slider volSlider, diffSlider;
	public LevelManager levelManager;
	
	private MusicManager musicManager;

	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		diffSlider.value = PrefsManager.GetDifficulty();
		volSlider.value = PrefsManager.GetMasterVolume();
	}
	
	void Update () {
		musicManager.ChangeVolume(volSlider.value);
	}
	
	public void SaveOptions() {
		PrefsManager.SetMasterVolume(volSlider.value);
		PrefsManager.Difficulty(diffSlider.value);
		levelManager.LoadLevel("Start");
	}
	
	public void SetDefaults() {
		volSlider.value = 0.7f;
		diffSlider.value = 1f;
	}
}
