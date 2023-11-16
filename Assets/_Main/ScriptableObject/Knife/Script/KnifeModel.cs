using UnityEngine;

[System.Serializable]
public class KnifeModel
{
    [Header("Base")]
    public int Id;
    public string Name;
    public Transform Prefab;

    [Header("Player")]
    public Sprite Avatar;
    [TextArea(5, 500)]
    public string Description;
    public int Price;
    public bool Unlock;
    public bool Use;
}
