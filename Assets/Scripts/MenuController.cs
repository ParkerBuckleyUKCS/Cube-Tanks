using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	public void StartGame() {
		SceneManager.LoadScene( "Game" );
		Time.timeScale = 1;
	}

	public void Back() {
		SceneManager.LoadScene( "Menu" );
	}

	public void Credits() {
		SceneManager.LoadScene( "Credits" );
	}

	public void Instructions() {
		SceneManager.LoadScene( "Instructions" );
	}

	public void Quit() {
		Application.Quit();
	}
	
}
