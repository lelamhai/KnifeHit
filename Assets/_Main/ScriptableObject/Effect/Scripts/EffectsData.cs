using UnityEngine;

[CreateAssetMenu(fileName = "ListEffectData", menuName = "Knife/Database/Effect/ListEffectData")]
public class EffectsData : BaseListItemData
{
    protected override void SetDefaultValue()
    {
        _pathFolder = "Effect/Items/";
    }
}
