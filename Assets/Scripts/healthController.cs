using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthController : MonoBehaviour
{
	public int health;
	public int experience;
	public GameObject explosionPrefab;
	public GameObject UserInterface;
	
	void Start() 
	{
		UserInterface = GameObject.Find("/Canvas/Image/Slider/Fill Area/expBar");
	}

	void Damage(int dmg) 
	{
		health = health - dmg;

		if (health <= 0) 
		{
			Destroy(this.gameObject);
			Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
			UserInterface.SendMessage("addExperience", experience);		
		}
	}
}
