using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public FightingCharacterScript thisPlayer;
    public int damage;
    public Vector2 hitRange;

    private void OnEnable()
    {
        RaycastHit2D[] hitList = Physics2D.BoxCastAll(transform.position, hitRange, 0, Vector2.zero);
        for (int i = 0; i < hitList.Length; i++)
        {
            if (hitList[i].collider.CompareTag("Player"))
            {
                if (hitList[i].collider.gameObject != thisPlayer.gameObject)
                {
                    hitList[i].collider.gameObject.GetComponent<FightingCharacterScript>().TakeDamage(damage, thisPlayer);
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent red cube at the transforms position
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, hitRange);
    }

}
