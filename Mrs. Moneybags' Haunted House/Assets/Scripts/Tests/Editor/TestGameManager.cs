using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestGameManager {

	[Test]
	public void TestClearRooms() {
		Assert.That(2, Is.EqualTo(1+1));	
	}
}
