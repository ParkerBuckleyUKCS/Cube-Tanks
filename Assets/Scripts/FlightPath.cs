using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightPath : MonoBehaviour
{
	public Transform firePointTransform;
	public float speed;		//bullet velocity multiplier
	public Rigidbody2D rb;
    public int Damage;
	private Vector2 direction;
    private Vector2 normalizedDirection;
	public GameObject explosionPrefab;
    private Collider2D thisCollider;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 direction = this.transform.up;
        thisCollider = gameObject.GetComponent<Collider2D>();

        normalizedDirection = direction / Mathf.Sqrt(Mathf.Pow (direction.x, 2) + Mathf.Pow (direction.y , 2) ) ;

    }

    void FixedUpdate() {   
        rb.velocity = normalizedDirection*speed;
    }

/*
    void OnTriggerEnter2D (Collider2D hitInfo) 
    {
    	if (hitInfo.name == "Player" || hitInfo.tag == "Radius")
    		Physics2D.IgnoreCollision( hitInfo , this.GetComponent<Collider2D>());
    	else
    	{
    		Debug.Log(hitInfo.name);
    		//Destroy(gameObject);
    		Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
   		}
    }
*/
    void OnCollisionEnter2D (Collision2D other) 
    {
        if (other.collider.CompareTag("Player") || other.collider.CompareTag("Radius") || other.collider.CompareTag("Bullet"))
        {
            Physics2D.IgnoreCollision(thisCollider, other.collider);
        }
        else
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
            other.collider.gameObject.SendMessage( "Damage", Damage );
        }   
    }
}


