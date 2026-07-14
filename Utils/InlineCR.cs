/**
 * A class for inlining simple coroutines as Actions
 * 
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 6.3
 */
 
using UnityEngine;
using System;
using System.Collections;

namespace WordsOnPlay.Utils {

public static class InlineCR {

    /// <summary>
    /// Simple wrapper for inlining an action as a coroutine.
    /// The action is executed on the current update cycle.
    /// 
    /// E.g.
    /// 
    /// StartCoroutine(InlineCR.Now(() => { Debug.Log("This is a coroutine.")}));
    /// 
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>

    public static IEnumerator Now(Action action)
    {
        action();
        yield return action;
    }

    /// <summary>
    /// Simple wrapper for inlining an action as a coroutine.
    /// The action is executed on the next update cycle.
    /// 
    /// E.g.
    /// 
    /// StartCoroutine(InlineCR.Next(() => { Debug.Log("This is a coroutine.")}));
    /// 
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>

    public static IEnumerator Next(Action action)
    {
        // wait a frame
        yield return null;
        action();
        yield return action;
    }

    /// <summary>
    /// Simple wrapper for inlining an action as a coroutine.
    /// The action is executed after a delay
    /// 
    /// E.g.
    /// 
    /// StartCoroutine(InlineCR.After(10, () => { Debug.Log("This is a coroutine.")}));
    /// 
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>

    public static IEnumerator After(float seconds, Action action)
    {
        // wait a frame
        yield return new WaitForSeconds(seconds);
        action();
        yield return action;
    }

}
}