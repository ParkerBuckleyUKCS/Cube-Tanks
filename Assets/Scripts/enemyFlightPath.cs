using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFlightPath : MonoBehaviour
{
	public Transform firePointTransform;
	public float speed;		//bullet velocity multiplier
	public Rigidbody2D rb;
	private Vector2 direction;
    private Vector2 normalizedDirection;
	public GameObject explosionPrefab;
    private Collider2D thisCollider;
    public int Damage;
    private GameObject UserInterface;
    // Start is called before the first frame update
    void Start()
    {
        UserInterface = GameObject.Find("/Canvas/Image/Slider/Fill Area/expBar");
        Vector2 direction = this.transform.up;
        thisCollider = gameObject.GetComponent<Collider2D>();

        normalizedDirection = direction / Mathf.Sqrt(Mathf.Pow (direction.x, 2) + Mathf.Pow (direction.y , 2) ) ;

        firePointTransform = this.transform.parent.gameObject.transform;
		this.transform.position = firePointTransform.position;
		this.transform.rotation = firePointTransform.rotation;
    }

    void FixedUpdate() {   
        rb.velocity = normalizedDirection*speed;
    }

    void OnCollisionEnter2D (Collision2D other) 
    {
        if (other.collider.CompareTag("Enemy") || other.collider.CompareTag("Radius") || other.collider.CompareTag("Bullet"))
        {
            Physics2D.IgnoreCollision(thisCollider, other.collider);
        }
        else if (other.collider.CompareTag("Wall"))
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);           
        }
        else
        {
            Destroy(gameObject);
            Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
            UserInterface.SendMessage("addExperience",-1*Damage);
        }    
    }
}


