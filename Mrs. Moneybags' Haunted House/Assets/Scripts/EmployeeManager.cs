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
		if(!employedEmployees.Contains(employeeToHire) && employees.Contains(employeeToHire))
		{
			employedEmployees.Add(employeeToHire);
		}
		else if(employedEmployees.Contains(employeeToHire))
		{
			throw new System.Exception("Employee already employed");
		}
		else if(!employees.Contains(employeeToHire))
		{
			throw new System.Exception("Employee not in list of available employees");
		}
	}

	public void FireEmployee(Employee employeeToFire)
	{
		if(employedEmployees.Contains(employeeToFire))
		{
			employedEmployees.Remove(employeeToFire);
		}
		else
		{
			throw new System.Exception("Employee not employed");
		}
	}

	public List<Employee> GetAllEmployees()
	{
		return employees;
	}

	public List<Employee> GetHiredEmployees()
	{
		return employedEmployees;
	}
}
