using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCharacterLoad : MonoBehaviour
{

    public List<GameObject> characterList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        int playerID = 0;

        foreach(int choice in PlayerManager.current.characterChoice)
        {
            characterList[choice].GetComponent<FightingCharacterScript>().id = playerID;
            characterList[choice].SetActive(true);
            playerID++;
        }
    }

    public void EndGame()
    {
        foreach(GameObject obj in characterList)
        {
            if (obj.activeSelf)
            {
                obj.GetComponent<FightingCharacterScript>().UpdateBP();
            }
        }
    }
}
