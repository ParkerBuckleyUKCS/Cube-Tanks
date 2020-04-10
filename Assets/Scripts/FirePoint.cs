using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePoint : MonoBehaviour
{
	public Transform gunTransform;
	public GameObject bulletPreFab;
	public float shootSpeed = 1;
	private float timer;
	private bool hasShot;

	void Start() 
	{
		hasShot = false;
		timer = shootSpeed;
	}

	void Update() 
	{
		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			hasShot = false; 
			timer = shootSpeed;
		}

		if (Input.GetMouseButtonDown(0) && hasShot == false)
		{
			Shoot();
			hasShot = true;
		}
	}

	
	void Shoot () 
    {
    	Instantiate(bulletPreFab, this.transform.position, this.transform.rotation);
    }  	
}
