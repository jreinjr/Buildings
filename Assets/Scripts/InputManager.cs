using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct Hotkey
{
    public char key;
    public UnityEvent action;
}

public class InputManager : MonoBehaviour
{
    // Singleton instance
    public static InputManager instance = null;

    public Hotkey[] keys;

    private void Awake()
    {
        // Singleton behavior
        if (instance == null) instance = this;
        else if (instance != this) DestroyImmediate(gameObject);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {

        }
    }
}
