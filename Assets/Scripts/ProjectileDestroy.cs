using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour {


	IEnumerator WaitToDestroy()
	{
		yield return new WaitForSeconds (5);
	}

	IEnumerator Start()
	{
		yield return StartCoroutine ("WaitToDestroy");
		Destroy (gameObject);
	}
}
