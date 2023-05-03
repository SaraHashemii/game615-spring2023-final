using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{

    private Camera mainCamera;

    [SerializeField] private ParticleSystem fireParticle;
    [SerializeField] private ParticleSystem hitParticle = null;
    [SerializeField] private float gunRange = 5f;
    [SerializeField] private float fireRate = 0.5f;
    [SerializeField] private float LastShootTime = 0f;
    [SerializeField] private int damage = 1;

    [SerializeField] AudioSource gunShotSound;




    private void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();
        

    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= LastShootTime + fireRate)
        {
            LastShootTime = Time.time;
            Shoot();

        }
    }




    private void Shoot()
    {

        fireParticle.Play();

        gunShotSound.Play();
        Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, gunRange))
        {
            Debug.Log(hit.transform.name);

            EnemyHealthController enemyHealthStatus = hit.transform.GetComponent<EnemyHealthController>();
            if (enemyHealthStatus != null)
            {
                enemyHealthStatus.TakeDamage(damage);
                SpawnHitParticle(hit.point);


            }
        }
    }

    private void SpawnHitParticle(Vector3 position)
    {
        Instantiate(hitParticle, position, Quaternion.identity);
    }

}
