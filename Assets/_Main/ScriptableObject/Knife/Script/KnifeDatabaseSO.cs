using UnityEngine;

[CreateAssetMenu(fileName = "New Database Knife", menuName = "Knife/Database/Knife/DatabaseKnife")]
public class KnifeDatabaseSO : BaseDatabaseSO
{
    protected override void SetDefaultValue()
    {
        _pathFolder = "Knifes/";
    }
}