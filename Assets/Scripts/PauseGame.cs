using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
	[SerializeField] private GameObject pausePanel;
    
    void Start()
    {
    	
    }

    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Escape)) 
        {
            if (!pausePanel.activeInHierarchy) 
            {
                Pause();
            }
            else
            {
                 ContinueGame();   
            }
        }
     }
    private void Pause()
    {
    	pausePanel.SetActive(true);
        Time.timeScale = 0;
        //Disable scripts that still work while timescale is set to 0
    } 
    private void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        //enable the scripts again
    }
}
