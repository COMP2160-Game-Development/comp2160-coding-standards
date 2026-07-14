/**
 * Extension methods for the Vector3 class
 * 
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 6.3
 */

using UnityEngine;
using System.Collections;

namespace WordsOnPlay.Utils {

public static class Vector3Extensions  {

	/**
 	 * Some GLSL-like conversions from Vector3 to Vector2.
     * Implemented as class extensions. So it should be possible to do:
     * 
     * Vector3 v3 = <blah>;
     * Vector2 v2 = v3.zx();
     */

	public static Vector2 xy(this Vector3 v) {
		return v;
	}

	public static Vector2 xz(this Vector3 v) {
		return new Vector2(v.x, v.z);
	}

	public static Vector2 yz(this Vector3 v) {
		return new Vector2(v.y, v.z);
	}

	public static Vector2 yx(this Vector3 v) {
		return new Vector2(v.y, v.x);
	}

	public static Vector2 zx(this Vector3 v) {
		return new Vector2(v.z, v.x);
	}

	public static Vector2 zy(this Vector3 v) {
		return new Vector2(v.z, v.y);
	}

	/**
	 * The normal version of Vector3.ToString only provides 1 decimal place. 
	 * This version shows more.
	 */

	public static string LongString(this Vector3 v) {
		return string.Format("({0}, {1}, {2})", v.x, v.y, v.z);
	}

	/**
	 * Rotate a vector around an axis by a given angle
	 */

	public static Vector3 Rotate(this Vector3 v, float angle, Vector3 axis) {
		return Quaternion.AngleAxis(angle, axis) * v;
	}

}

}