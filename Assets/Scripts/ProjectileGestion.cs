using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGestion : MonoBehaviour {
	public const int ProjectileDamage = 10;
	public GameObject weaponGestion;

	void OnColliderEnter(Collider col){
		col.GetComponent<EnnemyHealth> ().TakeDamage (ProjectileDamage*weaponGestion.GetComponent<ShooterGun>().DamageLevel);
		Destroy (gameObject);
	}
}
