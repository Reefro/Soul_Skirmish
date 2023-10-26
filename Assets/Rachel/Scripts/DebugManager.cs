using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public List<GameObject> characterPrefabs = new List<GameObject>();
    public List<GameObject> characters = new List<GameObject>();

    private void Start()
    {
        SpawnCharacters();
        InputManager.current.onStartPressed += TurnOnCharacter;
    }

    private void SpawnCharacters()
    {
        for(int i = 0; i < 3; i++)
        {
            GameObject player = Instantiate(characterPrefabs[PlayerManager.current.characterChoice[i]], transform.position, transform.rotation);
        
        }
    }

    private void OnDisable()
    {
        InputManager.current.onStartPressed -= TurnOnCharacter;
    }

    void TurnOnCharacter(int id)
    {
        characters[id].SetActive(true);
    }
}
