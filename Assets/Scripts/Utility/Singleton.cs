using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T:class, new()
{
   
    // Singleton instance
    private static T _instance = null;

    public static T GetInstance()
    {
        if (_instance == null)
            _instance = new T();
        return _instance;
    }

    private void Awake()
    {
        // Singleton behavior
        if (_instance == null) _instance = this;
        else if ((object)_instance != this) DestroyImmediate(gameObject);
    }

    private void Start()
    {
        GameClock.OnTick += delegate (object sender, GameClock.OnTickEventArgs e)
        {
            OnTick();
        };
    }

    void OnTick()
    {

    }
}
