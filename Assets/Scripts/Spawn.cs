using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
	public const int spawnCap = 30;
	private const int numEnemies = 6;

	public GameObject[] enemyModels = new GameObject[numEnemies];
	private int[] enemyIntCodes = new int[spawnCap];
	public GameObject[] enemyArray = new GameObject[spawnCap];

    // Start is called before the first frame update
    void Start()
    {
    	for (int i = 0; i < enemyIntCodes.Length; i++)
    	{
    		enemyIntCodes[i] = genNum(0f,(numEnemies-1f));
    	}

    	for (int i = 0; i < enemyIntCodes.Length; i++)
    	{
    		enemyArray[i] = enemyModels[enemyIntCodes[i]];
    	}
    
    	checkDeaths();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int genNum(float low, float high)
    {
    	return (int)Mathf.Floor(Random.Range(low, (float)(high + .99)));
    }

    void checkDeaths()
    {
    	for (int i = 0; i < spawnCap; i++)
    	{
    		if (true) 	//if there was a death at this inddex
    		{
    			enemyIntCodes[i] = genNum(0f,(numEnemies-1f));
    			enemyArray[i] = enemyModels[enemyIntCodes[i]];

    			Vector3 newPos = new Vector3( genNum(-30,26), genNum(-20,29) , 0);
    			Instantiate(enemyArray[i], newPos, enemyArray[i].transform.rotation, this.gameObject.transform);
    		}
    	}
    }
}
