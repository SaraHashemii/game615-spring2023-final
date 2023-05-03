using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int healthMax;

    [SerializeField] protected bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        InitialVariables();
    }


    public virtual void InitialVariables()
    {
        healthMax = 10;
        SetHealth(healthMax);
        isDead = false;
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void SetHealth(int value)
    {
        health = value;
        CheckHealth();
    }

    public virtual void CheckHealth()
    {
        if (health <= 0)
        {
            health = 0;
            isDead = true;
            Die();
        }

        if (health >= healthMax)
        {
            health = healthMax;
        }
    }

    public virtual void Die()
    {
        isDead = true;
    }

    public virtual void TakeDamage(int damage)
    {
        int DamagedHealth = health - damage;
        SetHealth(DamagedHealth);

    }


}
