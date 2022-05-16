using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TaskUtil
{
    public static void Schedule(MonoBehaviour mon ,Action action, float delay)
    {
        mon.StartCoroutine(DelayRoutine(action, delay));
    }

    private static IEnumerator DelayRoutine(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action.Invoke();
        
    }
}
