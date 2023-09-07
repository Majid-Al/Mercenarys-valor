using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Singleton instantiation
    private static GameManager instanse;
    public static GameManager Instance
    {
        get
        {
            if (instanse == null) instanse = GameObject.FindObjectOfType<GameManager>();
            return instanse;
        }
    }


    public int p_waveCount;
    public int p_enemyNumber;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}






































































































































































