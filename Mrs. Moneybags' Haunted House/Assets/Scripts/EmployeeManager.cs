using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeManager {

	private List<Employee> employees;
	private List<Employee> employedEmployees;

	public EmployeeManager(List<Employee> allEmployees)
	{
		employees = allEmployees;
		employedEmployees = new List<Employee>();
	}

	public void HireEmployee(Employee employeeToHire)
	{
		employedEmployees.Add(employeeToHire);
	}

	public void FireEmployee(Employee employeeToFire)
	{
		employedEmployees.Remove(employeeToFire);
	}

	public List<Employee> GetAllEmployees()
	{
		return employees;
	}

	public List<Employee> GetEmployedEmployees()
	{
		return employedEmployees;
	}
}
