using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FightingCharacterScript : MonoBehaviour
{
    //public KeyCode attackKeyCode;
    public GameObject characterObj;
    Animator controllerAnim;
    public GameObject hitbox;
    public GameObject pow;

    ControlMaster controlMaster; //Our input script we created

    public bool inputsDisabled;

    //public bool flipX = true;
    //public bool flipY;
    //public bool flipZ;

    //public Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        hitbox.SetActive(false);
        pow.SetActive(false);
        inputsDisabled = false;
        horizontal = 0f;
        controllerAnim = characterObj.GetComponent<Animator>();
        controlMaster = new ControlMaster(); //Assign and enable our class
        //controlMaster.BaseControls.Join.performed += JoinPerformed;
        
        // Create functions for all the inputs
        controlMaster.BaseControls.Jump.performed += Jump;
        controlMaster.BaseControls.Light_Attack.performed += Light_Attack;
        controlMaster.BaseControls.Heavy_Attack.performed += Heavy_Attack;
        controlMaster.BaseControls.Horizontal.performed += Walk;
        // enable inputs
        controlMaster.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // horizontal value when using keyboard input
        horizontal = Input.GetAxisRaw("Horizontal");

        // horizontal movement
        rigidBody.velocity = new Vector3(horizontal * movementSpeed, rigidBody.velocity.y);

        //// jumpiing with keyboard input
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
            controllerAnim.SetBool("Walking", false);
        }
        // set walking when horizontal movement and on ground
        else if (horizontal != 0 && OnGround())
        {
            controllerAnim.SetBool("Walking", true);
        }
        // enable input & disable hitbox when attack animation has ended
        if (controllerAnim.GetCurrentAnimatorStateInfo(0).IsName("Light"))
        {
            inputsDisabled = false;
            hitbox.SetActive(false);
            pow.SetActive(false);
        }
    }

    // when jump button is pressed on controller (gamepad south)
    private void Jump(InputAction.CallbackContext obj)
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
    private void Light_Attack(InputAction.CallbackContext obj)
    {
        if (!inputsDisabled)
        {
            // enable punch animation
            controllerAnim.SetTrigger("Punching");
            // enable punch hitbox
            hitbox.SetActive(true);
            // enable pow hitbox
            pow.SetActive(true);
            // disable other inputs
            inputsDisabled = true;
        }
    }

    private void Heavy_Attack(InputAction.CallbackContext obj)
    {
        if (!inputsDisabled)
        {
            controllerAnim.SetTrigger("Punching");
        }
    }

    private void Walk(InputAction.CallbackContext obj)
    {   
        if (!inputsDisabled)
        {
            horizontal = controlMaster.BaseControls.Horizontal.ReadValue<float>();
        }
        else
        {
            horizontal = 0f;
        }
    }

    public float movementSpeed = 16f; //player movement speed
    public float jumpHeight = 1f; //player jump height
    public float horizontal; //horizontal variable, used to check whether the player's input is positive or negative for movement
    public float rotation; //rotation variable, for rotating the character model on the y axis
    public bool hasDblJump = true;

    [SerializeField] private Rigidbody2D rigidBody; //referencing the rigid body on my character model, in order to access it in c#
    [SerializeField] private Transform groundCheck; //referencing the groundCheck emptyObject on my character model in order to access it in c#
    [SerializeField] private LayerMask groundLayer; //referencing the ground Layer in the layers in order to access it in c#

    public bool OnGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); //check the positon of groundCheck empty object on player character and if it meets the ground layer
    }

    private void FlipCharacter()
    {
        //Vector3 position = transform.position;

        if (horizontal < 0) //if the player is moving to the left, negative on the x axis
        {
            rotation = -90f; //set rotation to 180
            transform.rotation = Quaternion.Euler(0f, rotation, 0f); //transforms the character rotation to flip the model to the left, without using scale to invert the model
        }
        else if (horizontal > 0) //if the player is moving to the right, positive on the x axis
        {
            rotation = 90f; //set rotation to 0
            transform.rotation = Quaternion.Euler(0f, rotation, 0f); //transforms the character rotation to flip the model to the right, without using scale to invert the model
        }

        //if (mesh == null) return;
        //Vector3[] verts = mesh.vertices;
        //for (int i = 0; i < verts.Length; i++)
        //{
        //    Vector3 c = verts[i];
        //    if (flipX) c.x *= -1;
        //    if (flipY) c.y *= -1;
        //    if (flipZ) c.z *= -1;
        //    verts[i] = c;
        //}

        //mesh.vertices = verts;
        //if (flipX ^ flipY ^ flipZ) FlipNormals();

    }

    //private void FlipNormals()
    //{
    //    int[] tris = mesh.triangles;
    //    for (int i = 0; i < tris.Length / 3; i++)
    //    {
    //        int a = tris[i * 3 + 0];
    //        int b = tris[i * 3 + 1];
    //        int c = tris[i * 3 + 2];
    //        tris[i * 3 + 0] = c;
    //        tris[i * 3 + 1] = b;
    //        tris[i * 3 + 2] = a;
    //    }
    //    mesh.triangles = tris;
    //}

    //private void DblJump()
    //{
    //    if (OnGround() == true)
    //    {
    //        hasDblJump = true;
    //    }
    //}
} 

