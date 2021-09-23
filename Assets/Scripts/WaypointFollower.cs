using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWypointIndex = 0;

    [SerializeField] private float speed = 2f;
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWypointIndex].transform.position, transform.position) < .1f)
        {
            currentWypointIndex++;

            if(currentWypointIndex >= waypoints.Length)
            {
                currentWypointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWypointIndex].transform.position, Time.deltaTime * speed);
    }
}
