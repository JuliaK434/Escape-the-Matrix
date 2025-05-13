using UnityEngine;
using MBT;
using UnityEngine.AI;

[AddComponentMenu("")]
[MBTNode("Actions/Patrol")]
public class Patrol: Leaf
{
    private bool initialized;
    private Blackboard blackboard;
    private int _currentWaypoint = 0;
    private float _waitTimer = 0f;
    private bool _isWaiting = false;


    public override NodeResult Execute()
    {

        if (!initialized)
        {
            blackboard = gameObject.GetComponent<Blackboard>();

            blackboard._agent.destination = blackboard.wayPoints[_currentWaypoint].position;

            initialized = true;

        }

        if(blackboard.wayPoints.Length == 0)
        {
            Debug.Log("Error in Patrol, Add way points");
            return NodeResult.failure;
        }

        if(blackboard.SeePlayer || blackboard.SeeAnomaly)
        {
            Debug.Log("In Patrol: failure: saw player");
            return NodeResult.failure;
        }

        if (_isWaiting)
        {
            _waitTimer += Time.deltaTime;
            if (_waitTimer >= 2f) 
            {
                _isWaiting = false;
                _waitTimer = 0f;

                _currentWaypoint = (_currentWaypoint + 1) % blackboard.wayPoints.Length;
                blackboard._agent.destination = blackboard.wayPoints[_currentWaypoint].position;

                Debug.Log("In Patrol");
                return NodeResult.success;
            }
            return NodeResult.running;
        }

        if (!blackboard._agent.pathPending && blackboard._agent.remainingDistance <= blackboard.StopDistance)
        {
            _isWaiting = true; 
            return NodeResult.running;
        }

        return NodeResult.running;
    }

}
