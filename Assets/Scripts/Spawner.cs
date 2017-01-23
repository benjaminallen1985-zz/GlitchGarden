using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] prefabAttacker;
	
	void Update () {
		foreach (GameObject theAttacker in prefabAttacker) {
			if (isTimeToSpawn (theAttacker)) {
				Spawn (theAttacker);
			}
		}	
	}
	
	void Spawn (GameObject myGameObject) {
		GameObject thisAttacker = Instantiate (myGameObject) as GameObject;
		thisAttacker.transform.parent = transform;
		thisAttacker.transform.position = transform.position;
	}
	
	bool isTimeToSpawn (GameObject attackerGameObject) {
		Attacker attackGuy = attackerGameObject.GetComponent<Attacker>();
		
		float spawnDelay = attackGuy.spawnSeconds;
		float spawnsPerSecond = 1 / spawnDelay;
		
		if (Time.deltaTime > spawnDelay) {
			Debug.LogWarning("Spawn capped by framerate");
		}
		
		float threshold = spawnsPerSecond * Time.deltaTime / 5;
		
		return (Random.value < threshold);
	}
}
