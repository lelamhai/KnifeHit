using UnityEngine;
public class SpawnKnife : SingletonSpawnBD<SpawnKnife>
{
    [SerializeField] private bool _canShooting = false;
    //[SerializeField] private TypeKnife _currentKnife = TypeKnife.Knife0;

    private void OnEnable()
    {
        GameManager.Instance._StartGame += StartGame;
        GameManager.Instance._SetupLevel += SetupLevel;
        InputManager.Instance._Shooting += Shooting;


        //GameManager.Instance._GameOver += EndGame;
        //GameManager.Instance._NextLevelUp += EndGame;
        //GameManager.Instance._FinishGame += EndGame;
    }

    private void OnDisable()
    {
        GameManager.Instance._StartGame -= StartGame;
        GameManager.Instance._SetupLevel -= SetupLevel;
        InputManager.Instance._Shooting -= Shooting;


        //GameManager.Instance._GameOver -= EndGame;
        //GameManager.Instance._NextLevelUp -= EndGame;
        //GameManager.Instance._FinishGame -= EndGame;
    }

    private void SetupLevel(int count)
    {
        StartGame();
        //Clear();
        Initial(count);
    }


    private void StartGame()
    {
        _canShooting = true;
    }

    //private void EndGame()
    //{
    //    _isShooting = false;
    //}

    //private void Clear()
    //{
    //    _isShooting = true;
    //    //_baseHolders.ResetGame();
    //}

    private void Initial(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnGameObject(TypeKnife.Knife_01);
        }
    }

    public void SpawnGameObject(TypeKnife typeKnife)
    {
        Spawn((int)typeKnife);
    }

    private void Shooting()
    {
        if (!_canShooting) return;

        var move = _baseHolders.transform.GetChild(0).GetComponent<MoveKnife>();
        move.enabled = true;

        var box = _baseHolders.transform.GetChild(0).GetComponent<BoxCollider2D>();
        box.enabled = true;

        //UIManger.Instance.Shooting();
    }
}

public enum TypeKnife
{
    None = 0,
    Knife_01 = 1,
    Knife_02 = 2
}