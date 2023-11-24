using UnityEngine;

public class LevelManager : Singleton<LevelManager>, IDataPersistence
{
    [SerializeField] private LevelDatabase _data;

    public int Level
    {
        get => _data.Level;
    }

    private void Awake()
    {
        RegisterData();
    }

    private void OnEnable()
    {
        GameManager.Instance._Initialize += Initialize;
        GameManager.Instance._FinishLevel += FinishLevel;
    }

    private void OnDisable()
    {
        GameManager.Instance._Initialize -= Initialize;
        GameManager.Instance._FinishLevel -= FinishLevel;
    }

    private void FinishLevel()
    {
        _data.Level++;
        DataPersistanceManager.Instance.SaveData();
    }

    private void Initialize()
    {
        SpawnTrunk.Instance.LoadTrunk(Level);
    }

    public void RegisterData()
    {
        DataPersistanceManager.Instance.RegisterEventDataPersistance(this);
    }

    public void LoadData(GameData data)
    {}

    public void SaveData(GameData data)
    {
        data.Level = _data.Level;
    }

    protected override void SetDefaultValue()
    {}
}