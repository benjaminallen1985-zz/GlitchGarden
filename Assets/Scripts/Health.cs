using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float life = 100f;
	
	public void DealDamage (float damage) {
		life -= damage;
			
		if(life < 0) {
			//TODO add death animation
			DestoryObject();
		}
	}
	
	public void DestoryObject () {
		Destroy (gameObject);
	}
}
