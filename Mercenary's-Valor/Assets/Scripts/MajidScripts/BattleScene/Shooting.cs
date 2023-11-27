using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject shootPoint;
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate = 2f;
    [SerializeField] float bulletSpeed = 1;
    float shootCounter = 1;
    [SerializeField] BattleSceneManager battleSceneManagerScript;
    public bool beginShooting = false;

    void Update()
    {
        if (battleSceneManagerScript.p_canHeroWalk == false)
        {
            shootCounter -= fireRate / 2 * Time.deltaTime;
            if (beginShooting)
            {
                InvokeRepeating("StartShooting", 0f, 0.5f);
            }
        }
        else
        {
            CancelInvoke(); // Stop shooting when p_canHeroWalk is true
            shootCounter = 1;
        }
    }

    void StartShooting()
    {
        if (shootCounter <= 0)
        {
            GameObject shot = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
            Rigidbody2D shotRigidbody2d = shot.GetComponent<Rigidbody2D>();
            shotRigidbody2d.velocity = bulletSpeed * transform.right;
            Vector3 dir = transform.right - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            shot.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            shootCounter = 1;
            Destroy(shot, 4.6f);
        }
    }
}
