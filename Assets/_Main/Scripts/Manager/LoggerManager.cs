using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerManager : Singleton<LoggerManager>
{
    [SerializeField] private bool _activeLogger = true;

    public void Log(object message, Object sender)
    {
        if (!_activeLogger) return;
        Debug.Log(message, sender);
    }

    protected override void SetDefaultValue()
    {}
}
