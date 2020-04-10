using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAim : MonoBehaviour
{
	public Transform firePointTransform;
	public float shootSpeed = 1;
	private float timer;
	private bool isPlayerHere = false;
	private Transform targetTransform;
	private Transform emptyTransform;
	private Transform playerTransform;
	private Vector3 direction;
	public GameObject bulletPreFab;
	
	void Start() 
	{
		playerTransform = GameObject.Find("Player").transform;
		timer = shootSpeed;	//set the initial timer
	}

	void OnTriggerEnter2D(Collider2D hitInfo) 
	{
		if (hitInfo.tag == "Player")
        {
        	isPlayerHere = true;
        	targetTransform = playerTransform;
        }
	}

	void OnTriggerExit2D(Collider2D hitInfo) 
	{
		if (hitInfo.tag == "Player") 
		{
			isPlayerHere = false;
			targetTransform = emptyTransform;
		}
	}

	void Update()
	{
		if (isPlayerHere) 
		{
			direction = new Vector3(
				targetTransform.position.x - this.transform.position.x,
				targetTransform.position.y - this.transform.position.y,
				targetTransform.position.z - this.transform.position.z
				);

			this.transform.up = direction;

			Attack();
		}
	}

	void shoot() 
	{
		Instantiate(bulletPreFab, firePointTransform.position, firePointTransform.rotation);
	}

	void Attack()
	{
	    timer -= Time.deltaTime;
	    if (timer <= 0)
	    {
	         shoot();
	         timer = shootSpeed;
	    }
	}
}

