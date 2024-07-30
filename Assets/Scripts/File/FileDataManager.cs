using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Windows;

public class FileDataManager : MonoBehaviour
{
    public static FileDataManager Instance { get; private set; }
    FileData fileData;
    string saveFilePath;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        saveFilePath = Application.persistentDataPath + "/playerData.json";
        LoadData();
    }

    public void AddTimeShards(int amount)
    {
        fileData.timeShards += amount;
        Debug.Log(fileData.timeShards);
        SaveData();
    }

    public void SpendTimeShards(int amount)
    {
        if (fileData.timeShards > amount)
        {
            fileData.timeShards -= amount;
            Debug.Log(fileData.timeShards);
            SaveData();
        }
        else
        {
            Debug.Log("Not enough shards");
        }
    }

    void SaveData()
    {
        string json = JsonUtility.ToJson(fileData);
        System.IO.File.WriteAllText(saveFilePath, json);
    }

    void LoadData()
    {
        if (System.IO.File.Exists(saveFilePath))
        {
            string json = System.IO.File.ReadAllText(saveFilePath);
            fileData = JsonUtility.FromJson<FileData>(json);
        }
        else
        {
            fileData = new FileData();
        }
    }
}
