/**
 * Extension methods for the Rect class
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 6.3
 */
 
using UnityEngine;
using System.Collections;
using UnityEditor;

namespace WordsOnPlay.Utils {
public static class RectExtensions  {

	/**
	 * Get corners of the rect in clockwise order
	 */

	public static Vector2 Corner(this Rect r, int i) {
		Vector2 p = Vector2.zero;

		switch (((i % 4) + 4) % 4) {
		case 0:
			p = r.min;
			break;
		case 1:
			p = new Vector2(r.xMin, r.yMax);
			break;
		case 2:
			p = r.max;
			break;
		case 3:
			p = new Vector3(r.xMax, r.yMin);
			break;
		}

		return p;
	}

	/**
	 * Clamp a Vector2 to lie within the rect
	 */

	public static Vector2 Clamp(this Rect r, Vector2 v) {
		v.x = Mathf.Clamp(v.x, r.xMin, r.xMax);
		v.y = Mathf.Clamp(v.y, r.yMin, r.yMax);
		return v;
	}


	/**
	 * Clamp a Vector3 to lie within the rect (ignoring z)
	 */

	public static Vector3 Clamp(this Rect r, Vector3 v) {
		v.x = Mathf.Clamp(v.x, r.xMin, r.xMax);
		v.y = Mathf.Clamp(v.y, r.yMin, r.yMax);
		return v;
	}


	/**
	 * Pick a point inside the rect
	 */

	public static Vector3 Point(this Rect r, float x, float y)
	{
		Vector3 v = Vector3.zero;
		v.x = (1-x) * r.xMin + x * r.xMax;
		v.y = (1-y) * r.yMin + y * r.yMax;

		return v;
	}

	/**
	 * Pick a point inside the rect
	 */

	public static Vector3 Point(this Rect r, Vector2 p)
	{
		return r.Point(p.x, p.y);;
	}


	/**
	 * Pick a random point inside the rect
	 */

	public static Vector3 RandomPoint(this Rect r)
	{		
		return r.Point(Random.value, Random.value);
	}

	public static Vector3 RandomPoint(this Rect r, System.Random rng)
	{		
		float x = (float)rng.NextDouble();
		float y = (float)rng.NextDouble();
		return r.Point(x, y);
	}

	/**
	 * Lerp between two Rects
	 */

	public static Rect Lerp(Rect r1, Rect r2, float t) {
		Rect r = new Rect();

		r.xMin = Mathf.Lerp(r1.xMin, r2.xMin, t);
		r.xMax = Mathf.Lerp(r1.xMax, r2.xMax, t);
		r.yMin = Mathf.Lerp(r1.yMin, r2.yMin, t);
		r.yMax = Mathf.Lerp(r1.yMax, r2.yMax, t);

		return r;
	}

	public static void DrawGizmo(this Rect r) {
		for (int i = 0; i < 4; i++) {
			Gizmos.DrawLine(r.Corner(i), r.Corner(i+1));
		}
	}

	public static void DrawGizmo(this Rect r, Transform t) {
		for (int i = 0; i < 4; i++) {
			Gizmos.DrawLine(t.TransformPoint(r.Corner(i)), t.TransformPoint(r.Corner(i+1)));
		}
	}

	public static void DrawGizmoFilled(
		this Rect r, Transform t, Color faceColor, Color outlineColor) {

#if UNITY_EDITOR
		Vector3[] verts = new Vector3[4];
		verts[0] = t.TransformPoint(r.Corner(0));
		verts[1] = t.TransformPoint(r.Corner(1));
		verts[2] = t.TransformPoint(r.Corner(2));
		verts[3] = t.TransformPoint(r.Corner(3));

		Handles.DrawSolidRectangleWithOutline(verts, faceColor, outlineColor);
#endif
	}

}
}