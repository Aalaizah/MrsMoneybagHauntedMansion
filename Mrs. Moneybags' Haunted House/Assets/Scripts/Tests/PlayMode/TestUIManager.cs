using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestUIManager {

	[Test]
	public void TestCalculateEmployeeCostWhenNoEmployees() 
	{
		// Should return 0
		Assert.Fail("Not yet written");
	}

	[Test]
	public void TestCalculateEmployeeCostWhenOneOrMoreEmployees(){
		// should return the added cost of all employees that are hired
		Assert.Fail("Not yet written");
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator TestSetupEmployeeTogglesWithNoneHired() {
		Assert.Fail("Not yet written");
		yield return null;
	}

	[UnityTest]
	public IEnumerator TestSetupEmployeeTogglesWithOneOrMoreHired()
	{
		Assert.Fail("Not yet written");
		yield return null;
	}
}
