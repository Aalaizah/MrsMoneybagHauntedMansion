using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class TestEmployeeManager {

	[Test]
	public void TestGetAllEmployees() 
	{
		Employee employee1 = new Employee();
		Employee employee2 = new Employee();
		System.Collections.Generic.List<Employee> employees = new System.Collections.Generic.List<Employee>{employee1, employee2};
		EmployeeManager manager = new EmployeeManager(employees);

		Assert.IsInstanceOf<System.Collections.Generic.List<Employee>>(manager.GetAllEmployees());
	}

	[Test]
	public void TestHireEmployeeEmptyList() 
	{
		Employee employee1 = new Employee();
		Employee employee2 = new Employee();
		System.Collections.Generic.List<Employee> employees = new System.Collections.Generic.List<Employee>{employee2};
		EmployeeManager manager = new EmployeeManager(employees);

		manager.HireEmployee(employee1);
		System.Collections.Generic.List<Employee> hiredEmployees = manager.GetEmployedEmployees();

		Assert.That(hiredEmployees, Has.Count.EqualTo(1));
	}
}
