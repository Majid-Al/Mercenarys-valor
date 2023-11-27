using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject target;

    HeroBullet heroBullet;
    // these are set un the unity surface
    [SerializeField] float speed = 1;
    float maxHealth;
    [SerializeField] float health;
    [SerializeField] public float attack;
    [SerializeField] float attackRange;
    float damageRecived;
    public bool p_enemyIsActive = true;

    BattleSceneManager battleSceneManager;



    void Start()
    {
        maxHealth = health;
        battleSceneManager = GameObject.Find("BattleSceneManager").GetComponent<BattleSceneManager>();
        target = GameObject.Find("Base");
    }
    void Update()
    {
        if (p_enemyIsActive && target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "HBullet")
        {
            var theScript = other.gameObject.GetComponent<HeroBullet>();

            damageRecived = theScript.attackDamage;
            GetDamage();
            theScript.GetDestroy();
            if (health < 0)
                Gone();
        }
    }

    void GetDamage()
    {
        health -= damageRecived;
    }
    void Gone()
    {
        health = maxHealth;
        // transform.position = new Vector3(-5, 0, 0);
        battleSceneManager.p_activeEnemies.Remove(gameObject);
        battleSceneManager.p_enemiesNumberOriginal--;
        battleSceneManager.EnemyCounterUptade();
        p_enemyIsActive = false;
        gameObject.SetActive(false);
    }
}


