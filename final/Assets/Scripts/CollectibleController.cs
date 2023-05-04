using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleController : MonoBehaviour
{
    [SerializeField] PlayerUIController playerUIController;
    [SerializeField] AudioSource collectSound;

    public void Start()
    {
        this.collectSound.playOnAwake = false;
    }

    public int playerCount;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            collectSound.Play();
            playerCount++;
            playerUIController.UpdateScore(playerCount);
            
            Destroy(other.gameObject);

        }

    }
}