/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateRoom
{
    [MenuItem("Assets/Create/Room")]
    public static Room Create()
    {
        Room asset = ScriptableObject.CreateInstance<Room>();

        AssetDatabase.CreateAsset(asset, "Assets/Room.asset");
        AssetDatabase.SaveAssets();
        return asset;
    }
}*/