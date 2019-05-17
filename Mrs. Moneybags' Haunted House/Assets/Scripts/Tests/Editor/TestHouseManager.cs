using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class TestHouseManager 
{
	[Test]
	public void TestGetAllRooms() 
	{
		Room room1 = new Room();
		Room room2 = new Room();
		Room room3 = new Room();
		System.Collections.Generic.List<Room> rooms = new System.Collections.Generic.List<Room>{room1, room2, room3};
		HouseManager manager = new HouseManager(rooms);

		System.Collections.Generic.List<Room> allRooms = manager.GetAllRooms();
		Assert.IsInstanceOf<System.Collections.Generic.List<Room>>(allRooms);
		Assert.That(allRooms, Has.Count.EqualTo(3));
	}

	[Test]
	public void TestGetRoomsInUseWhenNoneAreInUse()
	{
		Room room1 = new Room();
		Room room2 = new Room();
		Room room3 = new Room();
		System.Collections.Generic.List<Room> rooms = new System.Collections.Generic.List<Room>{room1, room2, room3};
		HouseManager manager = new HouseManager(rooms);

		System.Collections.Generic.List<Room> roomsInUse = manager.GetRoomsInUse();

		Assert.That(roomsInUse, Has.Count.EqualTo(0));
	}

	[Test]
	public void TestAddRoomEmptyList() 
	{
		Room room1 = new Room();
		Room room2 = new Room();
		Room room3 = new Room();
		System.Collections.Generic.List<Room> rooms = new System.Collections.Generic.List<Room>{room1, room2, room3};
		HouseManager manager = new HouseManager(rooms);

		manager.AddRoom(room1);
		System.Collections.Generic.List<Room> roomsInUse = manager.GetRoomsInUse();

		Assert.That(roomsInUse, Has.Count.EqualTo(1));
	}

	[Test]
	public void TestGetRoomsInUseWhenMoreThanZeroAreInUse()
	{
		Room room1 = new Room();
		Room room2 = new Room();
		Room room3 = new Room();
		System.Collections.Generic.List<Room> rooms = new System.Collections.Generic.List<Room>{room1, room2, room3};
		HouseManager manager = new HouseManager(rooms);

		manager.AddRoom(room1);
		manager.AddRoom(room2);
		System.Collections.Generic.List<Room> roomsInUse = manager.GetRoomsInUse();

		Assert.That(roomsInUse, Has.Count.EqualTo(2));
	}

	[Test]
	public void TestAddRoomNotAvailableForUse()
	{
		Room room1 = new Room();
		Room room2 = new Room();
		Room room3 = new Room();
		System.Collections.Generic.List<Room> rooms = new System.Collections.Generic.List<Room>{room1, room2};
		HouseManager manager = new HouseManager(rooms);

		Assert.Catch(delegate {manager.AddRoom(room3);});
		System.Collections.Generic.List<Room> roomsInUse = manager.GetRoomsInUse();

		Assert.That(roomsInUse, Has.Count.EqualTo(0));
	}

	[Test]
	public void TestAddRoomAlreadyInUse()
	{
		Room room1 = new Room();
		Room room2 = new Room();
		Room room3 = new Room();
		System.Collections.Generic.List<Room> rooms = new System.Collections.Generic.List<Room>{room1, room2, room3};
		HouseManager manager = new HouseManager(rooms);

		manager.AddRoom(room3);
		Assert.Catch(delegate {manager.AddRoom(room3);});
		System.Collections.Generic.List<Room> roomsInUse = manager.GetRoomsInUse();

		Assert.That(roomsInUse, Has.Count.EqualTo(1));

	}

	[Test]
	public void TestRemoveRoomEmptyList()
	{
		Room room1 = new Room();
		Room room2 = new Room();
		Room room3 = new Room();
		System.Collections.Generic.List<Room> rooms = 
			new System.Collections.Generic.List<Room>{room1, room2, room3};
		HouseManager manager = new HouseManager(rooms);

		Assert.Catch(delegate {manager.RemoveRoom(room1);});
		System.Collections.Generic.List<Room> roomsInUse = manager.GetRoomsInUse();
		Assert.That(roomsInUse, Has.Count.EqualTo(0));
	}

	[Test]
	public void TestRemoveRoomListWithRoomsContained()
	{
		Room room1 = new Room();
		Room room2 = new Room();
		Room room3 = new Room();
		System.Collections.Generic.List<Room> rooms = new System.Collections.Generic.List<Room>{room1, room2, room3};
		HouseManager manager = new HouseManager(rooms);

		manager.AddRoom(room1);
		manager.AddRoom(room2);
		manager.RemoveRoom(room1);
		System.Collections.Generic.List<Room> roomsInUse = manager.GetRoomsInUse();

		Assert.That(roomsInUse, Has.Count.EqualTo(1));
	}
}
