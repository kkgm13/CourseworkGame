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
     // Navigational Mesh Agent
    private NavMeshAgent navMeshAgent;
    // Access to Animator Controller 
    private Animator animController;
    // Hashed Walking Speed ID
    private int walkSpeedID;
    // Hashed Attack Target ID
    private int attackID;
    // Starting WayPoint ID (Custom for each Agent)
    private int waypointID = 0;
    // Get the distance to next point
    public float distanceToStartHeadingToNextWaypoint = 1;
    // Get the distance to chase target
    public float distanceToStartChasingTarget = 15.0f;
    // Get distance to start attacking
    public float distanceToStartAttackTarget = 2.0f;
    // Time since last seen the target
    private float timeSinceLastSeenTarget = float.PositiveInfinity;
    // time since last seen 
    private float oldRemainingDistance = float.PositiveInfinity;
    // Target Object
    public Transform target;
    // Rotation Speed
    public float rotationSpeed = 2.0f;
    // Target pursue time
    public float timePursuingTarget = 10;

    void Awake(){
        walkSpeedID = Animator.StringToHash("walkingSpeed");
        attackID = Animator.StringToHash("attackTarget");
        navMeshAgent = GetComponent<NavMeshAgent>();
        animController = GetComponent<Animator>();

        // If the list of waypoints is nothing
        if(waypoints.Length == 0){
            // Destroy Object
            Debug.LogError("Error: List of Waypoints are empty!");
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
        } else {
            Chase();
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

    void Chase(){
        navMeshAgent.stoppingDistance = 1.5f;
        Attack();
        navMeshAgent.SetDestination(target.position);
        timePursuingTarget += Time.deltaTime;

        if(TargetAware()){
            timeSinceLastSeenTarget = 0;
        } 
        if(timePursuingTarget < timeSinceLastSeenTarget){
            WalkAround();
        } else if (RemainingDistance() <= navMeshAgent.stoppingDistance){
            navMeshAgent.isStopped = true;
            animController.SetFloat(walkSpeedID, 0.0f);
            RotateToTarget();
        } else {
            navMeshAgent.isStopped = false;
            animController.SetFloat(walkSpeedID, 1.0f);
        }
    }

    void RotateToTarget(){
        Vector3 planarDifference = (target.position - transform.position);
		planarDifference.y = 0;
		Quaternion targetRotation = Quaternion.LookRotation(planarDifference.normalized);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private bool TargetAware(){
        return RemainingDistance() <= distanceToStartChasingTarget && TargetWithinAngle(90);
    }

    private float RemainingDistance(){
		if(navMeshAgent.pathPending){
			return oldRemainingDistance;
		} else if(!navMeshAgent.hasPath){
			oldRemainingDistance = float.PositiveInfinity;
			return oldRemainingDistance;
		} else {
			float distance = 0;
			Vector3[] corners = navMeshAgent.path.corners;
			for (int i = 0; i < corners.Length - 1; i++){
				distance += Vector3.Distance(corners[i], corners[i+1]);
			}
			oldRemainingDistance = distance;
			return distance;
		}
    }

    private bool TargetWithinAngle(float angle){
		Vector3 planarDiff = target.position - transform.position;
		planarDiff.y = 0;
		float actualAngle = Vector3.Angle(planarDiff, transform.forward);
		return actualAngle <= angle;
	}

    private bool ShouldAttack(){
        return RemainingDistance() < distanceToStartAttackTarget && timeSinceLastSeenTarget <= timePursuingTarget && TargetWithinAngle(45);
    }

    void Attack(){
        if(ShouldAttack()){
            animController.SetTrigger(attackID);
        }
    }
}