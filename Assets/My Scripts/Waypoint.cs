using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // The next waypoint in the path
    public Waypoint NextWaypoint;

    // Draw a gizmo at the waypoint position for easy visualization
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.25f);
    }
}
