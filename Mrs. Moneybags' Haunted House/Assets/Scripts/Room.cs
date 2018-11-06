using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
[CreateAssetMenu(menuName = "ScriptableObjects/Room")]
public class Room : ScriptableObject {
    public string roomName;
    public int roomSize;
    public int roomPrice;
    public int roomRating;
    public Sprite roomImage;
}
