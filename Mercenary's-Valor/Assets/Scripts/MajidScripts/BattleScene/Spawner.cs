using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] BattleSceneManager battleSceneManagerScript;
    [SerializeField] GameObject enemyBasic;
    [SerializeField] GameObject enemyRange;
    [SerializeField] GameObject enemyFast;
    [SerializeField] GameObject enemyTank;
    [SerializeField] GameObject enemySuper;
    [SerializeField] int enemyPoolCap = 5;
    [SerializeField] Vector3 spawnLocationRange1;
    [SerializeField] Vector3 spawnLocationRange2;
    int enemyNumbers;
    int waveCount;

    List<int> enemyCount = new List<int>();
    List<GameObject> summoningEnemys = new List<GameObject>();


    List<GameObject> basicEnemyPool = new List<GameObject>();
    List<GameObject> rangeEnemyPool = new List<GameObject>();
    List<GameObject> fastEnemyPool = new List<GameObject>();
    List<GameObject> tankEnemyPool = new List<GameObject>();

    [SerializeField] private float delayTimeBetweenEnemies;

    [SerializeField] private float enemySpawnDelay; // Delay between enemy spawns
    [SerializeField] private float superCallingWait;

    void Start()
    {
        enemyNumbers = GameManager.Instance.p_enemyNumber;
        waveCount = GameManager.Instance.p_waveCount;

        // Initialize the Enemys pool
        CreatePool(enemyBasic, basicEnemyPool, enemyPoolCap);
        CreatePool(enemyRange, rangeEnemyPool, enemyPoolCap);
        CreatePool(enemyFast, fastEnemyPool, enemyPoolCap);
        CreatePool(enemyTank, tankEnemyPool, enemyPoolCap);

    }
    void Update()
    {
        if (!battleSceneManagerScript.p_liveEnemies && waveCount != 0)
        {
            CallTheSupper();
            EnemyCounter(enemyNumbers);
            GetInactiveEnemy();
            battleSceneManagerScript.p_liveEnemies = true;
            waveCount -= 1;
        }

    }

    void CreatePool(GameObject enemy, List<GameObject> thePool, int enemyNumbers)
    {
        for (int i = 0; i < enemyNumbers; i++)
        {
            GameObject spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity);
            spawnedEnemy.SetActive(false);
            thePool.Add(spawnedEnemy);
        }
    }

    void GetInactiveEnemy()
    {

        List<int> enemylist = enemyCount;
        summoningEnemys.Clear();
        for (int i = 0; i < enemyNumbers; i++)
        {
            if (enemylist[0] > 0)
            {
                summoningEnemys.Add(basicEnemyPool[i]);
            }
            if (enemylist[1] > 0)
            {
                summoningEnemys.Add(rangeEnemyPool[i]);
            }
            if (enemylist[2] > 0)
            {
                summoningEnemys.Add(fastEnemyPool[i]);
            }
            if (enemylist[3] > 0)
            {
                summoningEnemys.Add(tankEnemyPool[i]);
            }
            for (int m = 0; m < 4; m++)
            {
                enemylist[m] -= 1;
            }

            StartCoroutine(SpawnEnemiesWithDelay());
            // foreach (var enemyToSpawn in summoningEnemys)
            // {
            //     enemyToSpawn.transform.position = GetSpawnPosition();
            //     enemyToSpawn.SetActive(true);
            //     enemyToSpawn.GetComponent<Enemy>().p_enemyIsActive = true;
            //     battleSceneManagerScript.p_activeEnemies = summoningEnemys;

            // }

        }

    }
    IEnumerator SpawnEnemiesWithDelay()
    {
        int enemiesToSpawnCount = summoningEnemys.Count;

        for (int i = 0; i < enemiesToSpawnCount; i++)
        {
            GameObject enemyToSpawn = summoningEnemys[i];
            enemyToSpawn.transform.position = GetSpawnPosition();
            enemyToSpawn.SetActive(true);
            enemyToSpawn.GetComponent<Enemy>().p_enemyIsActive = true;
            // make delay
            if (i < enemiesToSpawnCount - 1)
            {
                yield return new WaitForSeconds(enemySpawnDelay);
            }
        }

        // Update the battleSceneManagerScript's p_activeEnemies list once, after all enemies are activated
        battleSceneManagerScript.p_activeEnemies = summoningEnemys;
    }




    Vector3 GetSpawnPosition()
    {
        return new Vector3(Random.Range(spawnLocationRange1.x, spawnLocationRange2.x), Random.Range(spawnLocationRange1.y, spawnLocationRange2.y), 0);
    }

    void EnemyCounter(int x)
    {
        enemyCount.Clear();
        x -= 3;
        int randomNumber = Random.Range(1, x + 1);
        enemyCount.Add(randomNumber);
        x = x - (randomNumber - 1);
        randomNumber = Random.Range(1, x + 1);
        enemyCount.Add(randomNumber);
        x = x - (randomNumber - 1);
        randomNumber = Random.Range(1, x + 1);
        enemyCount.Add(randomNumber);
        x = x - (randomNumber - 1);
        enemyCount.Add(x);

    }

    void CallTheSupper()
    {
        InvokeRepeating("SuperCallingFunc", superCallingWait, superCallingWait);
    }
    private void SuperCallingFunc()
    {
        Instantiate(enemySuper, GetSpawnPosition(), Quaternion.identity);

    }
}
