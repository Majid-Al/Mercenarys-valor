using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] GameObject sceneManager;
    BattleSceneManager battleSceneManagerScript;
    void Start()
    {
        battleSceneManagerScript = sceneManager.GetComponent<BattleSceneManager>();
    }
    public void OnImageClicked()
    {
        battleSceneManagerScript.p_canHeroWalk = !battleSceneManagerScript.p_canHeroWalk;
        Debug.Log("changed");
    }

    public void ChangeTheAttack()
    {
        battleSceneManagerScript.p_attackNearestEnemy = !battleSceneManagerScript.p_attackNearestEnemy;
    }

}
