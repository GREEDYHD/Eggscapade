using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public Text countdown;

    public float timeLeft = 10.0f;
    public float videoCountDown = 3.15f;

    public bool hasVideoStarted = false;
    public bool hasVideoFinished = false;
    public bool playGameMusic = false;
    private bool isEnded;

    public GameObject clock;
    public GameObject moviePlane;

    public AudioSource gameMusic;
    public AudioClip gameMusicClip;

    public GameObject WinPlane;

    private float leaderboardCountdown = 3;


    void Start()
    {
        isEnded = false; //Stops everyhting once game has finished
    }
	
    void EndLevel()
    {   
        //Stop Players
        //Stop HUD
        //Stop Eggs
        //Stop Farmers
        //Stop Countdown
        //Initialise End Screen
        WinPlane.SetActive(true);
        WinPlane.GetComponentInParent<WinScreen>().ActivateEndScreen();
    }

    public void Update()
    {
        if (!isEnded)
        {
            if (hasVideoStarted)
            {
                videoCountDown -= Time.deltaTime;
            }
            if (videoCountDown <= 0)
            {
                moviePlane.SetActive(false);
                hasVideoFinished = true;
            }
            
            if (hasVideoFinished)
            {
                clock.SetActive(true);
                
                timeLeft -= Time.deltaTime;
            }
            
            if (timeLeft <= 0.0f)
            {
                Debug.Log("Time Up");
                isEnded = true;
                WinPlane.SetActive(true);
                WinPlane.GetComponentInParent<WinScreen>().ActivateEndScreen();
                countdown.color = new Color (0,0,0,0);
                //EndLevel();
            } else
            {
                if (timeLeft < 10)
                {
                    countdown.color = Color.red;
                    countdown.text = "0" + (int)timeLeft;
                }
                else
                {
                    countdown.text = "" + (int)timeLeft;
                }
            }
        } 
        else
        {
            leaderboardCountdown -= Time.deltaTime;
            if(leaderboardCountdown <= 0)
            {
             
                WinPlane.GetComponentInParent<WinScreen>().ActivateLeaderboard();
            }
        }
    }
}