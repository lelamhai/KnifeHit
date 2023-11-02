using UnityEngine;

[CreateAssetMenu(fileName = "ListKnifeData", menuName = "Knife/Database/Knife/ListKnifeData")]
public class KnifesData : BaseListItemData
{
    protected override void SetDefaultValue()
    {
        _pathFolder = "Knife/Items/";
    }
}