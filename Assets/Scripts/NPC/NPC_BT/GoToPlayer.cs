using UnityEngine;
using MBT;
using UnityEngine.AI;

[AddComponentMenu("")]
[MBTNode("Actions/GoToPlayer")]
public class GoToPLayer : Leaf
{
    private Blackboard blackboard;
    private Animator _animator;

    public override void OnEnter()
    {
        blackboard = gameObject.GetComponent<Blackboard>();
        _animator = gameObject.GetComponent<Animator>();

        _animator?.SetBool("isChase", true);
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
        _animator?.SetBool("isChase", false);
    }

}
