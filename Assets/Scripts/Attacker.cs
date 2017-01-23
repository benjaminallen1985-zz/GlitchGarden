using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {
	
	[Tooltip ("Average number of seconds between appearances")]
	public float spawnSeconds;
	
	private float curSpeed;
	private GameObject curTarget;
	private Animator anim;
	
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	void Update () {
		transform.Translate(Vector3.left * curSpeed * Time.deltaTime);
		if(!curTarget) {
			anim.SetBool ("isAttacking", false);
		}
	}
	
	void OnTriggerEnter2D () {
		
	}
	
	public void SetSpeed (float speed) {
		curSpeed = speed;
	}
	
	public void attackTarget (float damage) {
		if(curTarget) {
			Health health = curTarget.GetComponent<Health>();
			if (health) {
				health.DealDamage (damage);
			}
		}
	}
	
	public void Attack (GameObject obj) {
		curTarget = obj;
	}
}
