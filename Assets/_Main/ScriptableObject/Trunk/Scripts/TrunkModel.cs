using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TrunkModel
{
    [Header("Base")]
    public int Id;
    public string Name;
    public Transform Prefab;
    public int Health;
    public int Damage;

    [Header("Rotate")]
    public List<RotationElement> TrunkElement = new List<RotationElement>();
}

[System.Serializable]
public struct RotationElement
{
    public float Speed;
    public float Duration;
}