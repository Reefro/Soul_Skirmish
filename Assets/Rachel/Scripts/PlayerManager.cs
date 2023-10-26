using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager current;
    public List<int> characterChoice = new List<int>() { 0, 0, 0 };
    //PlayerManager.current.characterChoice[IndexOfPlayer] to get the characters selection

    private void Awake()
    {
        if (current == null)
        {
            current = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerOneCharacter(int characterIndex)
    {
        characterChoice[0] = characterIndex;
    }
    public void SetPlayerTwoCharacter(int characterIndex)
    {
        characterChoice[1] = characterIndex;
    }
    public void SetPlayerThreeCharacter(int characterIndex)
    {
        characterChoice[2] = characterIndex;
    }
}
