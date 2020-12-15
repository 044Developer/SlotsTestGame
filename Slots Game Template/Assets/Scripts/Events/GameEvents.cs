using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents 
{
    public delegate void GameEvent();
    public static event GameEvent SpinStarted;
    public static event GameEvent SpinEnded;

    public static void OnSpinStarted()
    {
        if (SpinStarted != null)
        {
            SpinStarted();
        }
    }

    public static void OnSpinEnded()
    {
        if (SpinEnded != null)
        {
            SpinEnded();
        }
    }
}
