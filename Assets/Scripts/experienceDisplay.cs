using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class experienceDisplay : MonoBehaviour
{
	private int experience;
	private RectTransform slider;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    	slider = GetComponent<RectTransform>();
        experience = 1;
    }

    // Update is called once per frame
    void addExperience(int expUp)
    {
        experience += expUp;

    	if (experience < 100)
    	{
            checkExperience(experience);
    	}
    	else
    	{
    		experience = 1;
            player.SendMessage("activatePanel");
    	}

    	slider.localScale = new Vector3(experience, 1, 1);
    }

    void checkExperience(int expUp) 
    {
        if (expUp < 0)
        {
            experience += 100;
            levelDown(); 
        }
    }

    void levelDown() 
    {
        player.SendMessage("downgradeTank");
    }

    void reset()
    {
        experience = 1;
        slider.localScale = new Vector3(experience, 1, 1);
    }

}
