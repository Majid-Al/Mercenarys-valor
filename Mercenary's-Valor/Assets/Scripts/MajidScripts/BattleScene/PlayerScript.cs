using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] BattleSceneManager battleSceneManager;

    [SerializeField] private float health;
    float damageRecived;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            var theScript = other.gameObject.GetComponent<Enemy>();

            damageRecived = theScript.attack;
            GetDamage();
        }else if (other.gameObject.tag == "EnemyAir")
        {
            var theScript = other.gameObject.GetComponent<EnemyAir>();

            damageRecived = theScript.attack;
            GetDamage();
        }
    }

    void GetDamage()
    {
        health -= damageRecived;
        if (health < 0)
            Die();
    }
    void Die()
    {
        battleSceneManager.endingPanellAnimator.SetBool("LoosingBool", true);
        Destroy(gameObject);
    }
}
