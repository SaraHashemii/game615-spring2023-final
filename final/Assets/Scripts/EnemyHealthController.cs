using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : HealthManager
{

    [SerializeField] GameObject collectable;
    //[SerializeField] ParticleSystem collectableParticle;

    public float attackSpeed;

    [SerializeField] private bool canAttack;
    [SerializeField] private int damage;


    public void Start()
    {
        InitialVariables();
    }

    public override void CheckHealth()
    {
        base.CheckHealth();

    }

    public override void InitialVariables()
    {
        healthMax = 3;
        SetHealth(healthMax);
        isDead = false;
        damage = 5;

        attackSpeed = 1.5f;

    }


    public void HandleDamge(HealthManager damageAmount)
    {
        damageAmount.TakeDamage(damage);

    }


    public override void Die()
    {
        base.Die();
        Vector3 carrotSpawnPos = new Vector3(this.transform.position.x, this.transform.position.y + .85f, this.transform.position.z);
        Destroy(gameObject);
        Instantiate(collectable, carrotSpawnPos, Quaternion.identity);


    }
}
