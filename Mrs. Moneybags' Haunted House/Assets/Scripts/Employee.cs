using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "ScriptableObjects/Employee")]
public class Employee : ScriptableObject {
    public string employeeName;
    public int employeePrice;
    public int employeeRating;
    public Sprite employeeImage;

}
