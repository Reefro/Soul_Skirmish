using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code by Amberley

public class Amber_GM : MonoBehaviour
{
    public static Amber_GM managerOfGame;

    public List<GameObject> playerList;
    

    public float round1Timer;
    public float round2Timer;

    //public bool playerKaiju;
    public float playerSpeed;
    public int playerHP;
    public int kaijuHP;
    private int playersouls;
    private int playerpoints;


    private void Awake()
    {
        managerOfGame = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
