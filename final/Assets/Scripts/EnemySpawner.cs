using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum spawnerStatus { spawning, waiting, counting };

    [SerializeField] private Transform[] spawner;
    [SerializeField] private List<HealthManager> enemyList;
    [SerializeField] private GameObject snowman;

    [SerializeField] private WaveManager[] wavesnumber;
    [SerializeField] private float wavesSleepTime = 3f;
    [SerializeField] private float waveConutdown = 0;

    private spawnerStatus status = spawnerStatus.counting;

    private int currentWave;

    // Start is called before the first frame update
    void Start()
    {
        waveConutdown = wavesSleepTime;
        currentWave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (status == spawnerStatus.waiting)
        {
            if (!enemiesAreDead())
            {
                return;
            }
            else
            {
                CompeleteWave();
            }
        }


        if (waveConutdown <= 0)
        {
            if (status != spawnerStatus.spawning)
            {
                StartCoroutine(SpawnNewWave(wavesnumber[currentWave]));
            }
        }
        else
        {
            waveConutdown -= Time.deltaTime;
        }
    }




    private IEnumerator SpawnNewWave(WaveManager wave)
    {
        status = spawnerStatus.spawning;

        for (int i = 0; i < wave.enemiesNumber; i++)
        {
            SpawnSnowman(wave.enemy);
            yield return new WaitForSeconds(wave.delay);

        }


        status = spawnerStatus.waiting;

        yield break;

    }



    private void SpawnSnowman(GameObject snowman)
    {
        int randomInt = Random.Range(1, spawner.Length);

        Transform randomSpawner = spawner[randomInt];
        GameObject newEnemy = Instantiate(snowman, randomSpawner.position, randomSpawner.rotation);
        HealthManager newEnemyHealth = newEnemy.GetComponent<HealthManager>();
        enemyList.Add(newEnemyHealth);

    }


    private void CompeleteWave()
    {
        status = spawnerStatus.counting;
        waveConutdown = wavesSleepTime;


        if (currentWave + 1 > wavesnumber.Length - 1)
        {
            currentWave = 0;
            Debug.Log("completed all the waves");
            //end the game
        }
        else
        {
            currentWave++;
        }


    }
    private bool enemiesAreDead()
    {
        int i = 0;
        foreach (HealthManager enemy in enemyList)
        {
            if (enemy.IsDead())
            {
                i++;
            }
            else
            {
                return false;
            }

        }
        return true;
    }
}
