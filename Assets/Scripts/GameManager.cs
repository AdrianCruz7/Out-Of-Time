using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float playerTimeTest = 100;
    [SerializeField] TextMeshProUGUI time;

    // Update is called once per frame
    void Update()
    {
        DisplayTime();

        if(playerTimeTest > 0)
        {
            playerTimeTest -= Time.deltaTime;
        }    
    }

    void DisplayTime()
    {
        float minutes = Mathf.FloorToInt(playerTimeTest / 60);
        float seconds = Mathf.FloorToInt(playerTimeTest % 60);

        time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
