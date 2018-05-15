using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGestion : MonoBehaviour {

	public bool Shield;
	public bool CanTakeDamage; 


	// Use this for initialization
	void Start () 
	{
		CanTakeDamage = true;
		Shield = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Shield == true) // Passe à True quand le grappin attrape le bonus => Faire un lien entre les deux scripts
		{
			StartCoroutine (ShieldedTime ());
		}
	
	}

	IEnumerator ShieldedTime ()
	{
		CanTakeDamage = false;
		yield return new WaitForSeconds (2f);
		CanTakeDamage = true;
		Shield = false;
		yield break;
	}
}
