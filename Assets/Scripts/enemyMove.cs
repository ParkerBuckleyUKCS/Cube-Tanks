using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
	public float moveSpeed = 40; //Controlls player move speed
	private Rigidbody2D rb;	// used for mouse events, physics, etc..
    public float speedLimit = 3;

    private float moveHorizontal, moveVertical;


    void Start()
    {
    	rb = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
    	moveHorizontal = Random.Range(-1f,1f);
    	moveVertical = Random.Range(-1f,1f);
    }
    
    void FixedUpdate() 
    {
        if (Mathf.Abs(rb.velocity.x) > speedLimit)
        {
            if (((rb.velocity.x > 0) && (moveHorizontal > 0)) || ((rb.velocity.x < 0) && (moveHorizontal < 0)) )
                moveHorizontal = -moveHorizontal;
        }
        if (Mathf.Abs(rb.velocity.y) > speedLimit) 
        {
            if (((rb.velocity.y > 0) && (moveVertical > 0)) || ((rb.velocity.y < 0) && (moveVertical < 0)) )
                moveVertical = -moveVertical;
        }

        Vector2 movement = new Vector2 (moveHorizontal,moveVertical);
    	rb.AddForce(movement * moveSpeed);
    }
}
