using UnityEngine;

public abstract class BaseAttribute : BaseMonoBehaviour
{
    [SerializeField] private BaseItemSO _attribute;
    public BaseItemSO _Attribute => _attribute;
}