using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public float timeFade;
	
	private Image panelFading;
	private Color startColor = Color.black;

	void Start () {
		panelFading = GetComponent<Image>();
	}
	
	void Update () {
		if(Time.timeSinceLevelLoad < timeFade) {
			float alphaChange = Time.deltaTime / timeFade;
			startColor.a -= alphaChange;
			panelFading.color = startColor;
		} else {
			gameObject.SetActive(false);
		}
	}
}
