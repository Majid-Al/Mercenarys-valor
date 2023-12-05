using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("Developing")]
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
        if (GameObject.Find("OriginalGameManager")) Destroy(gameObject);
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, savingFileName, useEncryption);
        // if (Instance == null)
        // {
        //     Debug.LogError("Found more than one DataPersistenceManager singleton in the Scene");
        // }
        // Instance = this;
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
    public void OnSceneUnloaded(Scene sene)
    {

    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameObject.name = "OriginalDataManager";
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

        // if no data is avalable go slect the correct button dumbAss
        if(this.gameData == null)
        {
            Debug.Log("No data has beed faund.a new Game Must be start");
            return;
        }

        // push all the data to the necesary scripts 
        foreach(IDataPersistance dataPersistenceObj in dataPersistanceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
        Debug.Log("Gold amout is in Load func is : " + gameData.goldAmount);
    }

    public void SaveGame()
    {
        // if there is no data to save, log a warning 
        if (this.gameData == null)
        {
            Debug.LogWarning("No data was found Please start a game");
        }

        // update the data by other scripts
        foreach (IDataPersistance dataPersistenceObj in dataPersistanceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        // save the data to a file using a data handler
        dataHandler.Save(gameData); 
    }

    public void OnApplicationQuit()
    {
        SaveGame();
    }
    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistanceObjects);
    }

    public bool HasGameData()
    {
        return gameData != null;
    }
}
