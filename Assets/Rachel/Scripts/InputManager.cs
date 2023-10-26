using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    public static InputManager current;
    ControlMaster controlMaster; //Our input script we created

    public List<PlayerControl> players = new List<PlayerControl>(); //List all of the players joining in - custom class

    public delegate void OnStartPressed(int id);
    public OnStartPressed onStartPressed;

    private bool startPressed;

    GameObject menuButtons;
   [SerializeField] private bool inMainMenu;

    // Start is called before the first frame update
    void Awake()
    {
        if (current == null)
        {
            current = this;
            DontDestroyOnLoad(gameObject);

            controlMaster = new ControlMaster(); //Assign and enable our class
            controlMaster.BaseControls.Join.performed += JoinPerformed; //Create functions for all the inputs, JoinPerformed needs function
            controlMaster.Enable();
        }
        else
        {
            Destroy(gameObject);
        }

        startPressed = false;
        inMainMenu = SceneManager.GetActiveScene().name == "Main_Menu";
    }

    private void JoinPerformed(InputAction.CallbackContext ctx)
    {
        // don't let more than 3 players join
        if(players.Count >= 3)
        {
            return;
        }

        // check if the player aready exists
        foreach (PlayerControl player in players)
        {
            if(player.inputDevice == ctx.control.device)
            {
                Debug.Log("Player Already Joined");
                return;
            }
        }

        // add 1 to player list
        if(onStartPressed != null)
        {
            onStartPressed.Invoke(players.Count);
        }

        //Player doesn't exist so we need to create them
        PlayerControl newPlayer = new PlayerControl();
        newPlayer.SetDevice(ctx.control.device, players.Count); //Set up all the inputs in this class, look down below

        players.Add(newPlayer); //Add the new player to our list
        //Let the gamemanager a new player has joined
        //GameManager.current.PlayerJoined(GetButtonPrompts(ctx.control.device.displayName), newPlayer.playerID);

        // hide "press start" note & show buttons upon joining if in main menu
        if (SceneManager.GetActiveScene().name == "Main_Menu" && !startPressed)
        {
            GameObject pressStart = GameObject.Find("Press_Start");
            pressStart.SetActive(false);
            GameObject menuButtons = GameObject.Find("Menu_UI");
            menuButtons.SetActive(true);
        }
    }
}

//This is our custom class for each player
//This is where we do all the inputs for individual players
//Ignore above stuff
[System.Serializable]
public class PlayerControl
{
    public InputDevice inputDevice; //This is the device they are using
    public int playerID; //The player index
    public ControlMaster controlMaster; //Controls we created, but are assigning it to only them
    InputUser inputUser; //Assigning them a input user

    public delegate void OnJump();
    public OnJump onJump;

    public delegate void OnLightAttack();
    public OnLightAttack onLightAttack;

    public delegate void OnHeavyAttack();
    public OnHeavyAttack onHeavyAttack;

    public float horizontal;

    public void SetDevice(InputDevice device, int id)
    {
        inputDevice = device;
        playerID = id;

        controlMaster = new ControlMaster();
        inputUser = InputUser.PerformPairingWithDevice(inputDevice);
        inputUser.AssociateActionsWithUser(controlMaster);
        controlMaster.Enable();
        AssignEvents();
    }

    //Assign all the functions in the game manager
    void AssignEvents()
    {        
        controlMaster.BaseControls.Jump.performed += Jump;
        controlMaster.BaseControls.Light_Attack.performed += Light_Attack;
        controlMaster.BaseControls.Heavy_Attack.performed += Heavy_Attack;
        controlMaster.BaseControls.Horizontal.performed += Walk;
        controlMaster.BaseControls.Horizontal.canceled += WalkCancelled;
    }

    private void WalkCancelled(InputAction.CallbackContext obj)
    {
        horizontal = 0;
    }

    private void Walk(InputAction.CallbackContext obj)
    {
        horizontal = obj.ReadValue<float>();
    }

    private void Heavy_Attack(InputAction.CallbackContext obj)
    {
        if (onHeavyAttack != null)
        {
            onHeavyAttack.Invoke();
        }
    }

    private void Light_Attack(InputAction.CallbackContext obj)
    {
        if (onLightAttack != null)
        {
            onLightAttack.Invoke();
        }
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (onJump != null)
        {
            onJump.Invoke();
        }
    }
}
