using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [Header("Text's value")]
    public int stone = 10;
    public int gold = 10;
    public int food = 10;
    public int wood = 10;

    [Header("Text In UI")]
    public int UIstone = 100;
    public int UIgold = 100;
    public int UIfood = 100;
    public int UIwood = 100;

    [SerializeField] private TextMeshProUGUI UIwoodText;
    [SerializeField] private TextMeshProUGUI UIstoneText;
    [SerializeField] private TextMeshProUGUI UIgoldText;
    [SerializeField] private TextMeshProUGUI UIfoodText;

    void Start()
    {
       // UIwoodText.text = UIwood.ToString();
       // UIstoneText.text =UIstone.ToString();
       // UIgoldText.text = UIgold.ToString();
       // UIfoodText.text = UIfood.ToString();

    }

    // Update is called once per frame
    void Update()
    {

    }


}


