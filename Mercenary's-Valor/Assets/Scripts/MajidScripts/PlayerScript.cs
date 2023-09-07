using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] GameObject battleSceneManager;

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
        Destroy(gameObject);
    }
}
