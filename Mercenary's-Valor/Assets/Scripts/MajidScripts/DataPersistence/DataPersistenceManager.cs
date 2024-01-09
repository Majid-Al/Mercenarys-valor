using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Xml.Serialization;

public class DataPersistenceManager : MonoBehaviour
{
    // the save location for Data is at :  
    //                                           ===>    C:\Users\%userprofile%\AppData\LocalLow\<companyname>\<productname>
    //   for majid is this path :                ===>    C:\Users\FaraCom\AppData\LocalLow\DefaultCompany\Mercenary's-Valor       


    [Header("For Developing")]
    [SerializeField] private bool initializeDataIfNull = false;

    [Header("File Storage Config")]
    [SerializeField] private string savingFileName;
    [SerializeField] private bool useEncryption;

    private GameData gameData;
    List<IDataPersistance> dataPersistanceObjects;





    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }
    public static DataPersistenceManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<DataPersistenceManager>();

            }

            return instance;
        }
    }

    private void Awake()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, savingFileName, useEncryption);

    }
    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    public void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;

    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame();

    }
    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
    }


    private void Start()
    {
        
    }
    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        // load any saved data from a file using a data handler
        this.gameData = dataHandler.Load();

        if (this.gameData == null && initializeDataIfNull)
        {
            NewGame();
        }

        if (this.gameData == null) {
            Debug.Log("No data was found. A new game must be Started");
            return;
        }
        foreach (IDataPersistance obj in dataPersistanceObjects)
        {
            obj.LoadData(gameData);
        }
    }
    public void SaveGame()
    {
        if (this.gameData == null)
        {
            Debug.Log("No data was found Please start a game");
            return;
        } 

        foreach (IDataPersistance obj in dataPersistanceObjects)
        {
            obj.SaveData(ref gameData);
        }
        Debug.Log("Gold amout in save func is : " + gameData.goldAmount);

        // save the data to a file using a data handler
        dataHandler.Save(gameData);

    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
    public bool HasGameData()
    {
        return gameData != null;
    }
   private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistanceObjects);
    }
    


}

