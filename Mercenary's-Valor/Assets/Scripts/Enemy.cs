using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject target;

    HeroBullet heroBullet;
    // these are set un the unity surface
    [SerializeField] float speed = 1;
    [SerializeField] float health;
    [SerializeField] public float attack;
    [SerializeField] float attackRange;
    float damageRecived;
    bool isActive = true;

    [SerializeField] BattleSceneManager battleSceneManager;



    void Start()
    {
        target = GameObject.Find("Base");
    }
    void Update()
    {
        if (isActive && target != null)
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
        if (other.gameObject.tag == "CBullet")
        {
            damageRecived = battleSceneManager.p_cannonDamage;
            GetDamage();
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
        gameObject.SetActive(false);
        transform.position = new Vector3(-5, 0, 0);
        isActive = false;

    }
}


