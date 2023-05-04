using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthController : HealthManager
{
    private PlayerUIController playerUIController;
    [SerializeField] GameManager gm;

    [SerializeField] private int damage;

    // Start is called before the first frame update
    void Start()
    {
        playerUIController = GetComponent<PlayerUIController>();
        InitialVariables();


    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void InitialVariables()
    {
        healthMax = 50;
        SetHealth(healthMax);
        isDead = false;
        damage = 1;

       
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
        playerUIController.UpdateHealthBar(health, healthMax);
    }

    public override void Die()
    {
        base.Die();
        gm.HandleEndScene();
       
    }
}
