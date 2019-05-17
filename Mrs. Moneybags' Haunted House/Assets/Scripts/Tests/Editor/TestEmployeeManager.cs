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
		System.Collections.Generic.List<Employee> employees = 
			new System.Collections.Generic.List<Employee>{employee1, employee2};
		EmployeeManager manager = new EmployeeManager(employees);

		System.Collections.Generic.List<Employee> allEmployees = manager.GetAllEmployees();
		Assert.IsInstanceOf<System.Collections.Generic.List<Employee>>(allEmployees);
		Assert.That(allEmployees, Has.Count.EqualTo(2));
	}

	[Test]
	public void TestGetHiredEmployeesWhenNoneAreHired()
	{
		Employee employee1 = new Employee();
		Employee employee2 = new Employee();
		System.Collections.Generic.List<Employee> employees = 
			new System.Collections.Generic.List<Employee>{employee1, employee2};
		EmployeeManager manager = new EmployeeManager(employees);

		System.Collections.Generic.List<Employee> hiredEmployees = manager.GetHiredEmployees();

		Assert.That(hiredEmployees, Has.Count.EqualTo(0));
	}

	[Test]
	public void TestHireEmployeeEmptyList() 
	{
		Employee employee1 = new Employee();
		Employee employee2 = new Employee();
		System.Collections.Generic.List<Employee> employees = 
			new System.Collections.Generic.List<Employee>{employee1, employee2};
		EmployeeManager manager = new EmployeeManager(employees);

		manager.HireEmployee(employee1);
		System.Collections.Generic.List<Employee> hiredEmployees = manager.GetHiredEmployees();

		Assert.That(hiredEmployees, Has.Count.EqualTo(1));
	}

	[Test]
	public void TestGetHiredEmployeesWhenMoreThanZeroAreEmployed()
	{
		Employee employee1 = new Employee();
		Employee employee2 = new Employee();
		System.Collections.Generic.List<Employee> employees = 
			new System.Collections.Generic.List<Employee>{employee1, employee2};
		EmployeeManager manager = new EmployeeManager(employees);

		manager.HireEmployee(employee1);
		manager.HireEmployee(employee2);
		System.Collections.Generic.List<Employee> hiredEmployees = manager.GetHiredEmployees();

		Assert.That(hiredEmployees, Has.Count.EqualTo(2));
	}

	[Test]
	public void TestHireEmployeeNotAvailableForHire()
	{
		Employee employee1 = new Employee();
		Employee employee2 = new Employee();
		Employee employee3 = new Employee();
		System.Collections.Generic.List<Employee> employees = 
			new System.Collections.Generic.List<Employee>{employee2};
		EmployeeManager manager = new EmployeeManager(employees);

		Assert.Catch(delegate {manager.HireEmployee(employee1);});
		System.Collections.Generic.List<Employee> hiredEmployees = manager.GetHiredEmployees();

		Assert.That(hiredEmployees, Has.Count.EqualTo(0));
	}

	[Test]
	public void TestHireEmployeeAlreadyEmployed()
	{
		Employee employee1 = new Employee();
		Employee employee2 = new Employee();
		Employee employee3 = new Employee();
		System.Collections.Generic.List<Employee> employees = 
			new System.Collections.Generic.List<Employee>{employee1, employee2, employee3};
		EmployeeManager manager = new EmployeeManager(employees);
		
		manager.HireEmployee(employee1);

		Assert.Catch(delegate {manager.HireEmployee(employee1);});
		System.Collections.Generic.List<Employee> hiredEmployees = manager.GetHiredEmployees();
		Assert.That(hiredEmployees, Has.Count.EqualTo(1));

	}

	[Test]
	public void TestFireEmployeeEmptyList()
	{
		Employee employee1 = new Employee();
		Employee employee2 = new Employee();
		Employee employee3 = new Employee();
		System.Collections.Generic.List<Employee> employees = 
			new System.Collections.Generic.List<Employee>{employee1, employee2, employee3};
		EmployeeManager manager = new EmployeeManager(employees);

		Assert.Catch(delegate {manager.FireEmployee(employee1);});
		System.Collections.Generic.List<Employee> hiredEmployees = manager.GetHiredEmployees();
		Assert.That(hiredEmployees, Has.Count.EqualTo(0));
	}

	[Test]
	public void TestFireEmployeeListWithEmployeeContained()
	{
		Employee employee1 = new Employee();
		Employee employee2 = new Employee();
		Employee employee3 = new Employee();
		System.Collections.Generic.List<Employee> employees = 
			new System.Collections.Generic.List<Employee>{employee1, employee2, employee3};
		EmployeeManager manager = new EmployeeManager(employees);

		manager.HireEmployee(employee1);
		manager.HireEmployee(employee2);
		manager.FireEmployee(employee1);
		System.Collections.Generic.List<Employee> hiredEmployees = manager.GetHiredEmployees();

		Assert.That(hiredEmployees, Has.Count.EqualTo(1));

	}
}
