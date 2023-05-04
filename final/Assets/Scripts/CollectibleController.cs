using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleController : MonoBehaviour
{
    public PlayerUIController playerUIController;


    public int playerCount;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Debug.Log("collider");
            playerCount++;
            playerUIController.UpdateScore(playerCount);
            Destroy(other.gameObject);

        }

    }
}