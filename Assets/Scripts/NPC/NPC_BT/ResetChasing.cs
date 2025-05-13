using UnityEngine;
using MBT;
using UnityEngine.AI;

[AddComponentMenu("")]
[MBTNode("Actions/ResetChasing")]
public class ResetChasing: Leaf
{
    private Blackboard _blackboard;
    private bool _initialized;

    public override NodeResult Execute()
    {
        Debug.Log("In ResetChasing");
        if (!_initialized)
        {
            _blackboard = gameObject.GetComponent<Blackboard>();
            _initialized = true;
        }

        if(_blackboard._agent != null)
        {
            _blackboard._agent.speed = _blackboard.PatrolSpeed;
        }

        _blackboard.lastKnownPlayerPosition = Vector3.zero;
        _blackboard.SeePlayer = false;
        return NodeResult.success;
    }
}
