using UnityEngine;

public abstract class BaseReceiveDamage : BaseMonoBehaviour
{
    [SerializeField] protected int _maxHealth = 1;
    [SerializeField] protected int _currentHealth = 1;

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            DeadGameObject();
            return;
        }
    }

    protected abstract void DeadGameObject();
}