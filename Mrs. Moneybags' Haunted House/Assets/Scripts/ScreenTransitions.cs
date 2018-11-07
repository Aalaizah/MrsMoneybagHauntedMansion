using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScreenTransitions : MonoBehaviour {
	
	string NewGame = "GameScreen";
	string MainMenu = "MainMenuScreen";
	public GameObject roomListPanel;
	public GameObject gameUIPanel;
    public GameObject size1RoomsPanel;
    public GameObject size2RoomsPanel;
    public GameObject size3RoomsPanel;
    public Room[] rooms;
	public Toggle[] roomToggles;
	public Text currentHouseSizeText;
	public Text errorText;

	private int currentHouseSize = 0;
	private int maxHouseSize = 6;
	private int currentHouseRating = 0;
	private int currentHouseCost = 0;

	void Awake()
	{
		ShowRooms ();
	}

	public void PlayButtonPressed()
	{
		SceneManager.LoadSceneAsync(NewGame, LoadSceneMode.Single);
	}

	public void QuitButtonPressed()
	{
		SceneManager.LoadSceneAsync(MainMenu, LoadSceneMode.Single);
	}

	public void HideButtonPressed()
	{
		roomListPanel.SetActive (false);
		gameUIPanel.SetActive (true);
		GameManager.instance.SetInstructionTextEnabled(false);
        GameManager.instance.SetRoomLocations();
	}

	public void ShowButtonPressed()
	{
		ShowRooms ();
		roomListPanel.SetActive (true);
	}

    private void ShowRooms()
	{
		Debug.Log("ShowRooms was called");
		for (int i = 0; i < rooms.Length; i++) 
		{
			roomToggles [i].GetComponentInChildren<Text>().text = rooms[i].roomName;
		}
	}
}
