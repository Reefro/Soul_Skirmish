using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    public List<string> nextScene = new List<string>();

    private void Start()
    {
        StartCoroutine(CheckForPlayers());
    }

    IEnumerator CheckForPlayers()
    {
        bool waitingforplayers = true;
        List<int> playerList = PlayerManager.current.characterChoice;
        while (waitingforplayers)
        {
            bool playersReady = true;
            foreach (int player in playerList)
            {
                if (player == -1)
                {
                    playersReady = false;
                }
            }
            if (playersReady)
            {
                waitingforplayers = false;
            }
            yield return null;
        }

        StartGame();
    }

    [ContextMenu("StartGame")]
    void StartGame()
    {
        int randomArena = Random.Range(0, nextScene.Count);
        SceneManager.LoadScene(nextScene[randomArena]);
    }
}
