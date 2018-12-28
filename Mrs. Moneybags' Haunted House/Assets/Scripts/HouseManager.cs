using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseManager : MonoBehaviour {

    [SerializeField] private GameObject size1RoomsPanel;
    [SerializeField] private GameObject size2RoomsPanel;
    [SerializeField] private GameObject size3RoomsPanel;
    [SerializeField] private Room[] rooms;
	[SerializeField] private Toggle[] roomToggles;
	[SerializeField] private Text currentHouseSizeText;
	[SerializeField] private Text errorText;
	[SerializeField] private Text maxHouseSizeText;

	private int currentHouseSize = 0;
	public static readonly int maxHouseSize = 6;
	private int currentHouseRating = 0;
	private int currentHouseCost = 0;

	void Awake () {
		maxHouseSizeText.text = "Max Size: " + maxHouseSize.ToString();
		ClearToggles();
	}

	public int getHouseSize()
	{
		return currentHouseSize;
	}

	public void setHouseSize(int newSize)
	{
		if (newSize > 0)
		{
			currentHouseSize = newSize;
		}
	}

	public void SaveButtonPressed()
	{
		UpdateCurrentSize ();
		UpdateCurrentRating(GameManager.instance.ReadCurrentRooms());
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
			roomToggles [i].GetComponentInChildren<Toggle>().isOn = false;
		}
	}

	private void UpdateCurrentRooms()
	{
        GameManager.instance.ClearRooms();
        for (int i = 0; i < rooms.Length; i++)
        {
        	if (roomToggles[i].isOn)
        	{
        		GameManager.instance.AddRooms(rooms[i]);
        	}
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
                GameManager.instance.AddRooms(rooms[i]);
                numRooms++;
			}
		}
		if (currentHouseSize > maxHouseSize) 
		{
			errorText.enabled = true;
			errorText.text = "Please reduce the size of your haunted house.";
		} 
		else 
		{
			currentHouseSizeText.text = "Current House Size: " + currentHouseSize.ToString ();
			errorText.enabled = false;
		}
		if (currentHouseRating > 0)
		{
        	currentHouseRating /= numRooms;
    	}
        GameManager.instance.SetHouseRating(currentHouseRating);
		GameManager.instance.SetHouseCost(currentHouseCost);
	}

	private void UpdateCurrentRating(List<Room> roomsInHouse)
	{
		currentHouseRating = 0;
		for (int i = 0; i < roomsInHouse.Count; i++)
		{
			currentHouseRating += roomsInHouse[i].roomRating;
		}
	}
}
