using UnityEngine;

[System.Serializable]
public class KnifeModel
{
    public int Id;
    public string Name;
    public Sprite Avatar;
    [TextArea(5, 500)]
    public string Description;
    public int Price;
    public bool Unlock;
    public bool Use;
    public Transform Prefab;
}
