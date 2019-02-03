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
}
