/**
 * Extension methods for the MonoBehaviour class
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 6.3
 */

using UnityEngine;
using System;
using System.Collections;

namespace WordsOnPlay.Utils {

public static class MoneBehaviourExtensions  {

	public static Coroutine RunNow(this MonoBehaviour mb, Action action) {
		return mb.StartCoroutine(InlineCR.Now(action));
	}

	public static Coroutine RunNext(this MonoBehaviour mb, Action action) {
		return mb.StartCoroutine(InlineCR.Next(action));
	}

	public static Coroutine RunAfter(this MonoBehaviour mb, float seconds, Action action) {
		return mb.StartCoroutine(InlineCR.After(seconds, action));
	}
}
}