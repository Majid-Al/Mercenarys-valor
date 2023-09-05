using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{

    GameObject firstOne;
    bool setTarget = false;
    float closestDistance = 999;
    [SerializeField] GameObject haram;

    // shooting 
    [SerializeField] float heroRange = 5;
    [SerializeField] GameObject shootPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate = 2f;
    public bool p_beginShooting = false;

    [SerializeField] GameObject battleSceneManager;
    BattleSceneManager battleSceneManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GetTarget", 0f, 0.5f);
        battleSceneManagerScript = battleSceneManager.GetComponent<BattleSceneManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (p_beginShooting == true)
        {
            StartCoroutine(Shoot());
            p_beginShooting = false;
        }

    }

    // ----------------------------- find the target and select the one who is nearest to 
    #region  GetTarget
    void GetTarget()
    {

        int INDEX = 0;
        // get all the enemys
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] nearEnemys = new GameObject[enemys.Length];
        // filter the enemys and find those in range
        closestDistance = 999;

        foreach (var enemy in enemys)
        {
            if (Vector3.Distance(transform.position, enemy.transform.position) < heroRange)
            {
                nearEnemys[INDEX] = enemy;
                INDEX++;
            }
        }
        // find the first enemy in the range
        if (battleSceneManagerScript.p_attackNearestEnemy == false)
        {
            if (nearEnemys.Length >= 1 && nearEnemys[0])
            {
                foreach (var enemy in nearEnemys)
                {
                    if (enemy != null)
                    {
                        float distance = Vector2.Distance(enemy.transform.position, haram.transform.position);
                        if (distance < closestDistance)
                        {
                            closestDistance = distance;
                            firstOne = enemy;
                            p_beginShooting = true;
                        }
                    }
                }
                setTarget = true;
            }
        }
        if (battleSceneManagerScript.p_attackNearestEnemy == true)
        {
            if (nearEnemys.Length >= 1 && nearEnemys[0])
            {
                foreach (var enemy in nearEnemys)
                {
                    if (enemy != null)
                    {
                        float distance = Vector2.Distance(enemy.transform.position, transform.position);
                        if (distance < closestDistance)
                        {
                            closestDistance = distance;
                            firstOne = enemy;
                            p_beginShooting = true;
                        }
                    }
                }
                setTarget = true;
            }
        }
        // if there is no enemy in the range go back to deffault position
        if (firstOne == null)
        {
            p_beginShooting = false;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            setTarget = false;
        }
    }
    #endregion

    //  start shooting 

    private IEnumerator Shoot()
    {
        if (setTarget)
        {
            GameObject shot = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
            Rigidbody2D bulletRigidbody2d = shot.GetComponent<Rigidbody2D>();
            bulletRigidbody2d.velocity = 1 * transform.right;
            shot.GetComponent<HeroBullet>().SetTarget(firstOne);
            // Destroy(shot, 3f);
            yield return new WaitForSeconds(fireRate);
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, heroRange);
        Gizmos.color = Color.red;

    }




}
