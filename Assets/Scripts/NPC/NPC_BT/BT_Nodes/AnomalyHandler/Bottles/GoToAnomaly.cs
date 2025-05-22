using UnityEngine;
using MBT;
using UnityEngine.AI;

[AddComponentMenu("")]
[MBTNode("Actions/GoToAnomaly")]
public class GoToanomaly: Leaf
{
    private Blackboard blackboard;
    private bool _startWalk;
    public override void OnEnter()
    {
        blackboard = gameObject.GetComponent<Blackboard>();
        blackboard.isChase = true;
        blackboard.isStay = false;
        _startWalk = false;
    }
    public override NodeResult Execute()
    {
        blackboard._agent.destination = blackboard.AnomalyPosition;

        if (_startWalk)
        {
            if (blackboard.SeePlayer)
            {
                return NodeResult.success; 
            }

            if (blackboard._agent.remainingDistance <= blackboard.StopDistance)
            {
                // Debug.Log(blackboard._agent.destination);
                // Debug.Log(transform.position);
                return NodeResult.success;
            }

            return NodeResult.running;
        }
        else
        {
            _startWalk = true;
            return NodeResult.running;
        }
    }

    public override void OnExit()
    {
        blackboard.isChase = false;
    }

}
