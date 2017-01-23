using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCam;
	
	private GameObject theParent;
	private StarDisplay diplayStar;
	
	void Start () {
		theParent = GameObject.Find ("Defenders");
		diplayStar = GameObject.FindObjectOfType<StarDisplay>();
		
		if (!theParent) {
			theParent = new GameObject("Defenders");
		}
	}
	
	void OnMouseDown () {
		Vector2 rawPosition = CalculateWorldPointOfMouseClick();
		Vector2 roundedPosition = SnapToGrid (rawPosition);
		GameObject thisDefender = Button.thisDefender;
		
		int defCost = thisDefender.GetComponent<Defender>().starCost;
		if (diplayStar.UseStars(defCost) == StarDisplay.StatusUpdate.SUCCESS) {
			SpawnDefender (roundedPosition, thisDefender);
		} else {
			Debug.Log ("Insufficient stars");
		}		
	}
	
	Vector2 SnapToGrid (Vector2 rawWorldPos) {
		float xPos = Mathf.RoundToInt (rawWorldPos.x);
		float yPos = Mathf.RoundToInt (rawWorldPos.y);		
		
		return new Vector2 (xPos, yPos);
	}
	
	Vector2 CalculateWorldPointOfMouseClick () {
		float xMouse = Input.mousePosition.x;
		float yMouse = Input.mousePosition.y;
		float camDistance = 10f;
		
		Vector3 triplet = new Vector3 (xMouse, yMouse, camDistance);
		Vector2 worldPosition = myCam.ScreenToWorldPoint (triplet);
		
		return worldPosition;
	}

	void SpawnDefender (Vector2 roundedPos, GameObject defender) {
		Quaternion noRotation = Quaternion.identity;
		GameObject newDefender = Instantiate (Button.thisDefender, roundedPos, noRotation) as GameObject;
		newDefender.transform.parent = theParent.transform;
	}
}
