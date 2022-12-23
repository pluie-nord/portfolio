using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonSerialization : MonoBehaviour
{
    public int currentHealth;
    public int currentEXP;
    public string dialogueState;

    [ContextMenu("Save")]
    public void Save()
    {
        string json = JsonUtility.ToJson(this);
        File.WriteAllText(Application.persistentDataPath + "/PotionData.json", json);
    }

}
