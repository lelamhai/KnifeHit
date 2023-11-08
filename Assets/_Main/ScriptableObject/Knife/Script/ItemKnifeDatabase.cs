using UnityEngine;

[CreateAssetMenu(fileName = "New Item Knife", menuName = "Knife/Items/Knife")]
public class ItemKnifeDatabase : BaseItemDatabase
{
    public KnifeModel Model;

    protected override void SetInfo()
    {}

    protected override void SetPrefab()
    {}
}