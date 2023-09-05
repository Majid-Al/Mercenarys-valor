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
    int enemyNumbers;
    int waveCount;
    List<int> enemyCount = new List<int>();
    List<GameObject> summoningEnemys = new List<GameObject>();


    List<GameObject> basicEnemyPool = new List<GameObject>();
    List<GameObject> rangeEnemyPool = new List<GameObject>();
    List<GameObject> fastEnemyPool = new List<GameObject>();
    List<GameObject> tankEnemyPool = new List<GameObject>();

    bool liveEnemies;

    void Start()
    {
        enemyNumbers = GameManager.Instance.p_enemyNumber;
        waveCount = GameManager.Instance.p_waveCount;

        // Initialize the Enemys pool
        CreatePool(enemyBasic, basicEnemyPool, 5);
        CreatePool(enemyRange, rangeEnemyPool, 5);
        CreatePool(enemyFast, fastEnemyPool, 5);
        CreatePool(enemyTank, tankEnemyPool, 5);

    }
    void Update()
    {
        liveEnemies = battleSceneManagerScript.p_liveEnemies;
        if (!liveEnemies && waveCount != 0)
        {
            EnemyCounter(enemyNumbers);
            GetInactiveEnemy();
            liveEnemies = true;
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

            foreach (var enemyToSpawn in summoningEnemys)
            {
                enemyToSpawn.transform.position = GetSpawnPosition();
                enemyToSpawn.SetActive(true);
                battleSceneManagerScript.p_activeEnemies = summoningEnemys;
            }

        }
    }



    Vector3 GetSpawnPosition()
    {
        return new Vector3(Random.Range(-2.2f, 2.5f), 6, 0);
    }


    void EnemyCounter(int x)
    {
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


}
