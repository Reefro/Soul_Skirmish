using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    float startTime;
    public float timeRemaining;
    public bool timerRunning;
    public TextMeshProUGUI timerText;
    public Image timerImage;
    public TextMeshProUGUI announcer;
    public bool roundStart;

    // Start is called before the first frame update
    void Start()
    {
        startTime = 120f;
        timeRemaining = 3f;
        timerRunning = false;
        roundStart = false;
        StartRound();
    }

    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0f)
            {
                timeRemaining -= Time.deltaTime;
                // display corner time
                if (!roundStart)
                {
                    DisplayTime(timeRemaining);
                }
                // display red middle timer on 3 (this does not execute at the same time as corner, pls fix)
                if (timeRemaining <= 3)
                {
                    Countdown(timeRemaining);
                }
            }
            else // when timer gets to 0
            {
                // reset timer to 2min upon starting round, and set announcer text
                if (roundStart)
                {
                    announcer.text = string.Format("FIGHT!");
                    roundStart = false;
                    timeRemaining = startTime;
                    timerRunning = true;
                    Invoke("RemoveText", 1.0f);
                }
                else
                {
                    timeRemaining = 0;
                    timerRunning = false;
                    announcer.text = string.Format("END!");
                }
            }
        }
    }

    void RemoveText()
    {
        announcer.text = "";
    }

    private void StartRound()
    {
        roundStart = true;
        timerRunning = true;
    }

    private void Countdown(float t)
    {
        //announcer.text = string.Format("{0:0}...", t);
        announcer.text = Mathf.FloorToInt(t + 1).ToString();
    }

    private void DisplayTime(float t)
    {
        float min = Mathf.FloorToInt(t / 60);
        float sec = Mathf.FloorToInt(t % 60);
        sec += 1;
        timerText.text = string.Format("{0:0}:{1:00}", min, sec);
        timerImage.fillAmount = t / startTime;
    }
}
