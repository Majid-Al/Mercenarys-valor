using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneManager : MonoBehaviour
{
    public bool p_canHeroWalk = true;
    public float p_attackDamage = 40;
    public float p_cannonDamage = 50;

    public bool p_attackNearestEnemy = false;
    public bool p_liveEnemies = false;
    public List<GameObject> p_activeEnemies = new List<GameObject>();

    [SerializeField] private float delayTime; // Delay time in seconds
    private float delayTimer = 0.0f; // Timer to track the delay

    void Update()
    {

        if (p_activeEnemies.Count == 0 && p_liveEnemies)
        {
            // Check if the delay timer has reached the desired delay time
            if (delayTimer >= delayTime)
            {
                p_liveEnemies = false;
            }
            else
            {
                // Increment the delay timer
                delayTimer += Time.deltaTime;
            }
        }
        else
        {
            // Reset the delay timer when there are active enemies
            delayTimer = 0.0f;
        }
    }

    void plusAttack(float plus)
    {
        p_attackDamage += plus;
    }
}



