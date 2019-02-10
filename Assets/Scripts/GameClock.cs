using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameClock : MonoBehaviour
{
    public class OnTickEventArgs : EventArgs
    {
        public uint tick;
    }
    public static event EventHandler<OnTickEventArgs> OnTick;

    private uint tick;
    private float tickTimer;
    public float tickTimerMax = .2f;

    private void Awake()
    {
        tick = 0;
        tickTimer = 0;
    }

    private void Update()
    {
        tickTimer += Time.deltaTime;
        if (tickTimer >= tickTimerMax)
        {
            tickTimer -= tickTimerMax;
            tick++;
            OnTick?.Invoke(this, new OnTickEventArgs { tick = tick });
        }
    }
}
