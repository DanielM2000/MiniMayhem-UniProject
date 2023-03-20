using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointManager : MonoBehaviour
{
    // A static reference to the WaypointManager instance
    public static WaypointManager Instance;

    // An array to hold all of the waypoints
    public GameObject[] waypoints;

    private void Awake()
    {
        // Set the static reference to this instance
        Instance = this;

        // Find all child objects of this object and add them to the waypoints array
        waypoints = new GameObject[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i).gameObject;
        }
    }

    // Get the waypoint at the specified index
    public GameObject GetWaypoint(int index)
    {
        if (index >= 0 && index < waypoints.Length)
        {
            return waypoints[index];
        }
        else
        {
            Debug.LogWarning("Waypoint index out of range: " + index);
            return null;
        }
    }
}
