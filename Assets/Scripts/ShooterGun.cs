using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterGun : MonoBehaviour {
	public GameObject turret;
	public GameObject projectile;
	public Vector2 velocity;
	public Vector2 offset = new Vector2(0.4f, 0.1f);
	public PlayerMovement playerScript;
	public GameObject Turret;
	Quaternion rH;

	float Timer;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerScript.player == GameObject.Find ("Turret")) {
			transform.Rotate (0,0,0);
			float truckerRotation = Input.GetAxis ("Horizontal") * Time.time;
			Vector3 rot = transform.rotation.eulerAngles + new Vector3 (0, 0, truckerRotation);
			Timer -= 1 * Time.deltaTime;

			if (Input.GetButton ("controlTrucker") &&  Timer <= 0) {
				GameObject bullet = Instantiate (projectile, Turret.transform.position, Quaternion.Euler (0, 0, Mathf.Clamp (truckerRotation * 5, -70, 70)));
				Timer = 0.05f;
			}
		}
	}
}
