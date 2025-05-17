using UnityEngine;
using MBT;
using UnityEngine.AI;

[AddComponentMenu("")]
[MBTNode("Actions/GoToPlayer")]
public class GoToPLayer : Leaf
{
    private Blackboard blackboard;

    public override void OnEnter()
    {
        blackboard = gameObject.GetComponent<Blackboard>();
        blackboard.isChase = true;
    }
    public override NodeResult Execute()
    {

        blackboard._agent.speed = blackboard.ChasingSpeed;
        blackboard._agent.destination = blackboard.lastKnownPlayerPosition;

        if(blackboard._agent.remainingDistance <= blackboard.StopDistance && blackboard.SeePlayer)
        {
            return NodeResult.success;
        }
        else if(blackboard._agent.remainingDistance <= blackboard.StopDistance && !blackboard.SeePlayer)
        {
            return NodeResult.failure;
        }

        return NodeResult.running;
    }

    public override void OnExit()
    {
        blackboard.isChase = false;
    }

}
