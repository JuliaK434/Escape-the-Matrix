using UnityEngine;
using MBT;
using UnityEngine.AI;

[AddComponentMenu("")]
[MBTNode("Actions/ResetChasing")]
public class ResetChasing: Leaf
{
    private Blackboard _blackboard;
    public override void OnEnter()
    {
        _blackboard = gameObject.GetComponent<Blackboard>();
    }
    public override NodeResult Execute()
    {
        if(_blackboard._agent != null)
        {
            _blackboard._agent.speed = _blackboard.PatrolSpeed;
        }

        _blackboard.lastKnownPlayerPosition = Vector3.zero;
        _blackboard.SeePlayer = false;
        return NodeResult.success;
    }
}
