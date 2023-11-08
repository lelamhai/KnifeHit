using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(DataPersistanceManager))]
public class DataPersistanceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Save"))
        {
            DataPersistanceManager.Instance.SaveData();
        }

        if (GUILayout.Button("Open"))
        {
            DataPersistanceManager.Instance.OpenFolder();
        }

        if (GUILayout.Button("Clear"))
        {
            DataPersistanceManager.Instance.ClearData();
        }
    }
}