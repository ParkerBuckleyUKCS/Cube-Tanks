using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
	private Vector3 offset;
	private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    	offset = playerTransform.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    	this.transform.position = playerTransform.position - offset;
    }
}
