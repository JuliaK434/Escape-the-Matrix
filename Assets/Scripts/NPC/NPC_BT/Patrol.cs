using UnityEngine;
using MBT;
using UnityEngine.AI;

[AddComponentMenu("")]
[MBTNode("Actions/Patrol")]
public class Patrol: Leaf
{
    private Blackboard blackboard;
    private int _currentWaypoint = 0;
    private float _waitTimer = 0f;
    private bool _isWaiting = false;
    private Animator _animator;

    public override void OnEnter()
    {
        blackboard = gameObject.GetComponent<Blackboard>();
        _animator = gameObject.GetComponent<Animator>();

        blackboard._agent.destination = blackboard.wayPoints[_currentWaypoint].position;


        _animator?.SetBool("isWalk", true);
    }
    public override NodeResult Execute()
    { 

        if(blackboard.wayPoints.Length == 0)
        {
            return NodeResult.failure;
        }

        if(blackboard.SeePlayer || blackboard.SeeAnomaly)
        {
            return NodeResult.failure;
        }

        if (_isWaiting)
        {
            _waitTimer += Time.deltaTime;
            if (_waitTimer >= 1.5f) 
            {
                _isWaiting = false;
                _waitTimer = 0f;

                _currentWaypoint = (_currentWaypoint + 1) % blackboard.wayPoints.Length;
                blackboard._agent.destination = blackboard.wayPoints[_currentWaypoint].position;

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

    public override void OnExit()
    {
        _animator?.SetBool("isWalk", false);
    }
}
