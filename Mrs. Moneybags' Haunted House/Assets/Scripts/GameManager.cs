using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour {

	public Text houseRatingText;
	public Text currentMoneyText;
	public static GameManager instance = null;
	public Text instructionText;
	public GameObject[] size1Panels;
	public GameObject[] size2Panels;
	public GameObject[] size3Panels;
    public List<GameObject> activatedPanels;

	private int houseRating = 0;
	private int currentMoney = 0;
	private int houseCost = 0;
    private List<Room> currentRooms;
    private int numSize1Active;
    private int numSize2Active;
    private int numSize3Active;
    private int nextSize1ToActivate;
    private int nextSize2ToActivate;
    private int nextSize3ToActivate;
    private List<Room> size1RoomsToActivate;
    private List<Room> size2RoomsToActivate;
    private List<Room> size3RoomsToActivate;

    void Awake()
	{
		if(instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);

		currentRooms = new List<Room>();
        size1RoomsToActivate = new List<Room>();
        size2RoomsToActivate = new List<Room>();
        size3RoomsToActivate = new List<Room>();

        size1Panels[0].GetComponent<Image>().color = new Color(255, 255, 255, 100);

    }

	// Use this for initialization
	void Start () {
		currentMoneyText.text = "$" + currentMoney.ToString();
		houseRatingText.text = "Haunted House Rating: " + houseRating.ToString();
	}

	public void PlaySeasonButtonPressed()
	{
        Debug.Log("Play Day Button Pressed");
        currentMoney += CalculateMoneyMade();
		currentMoneyText.text = "$" + currentMoney.ToString();
	}

	public void SetHouseRating(int value)
	{
		houseRating = value;
		houseRatingText.text = "Haunted House Rating: " + houseRating.ToString();
	}

	public void SetHouseCost(int value)
	{
		houseCost = value;
	}

	public void SetInstructionTextEnabled(bool value)
	{
		instructionText.enabled = value;
	}

	public void SetInstructionText(string value)
	{
		instructionText.enabled = true;
		instructionText.text = value;
	}

    public List<Room> ReadCurrentRooms()
    {
        return currentRooms;
    }

    public void AddRooms(Room room)
    {
        currentRooms.Add(room);
    }

    public void ClearRooms()
    {
        currentRooms.Clear();
    }

    public void SetRoomLocations()
    {
        DisableRooms(size1Panels);
        DisableRooms(size2Panels);
        DisableRooms(size3Panels);

        ClearRoomImageLists(size1RoomsToActivate);
        ClearRoomImageLists(size2RoomsToActivate);
        ClearRoomImageLists(size3RoomsToActivate);

        nextSize1ToActivate = 0;
        nextSize2ToActivate = 0;
        nextSize3ToActivate = 0;

        GetSizeRoomCounts(currentRooms);
        nextSize2ToActivate += (numSize3Active * 2);
        nextSize1ToActivate += Convert.ToInt32(numSize2Active * 1.5) + (numSize3Active * 3); // 1.5 for size 6 house TODO clean up for other sizes
        ActivateRooms(size3Panels, size3RoomsToActivate, nextSize3ToActivate, numSize3Active);
        ActivateRooms(size2Panels, size2RoomsToActivate, nextSize2ToActivate, numSize2Active);
        ActivateRooms(size1Panels, size1RoomsToActivate, nextSize1ToActivate, numSize1Active);
    }

    private void ActivateRooms(GameObject[] panelsArray, List<Room> listToActivateRoomsFrom, int locationToStartActivating, int numPanelsActive)
    {
    	int imageLoc = 0;
    	for(int i = locationToStartActivating; i < (locationToStartActivating + numPanelsActive); i++)
    	{
    		panelsArray[i].GetComponent<Image>().sprite = listToActivateRoomsFrom[imageLoc].roomImage;
    		panelsArray[i].SetActive(true);
    		imageLoc++;
    	}
    }

    private void DisableRooms(GameObject[] roomsToDisable)
    {
        for (int i = 0; i < roomsToDisable.Length; i++)
        {
            roomsToDisable[i].SetActive(false);
        }
    }

    private void ClearRoomImageLists(List<Room> activeRoomImageList)
    {
        activeRoomImageList.Clear();
    }

    public void GetSizeRoomCounts(List<Room> rooms)
    {
        numSize1Active = 0;
        numSize2Active = 0;
        numSize3Active = 0;
        foreach (Room room in currentRooms)
        {
            switch (room.roomSize)
            {
                case 1:
                    size1RoomsToActivate.Add(room);
                    numSize1Active++;
                    break;
                case 2:
                    size2RoomsToActivate.Add(room);
                    numSize2Active++;
                    break;
                case 3:
                    size3RoomsToActivate.Add(room);
                    numSize3Active++;
                    break;
            }
        }
    }

    public int CalculateMoneyMade()
    {
        int moneyMade = houseRating - houseCost;
        return moneyMade;
    }
}
