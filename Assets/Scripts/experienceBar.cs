using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class experienceBar : MonoBehaviour
{
	private int experience;
	private RectTransform slider;	
    // Start is called before the first frame update
    void Start()
    {
    	slider = GetComponent<RectTransform>();
        experience = 1;
    }

    // Update is called once per frame
    void addExperience(int expUp)
    {
    	if (experience < 100)
    	{
    		experience += expUp;
    	}
    	else
    	{
    		experience = 1;
    	}
    	slider.localScale = new Vector3(experience, 1, 1);
    }

}
