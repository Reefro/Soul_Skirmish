using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingCharacterScript : MonoBehaviour
{
    public KeyCode attackKeyCode;
    public GameObject characterObj;
    Animator controllerAnim;

    public bool isWalking;


    // Start is called before the first frame update
    void Start()
    {
        controllerAnim = characterObj.GetComponent<Animator>();
        isWalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Light_Attack"))
        {
            LightAttack();
        }
    }

    [ContextMenu("Light Attack")]

    public void LightAttack()
    {
        controllerAnim.SetTrigger("Punching");
    }

    public void SetWalking()
    {

    }
}
