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
        startTime = 10f;
        timeRemaining = 3f;
        timerRunning = false;
        roundStart = false;
        StartRound();
    }

    void FixedUpdate()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.fixedDeltaTime;
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
                // remove text from middle after 1 sec
                if (timeRemaining == startTime - 1)
                {
                    announcer.text = string.Empty;
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

    private void StartRound()
    {
        roundStart = true;
        timerRunning = true;
    }

    private void Countdown(float t)
    {
        announcer.text = string.Format("{0:0}...", t);
    }

    private void DisplayTime(float t)
    {
        float min = Mathf.FloorToInt(t / 60);
        float sec = Mathf.FloorToInt(t % 60);
        timerText.text = string.Format("{0:0}:{1:00}", min, sec);
        timerImage.fillAmount = t / startTime;
    }
}
