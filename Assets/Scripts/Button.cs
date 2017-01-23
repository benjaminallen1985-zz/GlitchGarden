using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject prefabDefender;
	public static GameObject thisDefender;

	private Button[] buttonArr;
	private Text textCost;

	void Start () {
		buttonArr = GameObject.FindObjectsOfType<Button>();
		
		textCost = GetComponentInChildren<Text>();
		if(!textCost) {
			Debug.LogWarning(name + " has no child text object");
		}
		
		textCost.text = prefabDefender.GetComponent<Defender>().starCost.ToString();
	}
	
	void Update () {
	
	}
	
	void OnMouseDown() {
		foreach (Button thisButton in buttonArr) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		
		GetComponent<SpriteRenderer>().color = Color.white;
		thisDefender = prefabDefender;
	}
}
