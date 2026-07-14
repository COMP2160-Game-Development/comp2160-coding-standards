/**
 * Extension methods for the Object class
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 6.3
 */
 
using UnityEngine;
using System.Collections;

namespace WordsOnPlay.Utils {
	public static class ObjectExtensions
	{

        /**
		 * A simplified version of Object.FindObjectOfType() that eliminates the need for type-casting.
		 */

        [System.Obsolete]
        public static T FindObjectOfType<T>(this Object o) where T : Object
		{
			return (T)Object.FindObjectOfType(typeof(T));
		}

        /**
		 * A simplified version of Object.FindObjectsOfType() that eliminates the need for type-casting.
		 */

        [System.Obsolete]
        public static T[] FindObjectsOfType<T>(this Object o) where T : Object
		{
			return (T[])Object.FindObjectsOfType(typeof(T));
		}

		/**
		* A simplified version of Object.FindFirstObjectByType() that eliminates the need for type-casting.
		*/

		public static T FindFirstObjectByType<T>(this Object o) where T : Object {
			return (T) Object.FindFirstObjectByType (typeof(T));
		}
			
		/**
		* A simplified version of Object.FindObjectsOfType() that eliminates the need for type-casting.
		*/

		public static T[] FindObjectsByType<T>(this Object o) where T : Object {
			return (T[]) Object.FindObjectsByType (typeof(T), FindObjectsSortMode.None);
		}

	}
}