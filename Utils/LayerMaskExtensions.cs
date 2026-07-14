/**
 * Extensions to the LayerMask class
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 6.3
 */
 
using UnityEngine;
using System.Collections;

namespace WordsOnPlay.Utils {

public static class LayerMaskExtensions  {

	/**
	 * Check if a particular gameobject is included in the layermask
	 */

	public static bool Contains(this LayerMask layerMask, GameObject gameObject) {
		return (layerMask.value & (1 << gameObject.layer)) != 0;
	}

	public static bool Contains(this LayerMask layerMask, Collider collider) {
		return (layerMask.value & (1 << collider.gameObject.layer)) != 0;
	}

	/// <summary>
	/// Get the collision mask for an object from the 3D Physics Collision Matrix  
	/// </summary>
	/// <param name="obj">A gameobject</param>
	/// <returns>A LayerMask containing the layers this object can collder with.</returns>

	public static LayerMask CollisionLayerMask(GameObject obj) 
	{
		int layer = obj.layer;

		int mask = 0;
		for (int j = 0; j < 32; j++)
		{
			if(!Physics.GetIgnoreLayerCollision(layer, j))
			{
				mask |= 1 << j;
			}
		}

		LayerMask layerMask = mask;
		return layerMask;
    }

	/// <summary>
	/// Get the collision mask for an object from the 2D Physics Collision Matrix  
	/// </summary>
	/// <param name="obj">A gameobject</param>
	/// <returns>A LayerMask containing the layers this object can collder with.</returns>

	public static LayerMask CollisionLayerMask2D(GameObject obj) 
	{
		int layer = obj.layer;

		int mask = 0;
		for (int j = 0; j < 32; j++)
		{
			if(!Physics2D.GetIgnoreLayerCollision(layer, j))
			{
				mask |= 1 << j;
			}
		}

		LayerMask layerMask = mask;
		return layerMask;
    }

}
}