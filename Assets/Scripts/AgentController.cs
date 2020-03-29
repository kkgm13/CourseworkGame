using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    //Nav Mesh Agent States
    public enum AgentState {
		Idle = 0,
		WalkAround,
		Chasing
	}
    public AgentState state;
    // All waypoint information
    public Transform[] waypoints;
    // Starting WayPoint ID (Custom for each Agent)
    public int waypointID = 0;
    // Get the distance to next point
    public float distanceToStartHeadingToNextWaypoint = 1;
    // Target Object
    public Transform target;
    // Navigational Mesh Agent
    private NavMeshAgent navMeshAgent;
    // Access to Animator Controller 
    private Animator animController;
    // Hashed Walking Speed ID
    private int walkSpeedID;

    void Awake(){
        walkSpeedID = Animator.StringToHash("walkingSpeed");
        navMeshAgent = GetComponent<NavMeshAgent>();
        animController = GetComponent<Animator>();

        // If the list of waypoints is nothing
        if(waypoints.Length == 0){
            // Destroy Object
            GameObject.Destroy(gameObject);
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(state == AgentState.Idle){
            Idle();
        } else if(state == AgentState.WalkAround){
            WalkAround();
        }
    }

    void WalkAround(){
        navMeshAgent.isStopped = false;
        navMeshAgent.stoppingDistance = 0;

        animController.SetFloat(walkSpeedID, 1.0f);

        if(navMeshAgent.remainingDistance <= distanceToStartHeadingToNextWaypoint){
            waypointID = (waypointID+1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[waypointID].position);
        }
    }

    void Idle(){
        navMeshAgent.isStopped = true;
        animController.SetFloat(walkSpeedID, 0.0f);
    }
}
