using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurderousCollider : MonoBehaviour
{
    public Transform deathSpawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Void"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("Get void'd, punk!");
            this.gameObject.transform.position = deathSpawnPoint.position;
            this.gameObject.SetActive(true);
        }
    }


}