/**
 * Draw a path gizmo showing the movement of an object
 *
 * Author: Malcolm Ryan
 * Version: 1.0
 * For Unity Version: 6.3.7
 */

using System.Collections.Generic;
using UnityEngine;

public class PathGizmo : MonoBehaviour
{
#region Parameters
    [SerializeField] private float pathDuration = 10;   // seconds
    [SerializeField] private float pointRadius = 0.1f;  // metres
    [SerializeField] private Color color = Color.yellow;
#endregion

#region State
    private Queue<Vector3> points;
    private Queue<float> times;
#endregion

#region Init & Destroy
    void Awake()
    {
        points = new Queue<Vector3>();
        times = new Queue<float>();

        points.Enqueue(transform.position);
        times.Enqueue(Time.time);
    }
#endregion

#region Update
    void Update()
    {
        points.Enqueue(transform.position);
        times.Enqueue(Time.time);

        // remove old records
        float t = times.Peek();
        while (t < Time.time - pathDuration)
        {   
            points.Dequeue();
            times.Dequeue();

            t = times.Peek();
        }        
    }
#endregion

#region Gizmos
    void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = color;
            Vector3? prev = null;

            foreach (Vector3 p in points)
            {
                Gizmos.DrawSphere(p, pointRadius); 
                if (prev != null)
                {
                    Gizmos.DrawLine(prev.Value, p); 
                }
                prev = p;
            }            
        }
    }
#endregion

}
