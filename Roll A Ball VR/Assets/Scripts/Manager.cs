using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{

    public GameObject endLevelMenu;
    public TextMeshProUGUI results;
    private bool LevelOver = false;
    private int finalScore;
    public AudioSource[] audios;
    public static Manager manager;
    public float falloff;
    public GameObject[] buttons;
    public bool VRMode;
    private bool pause;
    public int count;
    public GameObject pickUpParent;



    private void Awake()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        audios[0].Play();
        manager = this;

        count = 0;
        foreach (Transform t in pickUpParent.transform)
        {
            if (t.gameObject.activeSelf)
            {
                count++;
            }
        }
    }

    private void Update()
    {

        if (Movement.move.score == 0 & LevelOver == false)
        {
            Timer.timerInstance.timeIsRunning = false;
            Movement.move.speed = 0;
            if (Timer.timerInstance.timeElapsed > count * 10)
            {
                finalScore = 0;
            }
            else
            {
                finalScore = (int)(count * 1000 - Timer.timerInstance.timeElapsed);
            }
            results.text = "\nFinal Score: " + finalScore + "\nCompleted In: " + Timer.timerInstance.textTime;
            endLevelMenu.SetActive(true);
            buttons[0].SetActive(false);
            buttons[1].SetActive(true);
            audios[0].volume -= falloff;
            audios[1].Play();
            LevelOver = true;

        }

    }

    public void VRModeOn()
    {
        VRMode = true;
    }
    public void VRModeOff()
    {
        VRMode = false;
    }

    public void PauseResume()
    {
        if (!pause)
        {
            Time.timeScale = 0f;
            pause = true;
        }
        else
        {
            Time.timeScale = 1f;
            pause = false;
        }
    }
}
