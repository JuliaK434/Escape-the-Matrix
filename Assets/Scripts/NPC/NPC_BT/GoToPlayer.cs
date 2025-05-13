using UnityEngine;
using MBT;
using UnityEngine.AI;

[AddComponentMenu("")]
[MBTNode("Actions/GoToPlayer")]
public class GoToPLayer : Leaf
{
    private Blackboard blackboard;
    private bool _initialized = false;
    public override NodeResult Execute()
    {
        if (!_initialized)
        {
            blackboard = gameObject.GetComponent<Blackboard>();

            _initialized = true;
        }


        blackboard._agent.speed = blackboard.ChasingSpeed;
        blackboard._agent.destination = blackboard.lastKnownPlayerPosition;

        if(blackboard._agent.remainingDistance <= blackboard.StopDistance && blackboard.SeePlayer)
        {
            Debug.Log("In GoToPlayer, success => playerCautch");
            return NodeResult.success;
        }
        else if(blackboard._agent.remainingDistance <= blackboard.StopDistance && !blackboard.SeePlayer)
        {
            return NodeResult.failure;
        }

        return NodeResult.running;
    }
}
