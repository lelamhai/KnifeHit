using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerManager : Singleton<LoggerManager>
{
    [SerializeField] private bool _activeCustomLog = true;
    [SerializeField] private bool _activeLog = true;
    [SerializeField] private bool _activeWarning = true;
    [SerializeField] private bool _activeError = true;

    public void CustomLog(object message, Object sender)
    {
        if (!_activeCustomLog) return;
        Debug.Log(message, sender);
    }

    public void Log(object message, Object sender =null)
    {
        if (!_activeLog) return;
        Debug.Log(message, sender);
    }

    public void LogWarning(object message, Object sender)
    {
        if (!_activeWarning) return;
        Debug.LogWarning(message, sender);
    }

    public void LogError(object message, Object sender)
    {
        if (!_activeError) return;
        Debug.LogError(message, sender);
    }

    protected override void SetDefaultValue()
    {}
}
