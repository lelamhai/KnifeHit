using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataPersistanceManager : Singleton<DataPersistanceManager>
{
    [Header("File Storage Config")]
    [SerializeField] private string _fileName;
    [SerializeField] private bool _useEncryption;

    private List<IDataPersistence> _dataPersistenceObjects = new List<IDataPersistence>();
    private GameData _gameData;
    private FileDataHandler _dataHandler;

    private void Awake()
    {
        this._dataHandler = new FileDataHandler(Application.persistentDataPath, _fileName, _useEncryption);
        LoadGame();
    }
    private void OnDestroy()
    {
        SaveData();
    }

    private void NewGame()
    {
        this._gameData = new GameData();
    }

    private void LoadGame()
    {
        this._gameData = _dataHandler.Load();

        if (this._gameData == null)
        {
            Debug.Log("No data was found. Initailizing data to defaults");
            NewGame();
        }

        foreach (IDataPersistence dataPersistenceObj in _dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(_gameData);
        }
    }

    private void SaveGame()
    {
        foreach (IDataPersistence dataPersistenceObj in _dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(_gameData);
        }

        _dataHandler.Save(_gameData);
        Debug.Log("Saved...");
    }

    public void ClearData()
    {
        string fullPath = Path.Combine(Application.persistentDataPath, _fileName);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
            Debug.Log("Clear data");
            return;
        }
        Debug.Log("Not clear data");
    }

    public void OpenFolder()
    {
        System.Diagnostics.Process.Start(Application.persistentDataPath);
    }

    public void SaveData()
    {
        SaveGame();
    }

    public void RegisterEventDataPersistance(IDataPersistence dataPersistence)
    {
        _dataPersistenceObjects.Add(dataPersistence);
    }

    protected override void SetDefaultValue()
    {
        _fileName = "GameData.game";
    }
}