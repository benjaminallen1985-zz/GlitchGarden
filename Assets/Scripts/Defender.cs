using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

	public int starCost = 100;
	
	private StarDisplay displayStar;

	void Start() {
		displayStar = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	public void AddStars (int amount) {
		displayStar.AddStars(amount);
	}
}