using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Inventory))]
[CanEditMultipleObjects]
public class InventoryEditor : Editor
{
    private SerializedProperty _resource;

    private void OnEnable()
    {
        _resource = serializedObject.FindProperty("resource");
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        //EditorGUILayout.PropertyField(_resource, true);
       // CreateEditor(_resource.objectReferenceValue).OnInspectorGUI();
        serializedObject.ApplyModifiedProperties();
    }
}
