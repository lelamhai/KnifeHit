using UnityEngine;

public class Id : MonoBehaviour
{
    [SerializeField] private int _id;

    public int _Id
    {
        get { return _id; }  
        set { _id = value; }
    }
}