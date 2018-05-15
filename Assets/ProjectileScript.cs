using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (DestroyBullet());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0,1,0, Space.Self);
	}

	IEnumerator DestroyBullet(){
		yield return new WaitForSeconds (1f);
		Destroy (gameObject);
	}
}
