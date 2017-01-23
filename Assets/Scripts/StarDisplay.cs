using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {
	
	public enum StatusUpdate {SUCCESS, FAILURE};
	
	private Text starText;
	private int stars = 1000;

	void Start () {
		starText = GetComponent<Text>();
		UpdateDisplay();
	}
	
	public void AddStars (int amount) {
		stars += amount;
		UpdateDisplay();
	}
	
	public StatusUpdate UseStars (int amount) {
		if (stars >= amount) {
			stars -= amount;
			UpdateDisplay();
			return StatusUpdate.SUCCESS;
		}
		return StatusUpdate.FAILURE;
	}
	
	private void UpdateDisplay () {
		starText.text = stars.ToString();
	}
}
