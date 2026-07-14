/**
 * Extension methods for the Vector2 class
 * 
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 6.3
 */

using UnityEngine;
using System.Collections;

namespace WordsOnPlay.Utils {
public static class Vector2Extensions  {

	/**
	 * Test if vector v1 is on the left of v2
	 */

	public static bool IsOnLeft(this Vector2 v1, Vector2 v2) {
		return v1.x * v2.y < v1.y * v2.x;
	}

	/**
	 * Rorate a 2D vector anticlockwise by the given angle (in degrees)
	 */

	public static Vector2 Rotate(this Vector2 v, float angle) {
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		return q * v;
	}

}
}