using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class InputManager : MonoBehaviour
{

    ControlMaster controlMaster; //Our input script we created

    [NonReorderable]
    List<PlayerControl> players = new List<PlayerControl>(); //List all of the players joining in - custom class

    float horizontal;

    //scriptable objects for different prompts
    public ButtonPrompts playstationInputs;
    public ButtonPrompts xboxInputs;

    // Start is called before the first frame update
    void Start()
    {
        controlMaster = new ControlMaster(); //Assign and enable our class
        controlMaster.BaseControls.Join.performed += JoinPerformed; //Create functions for all the inputs, JoinPerformed needs function
        controlMaster.BaseControls.Jump.performed += Jump;
        controlMaster.Enable();
    }

    //this is the function
    private void JoinPerformed(InputAction.CallbackContext ctx)
    {
        //This for loop is checking the player aready exists
        foreach (PlayerControl player in players)
        {
            if(player.inputDevice == ctx.control.device)
            {
                Debug.Log("Player Already Joined");
                return;
            }
        }

        //Player doesn't exist so we need to create them
        PlayerControl newPlayer = new PlayerControl();
        newPlayer.SetDevice(ctx.control.device, players.Count); //Set up all the inputs in this class, look down below

        players.Add(newPlayer); //Add the new player to our list
        //Let the gamemanager a new player has joined
        GameManager.current.PlayerJoined(GetButtonPrompts(ctx.control.device.displayName), newPlayer.playerID);
    }

    //This class just checks for the display name of the device and returns are scriptable object
    public ButtonPrompts GetButtonPrompts(string name)
    {
        name = name.ToLower();
        Debug.Log(name);
        ButtonPrompts prompts = playstationInputs;
        if(name.Contains("playstation") || name.Contains("dualshock") || name.Contains("wireless"))
        {
            prompts = playstationInputs;
        }
        else if(name.Contains("xbox"))
        {
            prompts = xboxInputs;
        }
        return prompts;
    }
    private void Jump(InputAction.CallbackContext obj)
    {
        Debug.Log("Player Jumped");
        Debug.Log(obj.control.device.displayName);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = controlMaster.BaseControls.Horizontal.ReadValue<float>();
    }
}

//This is are custom class for each player
[System.Serializable]
public class PlayerControl
{
    public InputDevice inputDevice; //This is the device they are using
    public int playerID; //The player index
    ControlMaster playerControls; //Controls we created, but are assigning it to only them
    InputUser inputUser; //Assigning them a input user

    public void SetDevice(InputDevice device, int id)
    {
        inputDevice = device;
        playerID = id;

        playerControls = new ControlMaster();
        inputUser = InputUser.PerformPairingWithDevice(inputDevice);
        inputUser.AssociateActionsWithUser(playerControls);
        playerControls.Enable();
        AssignEvents();
    }

    //Assign all the functions in the game manager
    void AssignEvents()
    {
        playerControls.BaseControls.North.performed += ctx => GameManager.current.ButtonPressed(playerID, 0);
        playerControls.BaseControls.East.performed += ctx => GameManager.current.ButtonPressed(playerID, 1);
        playerControls.BaseControls.South.performed += ctx => GameManager.current.ButtonPressed(playerID, 2);
        playerControls.BaseControls.West.performed += ctx => GameManager.current.ButtonPressed(playerID, 3);
        playerControls.BaseControls.Join.performed += ctx => GameManager.current.PlayerReady(playerID);
    }
}
