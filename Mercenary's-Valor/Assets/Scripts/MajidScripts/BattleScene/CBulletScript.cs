using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBulletScript : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "EnemyAir")
        {
        Destroy(gameObject);
        }
    }
}
