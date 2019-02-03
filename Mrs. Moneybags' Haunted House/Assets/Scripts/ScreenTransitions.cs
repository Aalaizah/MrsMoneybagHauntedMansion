using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenTransitions : MonoBehaviour {
	
	string NewGame = "GameScreen";
	string MainMenu = "MainMenuScreen";

	public void PlayButtonPressed()
	{
		SceneManager.LoadSceneAsync(NewGame, LoadSceneMode.Single);
	}

	public void QuitButtonPressed()
	{
		SceneManager.LoadSceneAsync(MainMenu, LoadSceneMode.Single);
	}
}
