using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneManager : MonoBehaviour
{
    public bool p_canHeroWalk = true;
    public float p_attackDamage = 40;
    public float p_cannonDamage = 5;

    public bool p_attackNearestEnemy = false;



    void plusAttack(float plus)
    {
        p_attackDamage += plus;
    }
}
