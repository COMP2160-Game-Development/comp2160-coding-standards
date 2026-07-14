/**
 * Extensions to the AnimationCurve class
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 6.3
 */
 
 using UnityEngine;
using System;
using System.Collections;

namespace WordsOnPlay.Utils {

public static class AnimationCurveExtensions  {

    /// A coroutine that calculates the current value of the Animation curve and calls an evalCallback.
    /// It calls the doneCallback when it reaches the end of the curver

	public static IEnumerator Run(this AnimationCurve curve, Action<float> evalCallback, Action doneCallback) {

	    float max = curve.keys[curve.length-1].time;
        float t = 0;
        evalCallback(curve.Evaluate(t));

        while (t < max) 
        {
            yield return null;            
            t += Time.deltaTime;
            t = Mathf.Clamp(t,0,max);
            evalCallback(curve.Evaluate(t));
        }
		doneCallback();
	}


}
}