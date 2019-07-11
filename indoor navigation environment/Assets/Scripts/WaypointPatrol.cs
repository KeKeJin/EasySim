using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    float dist = 0f;
    int m_CurrentWaypointIndex;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Start ()
    {
        Debug.Log("scripts start");
        navMeshAgent.SetDestination (waypoints[0].position);

    }

    void Update ()
    {

         
      //  dist = Vector3.Distance(transform.position, waypoints[m_CurrentWaypointIndex].position);

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination (waypoints[m_CurrentWaypointIndex].position);

        }
    }
}
