using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseManager {
	private List<Room> allRooms;
	private List<Room> roomsInUse;

	public HouseManager(List<Room> rooms)
	{
		allRooms = rooms;
		roomsInUse = new List<Room>();
	}

	public void AddRoom(Room roomToAdd)
	{
		if(!roomsInUse.Contains(roomToAdd))
		{
			roomsInUse.Add(roomToAdd);
		}
		else
		{
			Debug.Log("Room already in list");
		}
	}

	public void RemoveRoome(Room roomToRemove)
	{
		if(roomsInUse.Contains(roomToRemove))
		{
			roomsInUse.Remove(roomToRemove);
		}
		else
		{
			Debug.Log("Room not in list");
		}
	}

	public List<Room> GetAllRooms()
	{
		return allRooms;
	}

	public List<Room> GetRoomsInUse()
	{
		return roomsInUse;
	}
/*
    [SerializeField] private Room[] rooms;

	private int currentHouseSize = 0;
	public static readonly int maxHouseSize = 6;
	private int currentHouseRating = 0;
	private int currentHouseCost = 0;
	private List<Room> currentRooms;

	void Awake () {
		SetupRoomToggles(1);
		currentRooms = new List<Room>();
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
		//UpdateCurrentRating(GameManager.instance.ReadCurrentRooms());
	}

	public void SetupRoomToggles(int sizeToAdd)
	{
		int offset = 0;
		VerticalLayoutGroup layoutGroup = roomListPanel.GetComponent<VerticalLayoutGroup>();
		Text roomSizeText = Instantiate (textPrefab) as Text;
		roomSizeText.transform.SetParent(roomListPanel.transform, false);
		roomSizeText.transform.Translate(new Vector2(0, offset));
		roomSizeText.text = "Size " + sizeToAdd + " rooms";
		offset -= roomSizeText.fontSize - layoutGroup.padding.top - layoutGroup.padding.bottom;
		for(int i = 0; i < rooms.Length; i++)
		{
			if(rooms[i].roomSize == sizeToAdd)
			{
				Toggle toggle = Instantiate (togglePrefab) as Toggle;
				toggle.transform.SetParent(roomListPanel.transform, false);
				toggle.transform.Translate(new Vector2(0, offset));
				Text toggleText = toggle.GetComponentInChildren<Text>();
				toggleText.text = rooms[i].roomName;
				toggle.isOn = false;

				offset -= toggleText.fontSize - layoutGroup.padding.top - layoutGroup.padding.bottom;
			}
		}
	}

    public void Size1ButtonPressed()
    {
		ClearRoomToggles();
		SetupRoomToggles(1);
    }

    public void Size2ButtonPressed()
    {
		ClearRoomToggles();
		SetupRoomToggles(2);
    }

    public void Size3ButtonPressed()
    {
		ClearRoomToggles();
		SetupRoomToggles(3);
    }

	public void ClearRoomToggles()
	{
		int count = roomListPanel.transform.childCount;
		for(int i = 0; i < count; i++)
		{
			GameObject.Destroy(roomListPanel.transform.GetChild(i).gameObject);
		}
	}

	private void UpdateGameManagerRooms()
	{
        GameManager.instance.ClearRooms();
        for (int i = 0; i < rooms.Length; i++)
        {
        	// if (roomToggles[i].isOn)
        	// {
        	// 	GameManager.instance.AddRooms(rooms[i]);
        	// }
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
			if (roomToggles[i].isOn) 
			{
				currentHouseSize += rooms[i].roomSize;
				currentHouseRating += rooms[i].roomRating;
            	GameManager.instance.AddRooms(rooms[i]);
        		numRooms++;
			}
		}
		if (currentHouseSize > maxHouseSize) 
		{
			Debug.Log(currentHouseSize);
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
	}*/
}
