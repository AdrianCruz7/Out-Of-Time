using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] PlayerController playerController;

    void Start()
    {
            
    }

    void Update()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        DisplayTime();  
    }

    void DisplayTime()
    {
        float minutes = Mathf.FloorToInt(playerController.playerTime / 60);
        float seconds = Mathf.FloorToInt(playerController.playerTime % 60);

        time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
