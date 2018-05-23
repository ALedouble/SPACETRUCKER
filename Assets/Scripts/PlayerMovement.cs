using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Deployment.Internal;

public class PlayerMovement : MonoBehaviour {
	
	public float speedPlayer;
	public float speedTrucker;
	public GameObject Trucker;
	public GameObject EmptySlot;
	public bool playerTarget;
	public GameObject Turret;
	public GameObject[] door;
	public float range;
	
	public GameObject player;
	Rigidbody2D rgbTrucker;
	public float h;
	float v;
	public float rH;
	Vector2 movement;
	bool door0 = false;
	bool door1 = false;
	bool door2 = false;
	bool door3 = false;
	float maxSpeed = 5f;
	
	
	
	void Start()
	{
		player = GameObject.Find("Player");
		rgbTrucker = Trucker.GetComponent<Rigidbody2D> ();
		Physics2D.gravity = Vector2.zero;
	}
	
	void Update()
	{
		/// MOVEMENT
		if (Trucker.transform.rotation.z >= 0.923f)
		{
			playerTarget = true;
		}
		
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
		rH = Input.GetAxis("RHorizontal");
		
		if (player == GameObject.Find ("Player")) {
			if ( v < 0 && transform.localPosition.y > -1){
				transform.Translate (v * -speedPlayer, 0, 0);
			}

			if ( v > 0 && transform.localPosition.y < 1){
				transform.Translate (v * -speedPlayer, 0, 0);
			}

			if ( h < 0 && transform.localPosition.x > -4){
				transform.Translate (0, h * speedPlayer, 0);
			}

			if ( h > 0 && transform.localPosition.x < 4){
				transform.Translate (0, h * speedPlayer, 0);
			}
		}

		
		if (player == GameObject.Find("Trucker")){

			transform.position = EmptySlot.transform.position;	
			
//			movement = new Vector2(h, v);
			
			if (Input.GetAxis("RHorizontal") == 0)
			{
				playerTarget = true;
			} 
			
			if (Input.GetAxis("RHorizontal") != 0) 
			{
				float truckerRotation = Input.GetAxis("RHorizontal");
				Vector3 rot = Trucker.transform.rotation.eulerAngles + new Vector3 (0, 0, truckerRotation);
				rot.z = Mathf.Clamp (rot.z, 160,200);

				Trucker.transform.eulerAngles = rot;
			}

			if (Input.GetAxis ("Vertical") < 0) {
//				Trucker.transform.Translate(-0.5f*speedTrucker,0, 0, Space.Self);
			}

			if (Input.GetAxis ("Vertical") > 0) {
//				Trucker.transform.Translate (0.4f * speedTrucker * v, 0, 0, Space.Self);
			}
			
			
			/// PORTE
			
			
		}

		if (player == GameObject.Find ("Turret")) {
			transform.position = Turret.transform.position;	

			if (Input.GetAxis("RHorizontal") == 0)
			{
				playerTarget = true;
			} 


			if (Input.GetAxis("RHorizontal") != 0) 
			{
				float truckerRotation = Input.GetAxis("RHorizontal");
				Vector3 rot = Turret.transform.rotation.eulerAngles + new Vector3 (0, 0, truckerRotation);
				rot.z = Mathf.Clamp(rot.z, 70, 110);

				Turret.transform.eulerAngles = rot;
			}
		}

		OnModul ();
	}



	void OnModul(){
		RaycastHit hit;
		Vector3 endPosition = new Vector3 (10, 0, 0);
		if (Physics.Raycast (transform.position, endPosition, out hit, range)){
			print (hit.transform.name);
		}
		Debug.DrawRay (transform.position, endPosition, Color.red, 15f);
	}

//	void OnTriggerStay2D(Collider2D other)
//	{
//		if (gameObject.name == "Player" && other.gameObject.name == "EmptyBox") 
//		{
//			if (Input.GetButtonUp ("controlTrucker") && player == GameObject.Find ("Player")) {				
//				player = GameObject.Find ("Trucker");
//			}
//		}
//
//		if (gameObject.name == "Player" && other.gameObject.name == "Turret") 
//		{
//			if (Input.GetButtonUp ("controlTrucker") && player == GameObject.Find ("Player")) {				
//				player = GameObject.Find ("Turret");
//			}
//		}
//
//		if (Input.GetButtonUp ("exitTrucker") && player == GameObject.Find ("Turret")) 
//		{				
//			player = GameObject.Find ("Player");
//			rgbTrucker.velocity = new Vector3 (0, 0, 0);
//			playerTarget = false;
//		}
//
//		if (Input.GetButtonUp ("exitTrucker") && player == GameObject.Find ("Trucker")) 
//		{				
//			player = GameObject.Find ("Player");
//			rgbTrucker.velocity = new Vector3 (0, 0, 0);
//			playerTarget = false;
//		}
//
//		if (gameObject.name == "Player" && other.gameObject.name == "Door") {
//			if (Input.GetButtonUp ("controlTrucker") && player == GameObject.Find ("Player")) {	
//				StartCoroutine (Teleport());
//				door0 = true;
//			}
//		}
//
//		if (gameObject.name == "Player" && other.gameObject.name == "Door2") {
//			if (Input.GetButtonUp ("controlTrucker") && player == GameObject.Find ("Player")) {	
//				StartCoroutine (Teleport());
//				door1 = true;
//			}
//		}
//
//		if (gameObject.name == "Player" && other.gameObject.name == "Door3") {
//			if (Input.GetButtonUp ("controlTrucker") && player == GameObject.Find ("Player")) {	
//				StartCoroutine (Teleport());
//				door2 = true;
//			}
//		}
//
//		if (gameObject.name == "Player" && other.gameObject.name == "Door4") {
//			if (Input.GetButtonUp ("controlTrucker") && player == GameObject.Find ("Player")) {	
//				StartCoroutine (Teleport ());
//				door3 = true;
//			}
//		}
//
//
//
//	}

//	IEnumerator Teleport(){
//		yield return new WaitForSeconds (1);
//		if (door0 == true){
//			transform.position = door[1].transform.position;
//			door0 = false; 
//		}
//
//		if (door1 == true){
//			transform.position = door[0].transform.position;
//			door1 = false; 
//		}
//
//		if (door2 == true){
//			transform.position = door[2].transform.position;
//			door2 = false; 
//		}
//
//		if (door3 == true){
//			transform.position = door[3].transform.position;
//			door3 = false; 
//		}
//	}

	void FixedUpdate(){
		rgbTrucker.AddForce (transform.up * 1.5f);
		Vector2 movement = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
	}
}

