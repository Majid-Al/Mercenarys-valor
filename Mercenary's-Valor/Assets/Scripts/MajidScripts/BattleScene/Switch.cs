using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] GameObject sceneManager;
    [SerializeField] GameObject MenuPanell;
    BattleSceneManager battleSceneManagerScript;
    void Start()
    {
        battleSceneManagerScript = sceneManager.GetComponent<BattleSceneManager>();
    }
    public void OnImageClicked()
    {
        battleSceneManagerScript.p_canHeroWalk = !battleSceneManagerScript.p_canHeroWalk;
    }

    public void ChangeTheAttack()
    {
        battleSceneManagerScript.p_attackNearestEnemy = !battleSceneManagerScript.p_attackNearestEnemy;
    }

    public void PauseMenuActive()
    {
        MenuPanell.SetActive(true);
        Time.timeScale = 0.0f;  
    }
    public void PauseMenuDeactive()
    {
        MenuPanell.SetActive(false);
        Time.timeScale = 1.0f;
    }

}
