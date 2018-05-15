using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimpleBehaviour : MonoBehaviour {

	public GameObject EnemyTarget; 			// assigner le game object du spacetruck
	public float CircleDetectionRadius;		// Cercle de détection
	public float CircleChaseRadius;			// Cercle de détection une fois en chasse

	public Vector3 ActualTargetPos;			// position du spacetruck
	public Vector3 ActualEnemyPos;		

	public bool isChasing;					// est-ce que le vaisseau a repéré le spacetruck
	public Rigidbody2D rig;
	private int randomNumber;
	public float RevolutionSpeed;			// Vitesse à laquelle l'ennemi tourne autour du spacetruck

	public GameObject myPrefab;				// Assigner le prefab du projectile laser
	public float ProjectileSpeed = 20.0f;		// vitesse du projectile laser
	public float TimeBetweenShots = 1f;
	private bool CanShoot;



	void Start () 
	{
		GetComponent<CircleCollider2D> ().radius = 7;
		ActualEnemyPos = transform.position;
		isChasing = false;
		CanShoot = true;
	}


	void FixedUpdate () 
	{
		if (isChasing == true) 
		{
			GetComponent<CircleCollider2D> ().radius = CircleChaseRadius;
			
			Debug.Log ("lalalalalala");

			if (randomNumber == 0) 
			{
				rig.AddRelativeForce (new Vector2(0.2f,RevolutionSpeed),ForceMode2D.Force);

				Debug.Log ("Go Left");
			}
			if (randomNumber == 1) 
			{
				rig.AddRelativeForce (new Vector2(0.2f,-RevolutionSpeed), ForceMode2D.Force);
				Debug.Log ("Go Right");
			}

			ShootProjectile ();
		}


	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.gameObject == EnemyTarget) 
		{
			
			ActualTargetPos = other.transform.position;

			randomNumber = Random.Range (0, 2);

			isChasing = true;
		}
	}


	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject == EnemyTarget) 
		{
			ActualTargetPos = other.transform.position;
			ActualEnemyPos = transform.position;


			Vector3 direction = ActualTargetPos - ActualEnemyPos;
			float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		}

	}


	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject == EnemyTarget) 
		{
			GetComponent<CircleCollider2D> ().radius = CircleDetectionRadius;
			isChasing = false;
		}
	}
		


	void ShootProjectile ()
	{
		Debug.Log ("Shooting");

		if (CanShoot == true) 
		{
			Vector3 direct = ActualTargetPos - ActualEnemyPos;
			float angle = Mathf.Atan2 (direct.y, direct.x) * Mathf.Rad2Deg;

			GameObject ProjectileInstance = (GameObject)Instantiate (myPrefab, transform.position, transform.rotation);


			ProjectileInstance.GetComponent<Rigidbody2D> ().AddForce (direct * ProjectileSpeed);

			CanShoot = false;
			Debug.Log ("shot done");
		
			StartCoroutine ("Reload");
		}
	}


	IEnumerator Reload()
	{
		Debug.Log ("Reloading");

		yield return new WaitForSeconds (TimeBetweenShots);

		CanShoot = true;

	}






}

