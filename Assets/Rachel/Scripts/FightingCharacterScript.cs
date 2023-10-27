using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class FightingCharacterScript : MonoBehaviour
{
    public int id;

    public GameObject characterObj;
    public Animator anim;
    public GameObject hitbox;
    public GameObject pow;
    public bool inputsDisabled;

    public float HP; // health points
    public int BP; // battle points
    public int SP; // soul points
    public float maxHP;

    private GameObject healthBar;
    private GameObject SPText;

    public FightingCharacterScript lastAttacker; // stores last attacker, so we know who got the kill upon death

    private float initSpeed;
    public float movementSpeed; //player movement speed
    public float jumpHeight; //player jump height
    public float horizontal; //horizontal variable, used to check whether the player's input is positive or negative for movement
    public float rotation; //rotation variable, for rotating the character model on the y axis
    public bool hasDblJump = true;

    [SerializeField] private Rigidbody2D rigidBody; //referencing the rigid body on my character model, in order to access it in c#
    [SerializeField] private Transform groundCheck; //referencing the groundCheck emptyObject on my character model in order to access it in c#
    [SerializeField] private LayerMask groundLayer; //referencing the ground Layer in the layers in order to access it in c#

    public Kaiju kaiju;

    private void Awake()
    {
        SetStats();
    }

    // Start is called before the first frame update
    void Start()
    {
        initSpeed = 10;
        hitbox.SetActive(false);
        pow.SetActive(false);
        inputsDisabled = false;
        horizontal = 0f;
        if (anim == null)
        {
            anim = characterObj.GetComponent<Animator>();
        }
        lastAttacker = null;

        InputManager.current.players[id].onJump += Jump;
        InputManager.current.players[id].onLightAttack += Light_Attack;
        InputManager.current.players[id].onHeavyAttack += Heavy_Attack;

        HP = 100; // health points
        BP = 0; // battle points
        SP = 0; // soul points
        maxHP = 100;
    }

    private void OnDisable()
    {
        InputManager.current.players[id].onJump -= Jump;
        InputManager.current.players[id].onLightAttack -= Light_Attack;
        InputManager.current.players[id].onHeavyAttack -= Heavy_Attack;
    }

    public void UpdateBP()
    {
        PlayerManager.current.characterBP[id] = BP;
    }

    // Update is called once per frame
    void Update()
    {
        // horizontal value when using keyboard input
        //horizontal = Input.GetAxisRaw("Horizontal");
        if (inputsDisabled == false)
        {
            horizontal = InputManager.current.players[id].horizontal;
            rigidBody.velocity = new Vector3(horizontal * movementSpeed, rigidBody.velocity.y);
        }

        //// jumping with keyboard input
        //if (Input.GetButtonDown("Jump") && OnGround())
        //{
        //    rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
        //}
        //// double jumping with keyboard input
        //if (Input.GetButtonDown("Jump") && !OnGround() && hasDblJump)
        //{
        //    hasDblJump = false;
        //    rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight / 1.5f);
        //}

        // reset double jump when touching ground
        if (OnGround())
        {
            hasDblJump = true;
        }

        FlipCharacter();

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

        healthBar.GetComponent<Image>().fillAmount = (HP/maxHP) / 2f; // half full circle = full health bar
        SPText.GetComponent<TextMeshProUGUI>().text = "SP:\n" + SP;
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

    public void EndRecoil()
    {
        inputsDisabled = false;
        pow.SetActive(false);
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
            anim.SetTrigger("Light");
        }
    }

    private void Heavy_Attack()
    {
        if (!inputsDisabled)
        {
            // disable other inputs
            inputsDisabled = true;
            anim.SetTrigger("Heavy");
        }
    }

    public bool OnGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); //check the positon of groundCheck empty object on player character and if it meets the ground layer
    }

    private void FlipCharacter()
    {
        //Vector3 position = transform.position;

        if (horizontal < 0) //if the player is moving to the left, negative on the x axis
        {
            rotation = 180f; //set rotation to 180
            transform.rotation = Quaternion.Euler(0f, rotation, 0f); //transforms the character rotation to flip the model to the left, without using scale to invert the model
        }
        else if (horizontal > 0) //if the player is moving to the right, positive on the x axis
        {
            rotation = 0f; //set rotation to 0
            transform.rotation = Quaternion.Euler(0f, rotation, 0f); //transforms the character rotation to flip the model to the right, without using scale to invert the model
        }

    }

    public void TakeDamage(int damage, FightingCharacterScript otherPlayer) 
    {
        HP -= damage;
        inputsDisabled = true;
        if (HP > 0) // player is still alive
        {
            anim.SetTrigger("Recoiling");
            pow.SetActive(true);
            lastAttacker = otherPlayer;
        }
        else // player is dead
        {
            characterObj.GetComponent<Renderer>().enabled = false;
            StartCoroutine(KillPlayer(otherPlayer));
        }
    }

    public void SetStats()
    {
        if (id == 0)
        {
            healthBar = GameObject.Find("P1_Healthbar");
            SPText = GameObject.Find("P1_SP");
        }
        else if (id == 1)
        {
            healthBar = GameObject.Find("P2_Healthbar");
            SPText = GameObject.Find("P2_SP");
        }
        else if (id == 2)
        {
            healthBar = GameObject.Find("P3_Healthbar");
            SPText = GameObject.Find("P3_SP");
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        /*
        if (col.gameObject.tag == "Attack")
        {
            HP -= 20;
            if (HP > 0) // player is still alive
            {
                anim.SetTrigger("Recoiling");
                inputsDisabled = true;
                pow.SetActive(true);
            }
            else // player is dead
            {
                lastAttacker = col.transform.parent.gameObject; // set last attacker as the hitbox's parent

                //lastAttacker.SetPoints(SP); // how do we make this work? unity doesn't know that the last attacker will have the same script

                characterObj.SetActive(false); //deactivate (player is dead, do not kill game object)
                healthBar.gameObject.SetActive(false);
            }
        }
        */

        if (col.gameObject.tag == "Water")
        {
            movementSpeed = movementSpeed / 2;
        }

        if (col.gameObject.tag == "Boundary")
        {
            StartCoroutine(KillPlayer(lastAttacker));
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Attack")
        {
            pow.SetActive(false);
        }
        if (col.gameObject.tag == "Water")
        {
            movementSpeed = initSpeed;
        }
    }

    public void SetPoints(int soulPts)
    {
        // if the player you killed has no SP, gain 1 SP
        if (soulPts == 0)
        {
            SP++;
        }
        // if player has more than 0 SP, gain that many SP
        else
        {
            SP += soulPts;
        }
        // add 100 BP per kill
        BP += 100;
    }

    public void BecomeKaiju()
    {
        kaiju.SetPlayer(id);
        kaiju.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    // kill this player, give points to last attacker and respawn this player in centre stage
    IEnumerator KillPlayer(FightingCharacterScript otherPlayer)
    {
        // healthBar.gameObject.SetActive(false); // change this to a 3sec respawn timer visual
        otherPlayer.SetPoints(SP);
        // move player to centre
        characterObj.transform.position = new Vector3(0f, 8f, 0f);
        // turn off gravity
        yield return new WaitForSeconds(3f);
        // reset player health
        HP = maxHP;
        // enable player
        characterObj.GetComponent<Renderer>().enabled = true;
        // allow inputs
        inputsDisabled = false;
    }
} 