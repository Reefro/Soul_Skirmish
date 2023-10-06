using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace soulskirmish_greyboxtest
{
   public class PlayerController : MonoBehaviour
    {

        public float movementSpeed = 16f; //player movement speed
        public float jumpHeight = 1f; //player jump height
        public float horizontal; //horizontal variable, used to check whether the player's input is positive or negative for movement
        public float rotation; //rotation variable, for rotating the character model on the y axis
        public bool hasDblJump = true;

        [SerializeField] private Rigidbody2D rigidBody; //referencing the rigid body on my character model, in order to access it in c#
        [SerializeField] private Transform groundCheck; //referencing the groundCheck emptyObject on my character model in order to access it in c#
        [SerializeField] private LayerMask groundLayer; //referencing the ground Layer in the layers in order to access it in c#

        void Update()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            rigidBody.velocity = new Vector3(horizontal * movementSpeed, rigidBody.velocity.y);

            if (Input.GetButtonDown("Jump") && OnGround())
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
            }

            if (Input.GetButtonDown("Jump") && !OnGround() && hasDblJump == true)
            {
                hasDblJump = false;
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight / 1.5f);
            }

            if (OnGround())
            {
                hasDblJump = true;
            }

            FlipCharacter();

            //Debug.Log(transform.position.x);
        }

        //void OnCollisionEnter()
        //{
        //    if (rigidBody.tag == "Ground")
        //    {
                
        //    }
        //}

        private bool OnGround()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); //check the positon of groundCheck empty object on player character and if it meets the ground layer
        }

        private void FlipCharacter()
        {
            //Vector3 position = transform.position;

            if (horizontal == -1) //if the player is moving to the left, negative on the x axis
            {
                rotation = -180f; //set rotation to 180
                transform.rotation = Quaternion.Euler(0f, rotation, 0f); //transforms the character rotation to flip the model to the left, without using scale to invert the model
            }
            else if (horizontal == 1) //if the player is moving to the right, positive on the x axis
            {
                rotation = 0f; //set rotation to 0
                transform.rotation = Quaternion.Euler(0f, rotation, 0f); //transforms the character rotation to flip the model to the right, without using scale to invert the model
            }

        }

        //private void DblJump()
        //{
        //    if (OnGround() == true)
        //    {
        //        hasDblJump = true;
        //    }
        //}
    } 
}


