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

	void Start()
	{
		ClearToggles();
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

	public void SaveButtonPressed()
	{
		UpdateCurrentSize ();
	}

	public void ShowButtonPressed()
	{
		ShowRooms ();
		roomListPanel.SetActive (true);
	}

    public void Size1ButtonPressed()
    {
        size1RoomsPanel.SetActive(true);
        size2RoomsPanel.SetActive(false);
        size3RoomsPanel.SetActive(false);
    }

    public void Size2ButtonPressed()
    {
        size1RoomsPanel.SetActive(false);
        size2RoomsPanel.SetActive(true);
        size3RoomsPanel.SetActive(false);
    }

    public void Size3ButtonPressed()
    {
        size1RoomsPanel.SetActive(false);
        size2RoomsPanel.SetActive(false);
        size3RoomsPanel.SetActive(true);
    }

    private void ClearToggles()
	{
		for (int i = 0; i < rooms.Length; i++) 
		{
			roomToggles [i].GetComponentInChildren<Text>().text = rooms[i].roomName;
		}
	}

    private void ShowRooms()
	{
		for (int i = 0; i < rooms.Length; i++) 
		{
			roomToggles [i].GetComponentInChildren<Text>().text = rooms[i].roomName;
		}
	}

	private void UpdateCurrentSize()
	{
        GameManager.instance.ClearRooms();
		currentHouseSize = 0;
		currentHouseRating = 0;
		currentHouseCost = 0;
        int numRooms = 0;
		for (int i = 0; i < rooms.Length; i++) 
		{
			if (roomToggles [i].isOn) 
			{
				currentHouseSize += rooms[i].roomSize;
				currentHouseRating += rooms[i].roomRating;
				currentHouseCost += rooms[i].roomPrice;
                GameManager.instance.AddRooms(rooms[i]);
                numRooms++;
				Debug.Log("Toggled Location: " + i);
				Debug.Log("Current House Size: " + currentHouseSize);
			}
		}
		if (currentHouseSize > maxHouseSize) 
		{
			//Debug.Log(currentHouseSize);
			errorText.enabled = true;
			errorText.text = "Please reduce the size of your haunted house.";
		} 
		else 
		{
			currentHouseSizeText.text = "Current House Size: " + currentHouseSize.ToString ();
			errorText.enabled = false;
            HideButtonPressed();
		}
		if (currentHouseRating > 0)
		{
        	currentHouseRating /= numRooms;
    	}
        GameManager.instance.SetHouseRating(currentHouseRating);
		GameManager.instance.SetHouseCost(currentHouseCost);
	}
}
