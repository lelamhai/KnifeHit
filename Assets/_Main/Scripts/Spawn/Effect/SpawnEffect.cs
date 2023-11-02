using UnityEngine;

public class SpawnEffect : SingletonSpawnBD<SpawnEffect>
{
    public void SpawnGameObject(TypeEffect typeEffect)
    {
        Spawn((int)typeEffect);
    }    
}

public enum TypeEffect
{
    Apple = 0,
    Wood = 1 
}