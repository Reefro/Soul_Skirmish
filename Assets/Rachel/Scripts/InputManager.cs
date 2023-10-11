using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class InputManager : MonoBehaviour
{

    public static InputManager current;
    ControlMaster controlMaster; //Our input script we created

    public List<PlayerControl> players = new List<PlayerControl>(); //List all of the players joining in - custom class

    public delegate void OnStartPressed(int id);
    public OnStartPressed onStartPressed;

    // Start is called before the first frame update
    void Start()
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
    }

    //this is the function
    private void JoinPerformed(InputAction.CallbackContext ctx)
    {
        if(players.Count >= 4)
        {
            return;
        }

        //This for loop is checking the player aready exists
        foreach (PlayerControl player in players)
        {
            if(player.inputDevice == ctx.control.device)
            {
                Debug.Log("Player Already Joined");
                return;
            }
        }

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
    }
}

//This is are custom class for each player
[System.Serializable]
public class PlayerControl
{
    public InputDevice inputDevice; //This is the device they are using
    public int playerID; //The player index
    ControlMaster controlMaster; //Controls we created, but are assigning it to only them
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
