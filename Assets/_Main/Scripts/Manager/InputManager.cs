using UnityEngine;
using UnityEngine.Events;

public class InputManager : Singleton<InputManager>
{
    public UnityAction _Shooting;
    public UnityAction<Vector3> _Movement;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("InputManager");

            DataPersistanceManager.Instance.SaveData();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("space key was pressed");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space key was pressed");
        }
    }

    public void Movement(Vector3 pos)
    {
        _Movement?.Invoke(pos);
    }

    public void Shooting()
    {
        _Shooting?.Invoke();
    }

    protected override void SetDefaultValue()
    {}
}
