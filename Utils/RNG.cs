/**
 * Wrapper to the System.Random class, that can be overridden with a specific 'random' feed output
 * 
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 6.3
  */

using UnityEngine;

namespace WordsOnPlay.Utils {

public class RNG : MonoBehaviour
{
    [SerializeField] private bool isDebug = false;
    [SerializeField] private int[] debugValues;

    private System.Random rng;
    private int count = 0;

    public int Next(int min, int max) {
        if (isDebug) {
            int v = debugValues[count];
            count = (count + 1) % debugValues.Length;
            return v;
        }

        if (rng == null)
        {
            rng = new System.Random();
        }
        return rng.Next(min, max);
    }
}


}