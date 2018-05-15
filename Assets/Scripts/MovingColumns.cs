using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingColumns : MonoBehaviour {
	public GameObject targetPoint;
	private float TargetPosition;
	public int MovingTime;
	private float completion;
	// Use this for initialization
	void Start () {
		completion = 0;
		TargetPosition = targetPoint.GetComponent<Transform> ().transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		completion += (Time.deltaTime/MovingTime*Time.deltaTime);
		gameObject.transform.position = new Vector2 (gameObject.transform.position.x, Mathf.Lerp(gameObject.transform.position.y,TargetPosition,completion));
	}

	void OnCollider2DEnter(){
		Destroy (gameObject);
	}
}