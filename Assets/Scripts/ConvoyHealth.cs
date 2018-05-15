using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvoyHealth : MonoBehaviour {

	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	private bool CanConvoyTakeDamage;

	public void TakeDamage(int amount){
		if(gameObject.GetComponent<ShieldGestion> ().CanTakeDamage != false){
		currentHealth -= amount;
			if (currentHealth <= 0) {
				currentHealth = 0;
				Debug.Log(gameObject + "Dead");
				Destroy (gameObject);
			}
		}
	}

	public void HealConvoy(){
		currentHealth = maxHealth;
	}
}
