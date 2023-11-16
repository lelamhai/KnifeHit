using UnityEngine;

public abstract class BaseDamage : BaseMonoBehaviour
{
    [SerializeField] protected int _damage = 0;
    public int Damage()
    {
        return _damage;
    }
}
