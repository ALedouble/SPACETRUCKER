using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvoiFollow : MonoBehaviour
{
	public GameObject basTrucker;
	public PlayerMovement playerScript;
	public GameObject Trucker;
	public float smoothedSpeed;
	public Vector3 offset;
	
	float v;
	private bool returnRotation;
	
	// Use this for initialization
	void Start ()
	{
		Physics2D.gravity = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update ()
	{
		v = Input.GetAxis ("Vertical");
		StartCoroutine(rotationWagon());
		
		if (Vector3.Distance (transform.position, basTrucker.transform.position) > 1f) {
			transform.Translate(0.05f, 0, 0, Space.Self);
		}

//		Vector3 desiredPosition = Trucker.transform.position + offset;
//		Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothedSpeed);
//		transform.position = smoothedPosition;
		
		if (playerScript.player == GameObject.Find("Trucker") && Input.GetAxis ("Vertical") > 0)
		{
//			transform.Translate(playerScript.speedTrucker * 0.4f, 0, 0, Space.Self);
		}

		if (playerScript.player == GameObject.Find("Trucker") && Input.GetAxis ("Vertical") < 0) {
//			transform.Translate(-0.5f*playerScript.speedTrucker,0, 0, Space.Self);
		}
	}
	
	IEnumerator rotationWagon()
	{
		if (playerScript.playerTarget == true)
		{
			yield return new WaitForSeconds(0f);
			transform.LookAt (Trucker.transform.position);
			transform.Rotate (new Vector3 (0, -90, 0), Space.Self);
		}
		
		if (playerScript.playerTarget == true && returnRotation == false)
		{
			yield return new WaitForSeconds(3f);
			returnRotation = true;
		}
		
		if (playerScript.playerTarget == true && returnRotation == true)
		{
			yield return new WaitForSeconds(0.1f);
			returnRotation = false;
		}
			
	}
}
