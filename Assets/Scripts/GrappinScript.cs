using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappinScript : MonoBehaviour {
	Vector3 startPos;
	GameObject Parent;
	Vector3 Dir;
	int shoot = 0;
	public float speed = 6f;
	public float speedMultiply = 2f;
	public float delay = 0.5f;

	// Use this for initialization
	void Start () {
		Parent = transform.parent.gameObject;
		startPos = Parent.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		startPos = Parent.transform.position;
		if (shoot == 0) {
			transform.position = new Vector3 (startPos.x - Input.GetAxis ("Horizontal"), startPos.y - Input.GetAxis ("Vertical"), startPos.z);
			Dir = (transform.position - startPos).normalized;
		} else if (shoot == 1) {
			StartCoroutine (Timer ());
			transform.position += Dir * speed * Time.deltaTime;
		} else {
			if (transform.position != startPos) {
				transform.position = Vector3.MoveTowards (transform.position, startPos, speed * speedMultiply * Time.deltaTime);
			} else {
				shoot = 0;
			}
		}


		if (Input.GetButton ("controlTrucker")) {
			shoot = 1;
		}
	}

	IEnumerator Timer () {
		yield return new WaitForSecondsRealtime (delay);
		shoot = 2;
	}
}
