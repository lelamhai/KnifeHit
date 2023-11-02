using UnityEngine;

public class SpawnKnifeUI : BaseSpawn
{
    private void OnEnable()
    {
        GameManager.Instance._SetupLevel += SetupLevel;
    }

    private void OnDisable()
    {
        GameManager.Instance._SetupLevel -= SetupLevel;
    }

    private void SetupLevel(int count)
    {
        for (int i = 0; i < count; i++)
        {
            Spawn();
        }
    }
}