using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBullet : MonoBehaviour

{
    GameObject target;
    [SerializeField] int bulletSpeed;
    public float attackDamage;

    [SerializeField] BattleSceneManager battleSceneManager;

    void Start()
    {
        battleSceneManager = GameObject.Find("BattleSceneManager").GetComponent<BattleSceneManager>();
    }
    void Update()
    {

        attackDamage = battleSceneManager.p_attackDamage;
        if (target == null)
        {

            Destroy(gameObject);
            return;
        }
        // //  go towards selected Enemy (target) at the Speed of speed
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, bulletSpeed * Time.deltaTime * Vector3.Distance(transform.position, target.transform.position));
        Vector3 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // // make the bullet hit directly
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);



    }



    // enemy gets set to target ( this function will get called in the Attacking Script (hero))
    public void SetTarget(GameObject enemy)
    {
        target = enemy;
    }

    public void GetDestroy()
    {
        Destroy(gameObject);
    }
}
