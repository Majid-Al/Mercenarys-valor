using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    //UI & win/loose condition
    public int p_waveNumberOriginal;
    public int p_enemiesNumberOriginal;
    [SerializeField] public Animator endingPanellAnimator;
    [SerializeField] GameObject textmesh;

    private void Awake()
    {
        p_waveNumberOriginal = GameManager.Instance.p_waveCount;
    }
    private void Start()
    {
        p_enemiesNumberOriginal = GameManager.Instance.p_enemyNumber * p_waveNumberOriginal;
        Debug.Log("p_waveNumberOriginal  =" +p_waveNumberOriginal);
        Debug.Log("GameManager.Instance.p_enemyNumber  = "+GameManager.Instance.p_enemyNumber);
        Debug.Log("p_enemiesNumberOriginal  = " + p_enemiesNumberOriginal);
        EnemyCounterUptade();

    }

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

        if (p_activeEnemies.Count <= 0 && p_waveNumberOriginal <= 0)
        {
            endingPanellAnimator.SetBool("WiningBool", true);
        }

    }
    public void EnemyCounterUptade()
    {
        textmesh.GetComponent<TextMeshProUGUI>().text = p_enemiesNumberOriginal.ToString();
    }
    void plusAttack(float plus)
    {
        p_attackDamage += plus;
    }
}



