using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionRemove : MonoBehaviour
{
	private GameObject newExplosion;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
        newExplosion = this.gameObject;
    }


    // Update is called once per frame
    IEnumerator wait() 
    {
    	yield return new WaitForSeconds(1);
    	Destroy(newExplosion);
    }
}
