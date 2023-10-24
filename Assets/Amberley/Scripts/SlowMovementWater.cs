using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMovementWater : MonoBehaviour
{
    public GameObject swampWater;
    public float baseSpeed;

    public void Start()
    {
        baseSpeed = Amber_GM.managerOfGame.playerSpeed;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Amber_GM.managerOfGame.playerSpeed = Amber_GM.managerOfGame.playerSpeed / 2;
            Debug.Log("Player speed set to:" + Amber_GM.managerOfGame.playerSpeed);
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player")
        {
            Amber_GM.managerOfGame.playerSpeed = baseSpeed;
            Debug.Log("Player speed set to:" + Amber_GM.managerOfGame.playerSpeed);
        }
    }

}
