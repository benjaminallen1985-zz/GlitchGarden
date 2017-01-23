using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float curSpeed, curDamage;

	void Start () {
	
	}
	
	void Update () {
		transform.Translate(Vector3.right * curSpeed * Time.deltaTime);
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		Attacker attacker = collider.gameObject.GetComponent<Attacker>();
		Health health = collider.gameObject.GetComponent<Health>();
		
		if(attacker && health) {
			health.DealDamage(curDamage);
			Destroy(gameObject);
		}
	}
}
