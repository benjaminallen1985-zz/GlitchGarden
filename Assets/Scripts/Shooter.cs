using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject proj, weapon;
	
	private GameObject projParent;
	private Animator animator;
	private Spawner laneSpawner;
	
	void Start () {
		animator = GameObject.FindObjectOfType<Animator>();
	
		projParent = GameObject.Find ("Projectiles");
		
		if (!projParent) {
			projParent = new GameObject("Projectiles");
		}
		
		SetMyLaneSpawner();
		print (laneSpawner);
	}
	
	void Update () {
		if (IsAttackerAheadInLane()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}
	
	void SetMyLaneSpawner () {
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
		
		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				laneSpawner = spawner;
			}
		}
	}

	bool IsAttackerAheadInLane() {
		if (laneSpawner.transform.childCount <= 0) {
			return false;
		}
		foreach (Transform attacker in laneSpawner.transform) {
			if (attacker.transform.position.x > transform.position.x) {
				return true;
			}
		}
		return false;
	}
	
	private void Fire () {
		GameObject newProjectile = Instantiate (proj) as GameObject;
		newProjectile.transform.parent = projParent.transform;
		newProjectile.transform.position = weapon.transform.position;
	}
}
