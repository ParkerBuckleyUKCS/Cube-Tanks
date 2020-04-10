using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
	public Transform gunTransform;

    void FixedUpdate()
    {
	    Vector3 mousePosition = Input.mousePosition;  //used to calculate relative mouse position to player
		Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

		Vector2 direction = new Vector2(
	    	worldMousePosition.x - transform.position.x,
	    	worldMousePosition.y - transform.position.y
		);

		transform.up = direction;
    }

}
