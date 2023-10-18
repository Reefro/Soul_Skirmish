using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code by Amberley
public class MovingPlatform : MonoBehaviour
{
    public GameObject movingPlatform;
    public Transform positionLeft;
    public Transform positionRight;
    public Vector3 targetPosition;
    public float platformSpeed;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = positionRight.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, positionLeft.position) < 0.1f)
        {
            targetPosition = positionRight.position;
        }

        if (Vector3.Distance(transform.position, positionRight.position) < 0.1f)
        {
            targetPosition = positionLeft.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, platformSpeed * Time.deltaTime);
    }
}
