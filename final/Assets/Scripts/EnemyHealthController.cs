using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : HealthManager
{
    private EnemyUIController enemyUIController;
    [SerializeField] GameObject collectable;

    public float attackSpeed;

    [SerializeField] private bool canAttack;
    [SerializeField] private int damage;


    public void Start()
    {
        InitialVariables();
        enemyUIController = GetComponent<EnemyUIController>();
    }

    public override void CheckHealth()
    {
        base.CheckHealth();
        // enemyUIController.UpdateHealthBar(health, healthMax);
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
