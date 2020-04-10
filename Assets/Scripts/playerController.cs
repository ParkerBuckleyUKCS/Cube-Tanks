using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
	public float moveSpeed; //Controlls player move speed
	private Rigidbody2D rb;	// used for mouse events, physics, etc..
    public float speedLimit;
	// private MouseEventBase mb;
	// Start is called before the first frame update
    void Start()
    {
    	rb = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void FixedUpdate() 
    {
    	float moveHorizontal = Input.GetAxis ("Horizontal");
    	float moveVertical = Input.GetAxis ("Vertical");

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
