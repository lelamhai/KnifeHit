using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Instance.SetStage(GameStates.EndGame);
        }
    }
}
