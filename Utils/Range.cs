/**
 * Represents a range between min and max float values
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 6.3
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WordsOnPlay.Utils {
[System.Serializable]
public class Range {

	public float min;
	public float max;

	public float size {
		get => max - min;
	}

	public Range(float min, float max) {
		if (min < max) {
			this.min = min;
			this.max = max;
		}
		else {
			this.min = max;
			this.max = min;
		}
	}

	public bool Contains(float x, bool strict = false) {
		if (strict) {
			return x > min && x < max;
		}
		else {
			return x >= min && x <= max;
		}
	}

	public float Lerp(float t) {
		return Mathf.Lerp(min, max, t);
	}


	public float Random() {
		return Lerp(UnityEngine.Random.value);
	}

	public float Clamp(float x) {
		return Mathf.Clamp(x, min, max);
	}

	public float Wrap(float x) {
		x -= min;

		if (x >= 0) {
			return min + x % size;
		}	
		else {
			return min + size + x % size;
		}
	}
}
}