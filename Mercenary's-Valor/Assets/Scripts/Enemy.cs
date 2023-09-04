using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject target;
    HeroBullet heroBullet;
    // these are set un the unity surface
    [SerializeField] float speed = 1;
    [SerializeField] float health;
    [SerializeField] float attack;
    [SerializeField] float attackRange;
    float damageRecived;
    bool isActive = true;

    [SerializeField] BattleSceneManager battleSceneManager;



    void Start()
    {
        battleSceneManager = GameObject.Find("BattleSceneManager").GetComponent<BattleSceneManager>();
    }
    void Update()
    {
        if (isActive)
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        if (health < 0)
            Gone();
    }




    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "HBullet")
        {
            var theScript = other.gameObject.GetComponent<HeroBullet>();

            damageRecived = theScript.attackDamage;
            GetDamage();
            theScript.GetDestroy();
        }
        if (other.gameObject.tag == "CBullet")
        {
            damageRecived = battleSceneManager.p_cannonDamage;
            GetDamage();
        }
    }

    void GetDamage()
    {
        health -= damageRecived;
    }
    void Gone()
    {
        gameObject.SetActive(false);
        transform.position = new Vector3(-5, 0, 0);
        isActive = false;

    }
}


