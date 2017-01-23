using UnityEngine;
using System.Collections;

public class Spirit : MonoBehaviour {

	private Animator anim;
	private Attacker attackerGuy;
	
	void Start () {
		anim = GetComponent<Animator>();
		attackerGuy = GetComponent<Attacker>();
	}
	
	void Update () {
		
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log ("Spirit collided with " + collider);
		
		GameObject obj = collider.gameObject;
		
		if(!obj.GetComponent<Defender>()) {
			return;
		} else {
			anim.SetBool ("isAttacking", true);
			attackerGuy.Attack (obj);
		}
	}
}
