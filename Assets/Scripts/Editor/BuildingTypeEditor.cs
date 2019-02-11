using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildingType))]
[CanEditMultipleObjects]
public class BuildingTypeEditor : Editor
{
    private SerializedProperty _incomeType;

    private void OnEnable()
    {
        _incomeType = serializedObject.FindProperty("incomeType");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(_incomeType, true);
        CreateEditor(_incomeType.objectReferenceValue).OnInspectorGUI();
        serializedObject.ApplyModifiedProperties();
    }
}
