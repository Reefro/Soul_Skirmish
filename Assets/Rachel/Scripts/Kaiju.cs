using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Kaiju : MonoBehaviour
{
    public int id;

    public GameObject characterObj;
    Animator anim;
    public GameObject hitbox;
    public GameObject pow;
    public bool inputsDisabled;

    public float HP; // health points
    public float maxHP;

    public Image healthBar;

    public float movementSpeed; //player movement speed
    public float jumpHeight; //player jump height
    public float horizontal; //horizontal variable, used to check whether the player's input is positive or negative for movement
    public float rotation; //rotation variable, for rotating the character model on the y axis
    public bool hasDblJump = true;

    [SerializeField] private Rigidbody2D rigidBody; //referencing the rigid body on my character model, in order to access it in c#
    [SerializeField] private Transform groundCheck; //referencing the groundCheck emptyObject on my character model in order to access it in c#
    [SerializeField] private LayerMask groundLayer; //referencing the ground Layer in the layers in order to access it in c#

    // Start is called before the first frame update
    public void SetPlayer(int playerID)
    {
        id = playerID;

        hitbox.SetActive(false);
        pow.SetActive(false);
        inputsDisabled = false;
        horizontal = 0f;
        anim = characterObj.GetComponent<Animator>();

        InputManager.current.players[id].onJump += Jump;
        InputManager.current.players[id].onLightAttack += Light_Attack;
        InputManager.current.players[id].onHeavyAttack += Heavy_Attack;

        HP = 100; // health points
        maxHP = 100;
    }

    private void OnDisable()
    {
        InputManager.current.players[id].onJump -= Jump;
        InputManager.current.players[id].onLightAttack -= Light_Attack;
        InputManager.current.players[id].onHeavyAttack -= Heavy_Attack;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputsDisabled == false)
        {
            horizontal = InputManager.current.players[id].horizontal;
            rigidBody.velocity = new Vector3(horizontal * movementSpeed, rigidBody.velocity.y);
        }

        // stop walking when no horizontal movement or off ground
        if (horizontal == 0 || !OnGround())
        {
            anim.SetBool("Walking", false);
        }
        // set walking when horizontal movement and on ground
        else if (horizontal != 0 && OnGround())
        {
            anim.SetBool("Walking", true);
        }

        healthBar.fillAmount = (HP / maxHP) / 2f; // half full circle = full health bar
    }

    public void StartAnim()
    {
        // enable punch hitbox
        hitbox.SetActive(true);
    }
    public void EndAnim()
    {
        inputsDisabled = false;
        hitbox.SetActive(false);
    }

    // when jump button is pressed on controller (gamepad south)
    private void Jump()
    {
        if (!inputsDisabled)
        {
            // jump when on ground
            if (OnGround())
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
            }
            // if not on ground and double jump is available
            if (!OnGround() && hasDblJump == true)
            {
                // make double jump unavailable until on ground again
                hasDblJump = false;
                // jump a shorter height
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight / 1.5f);
            }
        }
    }

    // when light attack button is pressed on controller (gamepad west)
    private void Light_Attack()
    {
        if (!inputsDisabled)
        {
            // disable other inputs
            inputsDisabled = true;
            // enable punch animation
            anim.SetTrigger("Punching");
        }
    }

    private void Heavy_Attack()
    {
        if (!inputsDisabled)
        {
            anim.SetTrigger("Punching");
        }
    }

    public bool OnGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); //check the positon of groundCheck empty object on player character and if it meets the ground layer
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Attack")
        {
            HP = HP - 20;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Attack")
        {
            pow.SetActive(false);
        }
    }
}
