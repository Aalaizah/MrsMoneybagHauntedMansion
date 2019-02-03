using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	// TODO Organize these better
	[SerializeField] private GameObject houseUpdatePanel;
	[SerializeField] private GameObject gameUIPanel;
	[SerializeField] private Text currentHouseSizeText;
	[SerializeField] private Text errorText;
	[SerializeField] private GameObject roomUpdatePanel;
	[SerializeField] private GameObject employeeUpdatePanel;
	[SerializeField] private Text infoText;
	[SerializeField] private Toggle togglePrefab;
	[SerializeField] private GameObject employeePanel;
	[SerializeField] private GameObject roomPanel;
	[SerializeField] private List<Employee> theEmployees;
	[SerializeField] private List<Room> theRooms;
	[SerializeField] private Button fireHireButton;
	private List<Employee> currentlySelectedToHireEmployees;
	private List<Employee> currentlySelectedToFireEmployees;
	private List<Room> currentlySelectedRooms;
	private EmployeeManager employeeManager;
	private HouseManager houseManager;
	private List<Toggle> currentToggles;
	private List<Employee> currentToggleEmployees;
	private List<Room> currentToggleRooms;

	private int currentHouseSize = 0;
	private int maxHouseSize = 6;
	private int currentHouseRating = 0;
	private int currentHouseCost = 0;
	private int employeeCost = 0;
	private bool toHireScreen;

	void Awake () {
		employeeManager = new EmployeeManager(theEmployees);
		houseManager = new HouseManager(theRooms);
		toHireScreen = true;
		currentlySelectedToFireEmployees = new List<Employee>();
		currentlySelectedToHireEmployees = new List<Employee>();
		currentlySelectedRooms = new List<Room>();
		currentToggles = new List<Toggle>();
		currentToggleEmployees = new List<Employee>();
		currentToggleRooms = new List<Room>();
		SetupEmployeeToggles(true);
	}

	private void CalculateEmployeeCost()
	{
		List<Employee> currentlyEmployed = employeeManager.GetEmployedEmployees();
		employeeCost = 0;
		for(int i = 0; i < currentlyEmployed.Count; i++)
		{
			employeeCost += currentlyEmployed[i].employeePrice;
		}
		GameManager.instance.SetHouseCost(employeeCost);
	}

	private void SetupEmployeeToggles(bool toHire)
	{
		int offset = 0;
		List<Employee> currentlyEmployed = employeeManager.GetEmployedEmployees();
		if(!toHire)
		{
			infoText.text = "Select Employees To Fire";
			for(int i = 0; i < theEmployees.Count; i++)
			{
				if(currentlyEmployed.Contains(theEmployees[i]))
				{
					Toggle toggle = Instantiate (togglePrefab) as Toggle;
					toggle.transform.SetParent(employeePanel.transform, false);
					toggle.transform.Translate(new Vector2(0, offset));
					Text toggleText = toggle.GetComponentInChildren<Text>();
					toggleText.text = theEmployees[i].employeeName;
					toggle.isOn = false;

					currentToggles.Add(toggle);
					currentToggleEmployees.Add(theEmployees[i]);

					VerticalLayoutGroup layoutGroup = employeePanel.GetComponent<VerticalLayoutGroup>();
					offset -= toggleText.fontSize - layoutGroup.padding.top - layoutGroup.padding.bottom;
				}
			}
		}
		else
		{
			infoText.text = "Select Employees to Hire";
			for(int i = 0; i < theEmployees.Count; i++)
			{
				if(!currentlyEmployed.Contains(theEmployees[i]))
				{
					Toggle toggle = Instantiate (togglePrefab) as Toggle;
					toggle.transform.SetParent(employeePanel.transform, false);
					toggle.transform.Translate(new Vector2(0, offset));
					Text toggleText = toggle.GetComponentInChildren<Text>();
					toggleText.text = theEmployees[i].employeeName;
					toggle.isOn = false;

					currentToggles.Add(toggle);
					currentToggleEmployees.Add(theEmployees[i]);

					VerticalLayoutGroup layoutGroup = employeePanel.GetComponent<VerticalLayoutGroup>();
					offset -= toggleText.fontSize - layoutGroup.padding.top - layoutGroup.padding.bottom;
				}
			}
		}
	}

	public void HideButtonPressed()
	{
		houseUpdatePanel.SetActive (false);
		gameUIPanel.SetActive (true);
		GameManager.instance.SetInstructionTextEnabled(false);
        GameManager.instance.SetRoomLocations();
	}

	public void ShowButtonPressed()
	{
		houseUpdatePanel.SetActive (true);
	}

	public void SwapHouseUpdatePanels()
	{
		roomUpdatePanel.SetActive(!roomUpdatePanel.activeSelf);
		employeeUpdatePanel.SetActive(!employeeUpdatePanel.activeSelf);
		if(toHireScreen)
		{
			AddToSelectedEmployeeList(currentlySelectedToHireEmployees);
			fireHireButton.GetComponentInChildren<Text>().text = "Hire";
		}
		else
		{
			AddToSelectedEmployeeList(currentlySelectedToFireEmployees);
			fireHireButton.GetComponentInChildren<Text>().text = "Fire";
		}
		currentToggles.Clear();
		AddToSelectedHouseList();
		Size1ButtonPressed();
	}

	// TODO Update for house/room info
	public void SaveButtonPressed()
	{
		if(!toHireScreen && currentlySelectedToHireEmployees.Count > 0)
		{
			AddToSelectedEmployeeList(currentlySelectedToHireEmployees);
			fireHireButton.GetComponentInChildren<Text>().text = "Fire";
		}
		else if(toHireScreen && currentlySelectedToFireEmployees.Count > 0)
		{
			AddToSelectedEmployeeList(currentlySelectedToFireEmployees);
			fireHireButton.GetComponentInChildren<Text>().text = "Hire";
		}
		for(int i = 0; i < currentlySelectedToHireEmployees.Count; i++)
		{
			employeeManager.HireEmployee(currentlySelectedToHireEmployees[i]);
			Debug.Log("Hired: " + currentlySelectedToHireEmployees[i].employeeName);
		}
		for(int i = 0; i < currentlySelectedToFireEmployees.Count; i++)
		{
			employeeManager.FireEmployee(currentlySelectedToFireEmployees[i]);
			Debug.Log("Fired: " + currentlySelectedToFireEmployees[i].employeeName);
		}
		for(int i = 0; i < currentlySelectedRooms.Count; i++)
		{
			houseManager.AddRoom(currentlySelectedRooms[i]);
			Debug.Log("Room Added: " + currentlySelectedRooms[i].roomName);
		}
		SetupEmployeeToggles(toHireScreen);
		ClearToggles(employeePanel);
		ClearToggles(roomPanel);
		CalculateEmployeeCost();
		GameManager.instance.SetRoomLocations();
	}

	public void FireHireButtonPressed()
	{
		if(toHireScreen)
		{
			AddToSelectedEmployeeList(currentlySelectedToHireEmployees);
			fireHireButton.GetComponentInChildren<Text>().text = "Fire";
		}
		else
		{
			AddToSelectedEmployeeList(currentlySelectedToFireEmployees);
			fireHireButton.GetComponentInChildren<Text>().text = "Hire";
		}
		ClearToggles(employeePanel);
		toHireScreen = !toHireScreen;
		SetupEmployeeToggles(toHireScreen);
	}

	private void AddToSelectedEmployeeList(List<Employee> listToAddTo)
	{
		for(int i = 0; i <= currentToggles.Count - 1; i++)
		{
			Toggle currentToggle = currentToggles[i];
			if(currentToggle.isOn)
			{
				listToAddTo.Add(currentToggleEmployees[i]);
			}
		}
		currentToggles.Clear();
		currentToggleEmployees.Clear();
	}

	private void ClearToggles(GameObject panel) {
		Debug.Log("Panel: " + panel.name);
		int count = panel.transform.childCount;
		for(int i = count - 1; i >= 0; i--) {
			GameObject.Destroy (panel.transform.GetChild(i).gameObject);
		}
		currentToggles.Clear();
		currentToggleEmployees.Clear();
		currentToggleRooms.Clear();
	}
	
	// TODO Actual implementation
	private void CalculateHouseRating()
	{
		GameManager.instance.SetHouseRating(5);
	}

	private void SetupRoomToggles(int sizeToAdd)
	{
		int offset = 0;
		VerticalLayoutGroup layoutGroup = roomPanel.GetComponent<VerticalLayoutGroup>();
		//Text roomSizeText = Instantiate (textPrefab) as Text;
		//roomSizeText.transform.SetParent(roomListPanel.transform, false);
		//roomSizeText.transform.Translate(new Vector2(0, offset));
		//roomSizeText.text = "Size " + sizeToAdd + " rooms";
		//offset -= roomSizeText.fontSize - layoutGroup.padding.top - layoutGroup.padding.bottom;
		for(int i = 0; i < theRooms.Count; i++)
		{
			if(theRooms[i].roomSize == sizeToAdd)
			{
				Toggle toggle = Instantiate (togglePrefab) as Toggle;
				toggle.transform.SetParent(roomPanel.transform, false);
				toggle.transform.Translate(new Vector2(0, offset));
				Text toggleText = toggle.GetComponentInChildren<Text>();
				toggleText.text = theRooms[i].roomName;
				toggle.isOn = false;

				currentToggles.Add(toggle);
				currentToggleRooms.Add(theRooms[i]);

				offset -= toggleText.fontSize - layoutGroup.padding.top - layoutGroup.padding.bottom;
			}
		}
	}


	public void Size1ButtonPressed()
	{
		AddToSelectedHouseList();
		ClearToggles(roomPanel);
		SetupRoomToggles(1);
	}

	public void Size2ButtonPressed()
	{
		AddToSelectedHouseList();
		ClearToggles(roomPanel);
		SetupRoomToggles(2);
	}

	public void Size3ButtonPressed()
	{
		AddToSelectedHouseList();
		ClearToggles(roomPanel);
		SetupRoomToggles(3);
	}

	private void AddToSelectedHouseList()
	{
		for(int i = 0; i <= currentToggles.Count - 1; i++)
		{
			Debug.Log(currentToggleRooms.Count);
			Debug.Log(currentToggleRooms[i]);
			Toggle currentToggle = currentToggles[i];
			Room room = currentToggleRooms[i];
			if(currentToggle.isOn && !currentlySelectedRooms.Contains(room))
			{
				currentlySelectedRooms.Add(room);
			}
		}
		currentToggles.Clear();
		currentToggleRooms.Clear();
	}
}
