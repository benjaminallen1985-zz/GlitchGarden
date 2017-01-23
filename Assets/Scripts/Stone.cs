using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

	private Animator anim;
	
	void Start() {
		anim = GetComponent<Animator>();
	}
	
	void Update() {
		
	}
	
	void OnTriggerStay2D (Collider2D collider) {
		Attacker attackGuy = collider.gameObject.GetComponent<Attacker>();
		
		if(attackGuy) {
			anim.SetTrigger("underAttackTrigger");
		}
	}
	
}
