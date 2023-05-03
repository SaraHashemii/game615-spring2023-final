using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : HealthManager
{
    private PlayerUIController playerUIController;

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

        //attackSpeed = 2f;
        //canAttack = true;
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
        playerUIController.UpdateHealthBar(health, healthMax);
    }
}
