using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour, IDataPersistance
{

    //Singleton instantiation
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = GameObject.FindObjectOfType<GameManager>();
            return instance;
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

    public int Contractnumbers = 0;//To count contract

    private void Awake()
    {
        if (GameObject.Find("OriginalGameManager")) Destroy(gameObject);
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameObject.name = "OriginalGameManager";
        if(UIwoodText != null)
        {
            UIwoodText.text = UIwood.ToString();
            UIstoneText.text = UIstone.ToString();
            UIgoldText.text = UIgold.ToString();
            UIfoodText.text = UIfood.ToString();
        }

    }
    public void ResetContractNumber()
    {
        Contractnumbers = 0;
    }


    // Saving And loading functions (IDataPersistance): 
    public void LoadData(GameData data)
    {
        this.gold = data.goldAmount;
    }
    public void SaveData(ref GameData data)
    {
        data.goldAmount = this.gold;
    }

}

