using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] public string fileName;


    private GameData gameData;

    private List<IdataPersistence> dataPersObjs;

    private FileDataHandler dataHandler;

    private Scene sceneName;
    public static DataPersistenceManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);


    }

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene();
        if (sceneName.name == "MainMenu")
        {
            this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
            this.dataPersObjs = FindAllDataPersObj();
            LoadGame();

        }
        else;
    }

   
    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        if (this.gameData == null)
        {

            NewGame();
        }

        foreach (IdataPersistence dataPersObj in dataPersObjs)
        {
            dataPersObj.LoadData(gameData);

        }


    }

    public void SaveGame()
    {
        foreach (IdataPersistence dataPersObj in dataPersObjs)
        {
            dataPersObj.SaveData(ref gameData);
        }

       
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IdataPersistence> FindAllDataPersObj()
    {
        IEnumerable<IdataPersistence> dataPersObjs = FindObjectsOfType<MonoBehaviour>().OfType<IdataPersistence>();

        return new List<IdataPersistence>(dataPersObjs);
    }
}
