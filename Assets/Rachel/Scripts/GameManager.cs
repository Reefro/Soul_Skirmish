using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager current;
    public List<bool> playersReady = new List<bool>();
    //public List<BlockManager> blockManagers = new List<BlockManager>();
    public bool gameStarted;
    bool gameEnded;
    
    void Start()
    {
        current = this;
    }

    public void PlayerJoined(ButtonPrompts prompts, int id)
    {
        playersReady.Add(false);
        //blockManagers[id].LoadPlayer(prompts);
    }

    public void PlayerReady(int id)
    {
        playersReady[id] = !playersReady[id];
        foreach(bool player in playersReady)
        {
            if(player == false)
            {
                return;
            }
        }

        if (gameEnded)
            return;

        gameStarted = true;
        Invoke("EndGame", 10f);
    }

    public void EndGame()
    {
        gameEnded = true;
        gameStarted = false;
    }

    public void ButtonPressed(int playerID, int ButtonID)
    {
        //blockManagers[playerID].CheckBlock(ButtonID);
    }
}
