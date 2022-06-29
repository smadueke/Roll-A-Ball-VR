using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Timer : MonoBehaviour
{
    public float timeElapsed;
    public bool timeIsRunning;
    public TextMeshProUGUI timeText;
    private TimeSpan timeCount;
    public String textTime;

    public static Timer timerInstance;

    private void Awake()
    {
        timeText.text = "Time: 00:00:00";
        timeIsRunning = true;
        timeElapsed = 0f;
        StartCoroutine(time());

        timerInstance = this;
    }

    void StopTime()
    {
        timeIsRunning = false;
    }

    private IEnumerator time()
    {
        while (timeIsRunning)
        {
            timeElapsed += Time.deltaTime;
            timeCount = TimeSpan.FromSeconds(timeElapsed);
            //Debug.Log(time);
            textTime = "Time: " + timeCount.ToString("mm':'ss'.'ff");
            timeText.text = textTime;

            yield return null;
        }
        
    } 
}
