using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{
    public List<GameObject> characters = new List<GameObject>();

    private void Start()
    {
        InputManager.current.onStartPressed += TurnOnCharacter;
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
