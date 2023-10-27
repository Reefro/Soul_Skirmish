using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class placement : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;

    public Transform firstPos;
    public Transform secondPos;
    public Transform thirdPos;

    private int score1;
    private int score2;
    private int score3;

    public int firstScore;
    public int secondScore;
    public int thirdScore;

    public TextMeshProUGUI firstScoreText;
    public TextMeshProUGUI secondScoreText;
    public TextMeshProUGUI thirdScoreText;
    public TextMeshProUGUI winningPlayerNumber;

    public void Start()
    {
        score1 = PlayerManager.current.characterBP[0];
        score2 = PlayerManager.current.characterBP[1];
        score3 = PlayerManager.current.characterBP[2];

        CheckDraw();
        CheckFirstScore();
        CheckSecondScore();
        CheckThirdScore();

        MoveFirstPlace();
        MoveSecondPlace();
        MoveThirdPlace();
    }

    public void CheckFirstScore()
    {
        if (score1 > score2 && score1 > score3)
        {
            firstScore = score1;
            winningPlayerNumber.text = string.Format("1");
            firstScoreText.text = string.Format(firstScore.ToString());
            //Debug.Log("score1 is first");
        }

        if (score2 > score1 && score2 > score3)
        {
            firstScore = score2;
            winningPlayerNumber.text = string.Format("2");
            firstScoreText.text = string.Format(firstScore.ToString());
            //Debug.Log("score2 is first");
        }

        if (score3 > score1 && score3 > score2)
        {
            firstScore = score3;
            winningPlayerNumber.text = string.Format("3");
            firstScoreText.text = string.Format(firstScore.ToString());
            //Debug.Log("score3 is first");
        }
    }

    public void CheckSecondScore()
    {
        if (score1 > score2 ^ score1 > score3)
        {
            secondScore = score1;
            secondScoreText.text = string.Format(secondScore.ToString());
            //Debug.Log("score1 is second");
        }

        if (score2 > score1 ^ score2 > score3)
        {
            secondScore = score2;
            secondScoreText.text = string.Format(secondScore.ToString());
            //Debug.Log("score2 is second");
        }

        if (score3 > score1 ^ score3 > score2)
        {
            secondScore = score3;
            secondScoreText.text = string.Format(secondScore.ToString());
            //Debug.Log("score3 is second");
        }
    }

    public void CheckThirdScore()
    {
        if (score1 < score2 && score1 < score3)
        {
            thirdScore = score1;
            thirdScoreText.text = string.Format(thirdScore.ToString());
            //Debug.Log("score1 is third");
        }

        if (score2 < score1 && score2 < score3)
        {
            thirdScore = score2;
            thirdScoreText.text = string.Format(thirdScore.ToString());
            //Debug.Log("score2 is third");
        }

        if (score3 < score1 && score3 < score2)
        {
            thirdScore = score3;
            thirdScoreText.text = string.Format(thirdScore.ToString());
            //Debug.Log("score3 is third");
        }
    }

    public void CheckDraw()
    {
        if (score1 == score2)
        {
            int coin = Random.Range(0, 2);
            if (coin == 1)
            {
                score1 += 1;
                Debug.Log("DRAW - Score 1 increased");
            }
            else
            {
                score2 += 1;
                Debug.Log("DRAW - Score 2 increased");
            }
        }

        if (score1 == score3)
        {
            int coin = Random.Range(0, 2);
            if (coin == 1)
            {
                score1 += 1;
                Debug.Log("DRAW - Score 1 increased");
            }
            else
            {
                score3 += 1;
                Debug.Log("DRAW - Score 3 increased");
            }
        }

        if (score2 == score3)
        {
            int coin = Random.Range(0, 2);
            if (coin == 1)
            {
                score2 += 1;
                Debug.Log("DRAW - Score 2 increased");
            }
            else
            {
                score3 += 1;
                Debug.Log("DRAW - Score 3 increased");
            }
        }
    }

    public void MoveFirstPlace()
    {
        if (firstScore == score1)
        {
            player1.transform.position = firstPos.position;
            Debug.Log("P1 in 1st position");
        }

        if (firstScore == score2)
        {
            player2.transform.position = firstPos.position;
            Debug.Log("P2 in 1st position");
        }

        if (firstScore == score3)
        {
            player3.transform.position = firstPos.position;
            Debug.Log("P3 in 1st position");
        }
    }

    public void MoveSecondPlace()
    {
        if (secondScore == score1)
        {
            player1.transform.position = secondPos.position;
            Debug.Log("P1 in 2nd position");
        }

        if (secondScore == score2)
        {
            player2.transform.position = secondPos.position;
            Debug.Log("P2 in 2nd position");
        }

        if (secondScore == score3)
        {
            player3.transform.position = secondPos.position;
            Debug.Log("P3 in 2nd position");
        }
    }

    public void MoveThirdPlace()
    {
        if (thirdScore == score1)
        {
            player1.transform.position = thirdPos.position;
            Debug.Log("P1 in 3rd position");
        }

        if (thirdScore == score2)
        {
            player2.transform.position = thirdPos.position;
            Debug.Log("P2 in 3rd position");
        }

        if (thirdScore == score3)
        {
            player3.transform.position = thirdPos.position;
            Debug.Log("P3 in 3rd position");
        }
    }
}
