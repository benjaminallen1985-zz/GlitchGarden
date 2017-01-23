using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	private Animator animate;
	private Attacker attacker;
	
	void Start () {
		animate = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	void Update () {
	
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log ("Fox collided with " + collider);
		
		GameObject obj = collider.gameObject;
		
		if(!obj.GetComponent<Defender>()) {
			return;
		}
		
		if(obj.GetComponent<Stone>()) {
			animate.SetTrigger ("Jump Trigger");
		} else {
			animate.SetBool ("isAttacking", true);
			attacker.Attack (obj);
		}
	}
}
