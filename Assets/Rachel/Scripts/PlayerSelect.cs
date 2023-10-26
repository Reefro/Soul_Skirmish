using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public int playerIndex;
    bool playerJoined;

    public List<GameObject> characterList = new List<GameObject>();
    int characterSelectIndex;

    private void Start()
    {
        StartCoroutine(CheckForInput());
    }

    IEnumerator CheckForInput()
    {
        while (InputManager.current.players.Count -1 >= playerIndex)
        {
            //Player hasn't joined yet
            yield return null;
        }
    }

    void AssignInputs()
    {

    }


    public void Left()
    {

    }

   public void Right()
    {

    }
}
