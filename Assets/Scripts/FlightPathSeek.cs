using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightPathSeek : MonoBehaviour
{
	public float speed;		//bullet velocity multiplier
    public float rotateSpeed; //speed that targets are tracked.
    public GameObject explosionPrefab;
    public Rigidbody2D rb;
    public int Damage;

	private Vector2 direction;
    private Vector2 normalizedDirection;
    private Transform targetTransform;
    private bool enter = false;
    private Transform nullTransform = null;
    private Collider2D thisCollider;
    // Start is called before the first frame update
    void Start()
    {
        thisCollider = gameObject.GetComponent<Collider2D>();
        direction = this.transform.up;

        normalizedDirection = direction / Mathf.Sqrt(Mathf.Pow (direction.x, 2) + Mathf.Pow (direction.y , 2) ) ;
    }

    void Update() {   

    }

    void FixedUpdate() 
    {
        rb.velocity = transform.up * speed;

        if (enter) {
            Vector2 turnDirection = (Vector2)targetTransform.position - (Vector2)this.transform.position;
            Vector2 normalizedTurnDirection = turnDirection / Mathf.Sqrt(Mathf.Pow (turnDirection.x, 2) + Mathf.Pow (turnDirection.y , 2) ) ;
            float rotateAmount = Vector3.Cross(normalizedTurnDirection, this.transform.up).z;
            rb.angularVelocity = -rotateAmount * rotateSpeed; 
        }
        else
            rb.angularVelocity = 0f;
    }

    void OnTriggerEnter2D (Collider2D hitInfo) 
    {
        if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("Bullet") || hitInfo.CompareTag("Radius") || hitInfo.CompareTag("Wall")) 
        {
            // do nothing
        }
        else
        {
            enter = true;
            targetTransform = hitInfo.transform;  
            Debug.Log(hitInfo.tag);
        }
    }

    void OnTriggerStay2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("Bullet") || hitInfo.CompareTag("Radius") || hitInfo.CompareTag("Wall")) 
        {

        }
        else
        {
                enter = true; 
                targetTransform = hitInfo.transform;
        }
    }

    void OnTriggerExit2D (Collider2D other) 
    {
        enter = false;
        targetTransform = nullTransform;
    }

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


