using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeController : MonoBehaviour
{
   [SerializeField] private GameObject pausePanel;
    private GameObject canvas;
	private int currentTier;
	public GameObject[] allTanks;
    public GameObject[] textDescriptions;
    public GameObject[] buttons;
    public int[] upgradeChoices = new int[5];

    void Start()
    {
        currentTier = 0;
        pausePanel.SetActive(false);
        upgradeChoices[0] = 0;
        canvas = GameObject.Find("/Canvas/Image/Slider/Fill Area/expBar");
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    } 
    private void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        //enable the scripts again
    }

    void activatePanel() 
    {
	    if (!pausePanel.activeInHierarchy) 
        {
            setTextTier();
            PauseGame();
        }
        else
        {
            ContinueGame();   
        }
    }

    public void upgradeTank1() 
    {
    	ContinueGame();
    	currentTier++;
    	upgradeChoices[currentTier] = 1;
        if (currentTier != 1)
    	   allTanks[3*(currentTier-2) + upgradeChoices[currentTier - 1]].SetActive(false);
        else
            allTanks[0].SetActive(false);
            
    	allTanks[3*(currentTier-1) + 1].SetActive(true);
    }
    public void upgradeTank2()
    {
    	ContinueGame();
    	currentTier++;
    	upgradeChoices[currentTier] = 2;
        if (currentTier != 1)
            allTanks[3*(currentTier-2) + upgradeChoices[currentTier - 1]].SetActive(false);
        else
            allTanks[0].SetActive(false);

    	allTanks[3*(currentTier-1) + 2].SetActive(true);
    }
    public void upgradeTank3()
    {
    	ContinueGame();
    	currentTier++;
    	upgradeChoices[currentTier] = 3;
    	if (currentTier != 1)
            allTanks[3*(currentTier-2) + upgradeChoices[currentTier - 1]].SetActive(false);
        else
            allTanks[0].SetActive(false);
            
    	allTanks[3*(currentTier-1) + 3].SetActive(true);
    }

    void downgradeTank()
    {
        if (currentTier == 1)
        {
            allTanks[0].SetActive(true);
            allTanks[upgradeChoices[1]].SetActive(false);
            currentTier--;
        }
        else if (currentTier > 1)
        {
            allTanks[3*(currentTier-1) + upgradeChoices[currentTier]].SetActive(false);
            allTanks[3*(currentTier-2) + upgradeChoices[currentTier-1]].SetActive(true);
            currentTier--;
        }
        else
        {
            canvas.SendMessage("reset");
        }
        /*
        if (currentTier != 0)
        {
            currentTier--;
            allTanks[3*(currentTier+1) + upgradeChoices[currentTier+2]].SetActive(false);
            allTanks[3*( currentTier ) + upgradeChoices[currentTier]].SetActive(true);
        }
        else
        {
            canvas.SendMessage("reset");
        }
        */    
    }

    void resetText()
    {
        for (int i = 0; i < textDescriptions.Length; i++)
        {
            textDescriptions[i].SetActive(false);
        }
    }

    void setTextTier()
    {
        resetText();

        if(currentTier == 0)
        {
            textDescriptions[0].SetActive(true);
            textDescriptions[1].SetActive(true);
            textDescriptions[2].SetActive(true);
        }
        else if (currentTier == 1)
        {
            textDescriptions[3].SetActive(true);
            textDescriptions[4].SetActive(true);
            textDescriptions[5].SetActive(true);
        }
        else if (currentTier == 2)
        {
            textDescriptions[6].SetActive(true);
            textDescriptions[7].SetActive(true);
            textDescriptions[8].SetActive(true);
        }
        else if (currentTier == 3)
        {
            buttons[0].SetActive(false);
            buttons[1].SetActive(false);
            buttons[2].SetActive(false);            
            buttons[3].SetActive(true);
        }
    }
}

