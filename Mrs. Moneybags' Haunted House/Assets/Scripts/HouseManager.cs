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
		if(!roomsInUse.Contains(roomToAdd) && allRooms.Contains(roomToAdd))
		{
			roomsInUse.Add(roomToAdd);
		}
		else if(roomsInUse.Contains(roomToAdd))
		{
			throw new System.Exception("Room already in list");
		}
		else if(!allRooms.Contains(roomToAdd))
		{
			throw new System.Exception("Room not available to Add");
		}
	}

	public void RemoveRoom(Room roomToRemove)
	{
		if(roomsInUse.Contains(roomToRemove))
		{
			roomsInUse.Remove(roomToRemove);
		}
		else
		{
			throw new System.Exception("Room not currently in use");
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
